﻿using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RpgGenerator.Generator.PhaseSystem.Analyzer;
using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.PhaseSystem.Template;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem
{
	class PhaseSystemGenerator
	{
		private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
		private const string Category = "Implementation";

		public const string Id = "RPG001";
		public static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
			Id, Title, MessageFormat, Category,
			DiagnosticSeverity.Info, isEnabledByDefault: true,
			description: Description);

		public static async Task<Solution> ApplyCodeFixAsync(Document document, TextSpan diagnosticSpan, CancellationToken ct)
		{
			var root = await document.GetSyntaxRootAsync(ct).ConfigureAwait(false);
			var declaration = root.FindToken(diagnosticSpan.Start)
				.Parent
				.AncestorsAndSelf()
				.OfType<TypeDeclarationSyntax>()
				.First();

			if (!(declaration is InterfaceDeclarationSyntax ids))
				return document.Project.Solution;

			var syntax = await PhaseGroupSyntax.FromDeclarationAsync(ids, document, ct);
			var semantics = AnalyzerRoot.FromPhaseGroup(syntax);
			var template = new PhaseTemplate(semantics);
			return ApplyGeneratedCode(document, template);
		}

		private static Solution ApplyGeneratedCode(Document document, PhaseTemplate template)
		{
			var code = template.TransformText();

			var fileName = $"{template.Root.PhaseGroupName}.g.cs";
			var existing = document.Project.Documents
				.Where(d => d.Folders.IsStructualEqual(document.Folders))
				.FirstOrDefault(d => d.Name == fileName);
			if (existing is { })
			{
				var newDoc = existing.WithText(SourceText.From(code, Encoding.UTF8));
				return newDoc.Project.Solution;
			}

			var newDocument = document.Project.AddDocument(
				fileName,
				SourceText.From(code, Encoding.UTF8),
				document.Folders);

			return newDocument.Project.Solution;
		}
	}
}
