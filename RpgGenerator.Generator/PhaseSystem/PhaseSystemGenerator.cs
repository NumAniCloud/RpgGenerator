using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Deptorygen.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RpgGenerator.Generation.Analyzer;
using RpgGenerator.Syntax;
using RpgGenerator.PhaseSystem.Template;

namespace RpgGenerator.Generation
{
	class PhaseSystemGenerator
	{
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
