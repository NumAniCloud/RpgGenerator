using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RpgGenerator.Generator.PassiveDecoration.Semantics;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.PassiveDecoration.Template;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration
{
	class PassiveDecorationGenerator
	{
		private static readonly LocalizableString Title = new LocalizableResourceString(
			nameof(Resources.PassiveTitle), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString MessageFormat = new LocalizableResourceString(
			nameof(Resources.PassiveMessageFormat), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString Description = new LocalizableResourceString(
			nameof(Resources.PassiveDescription), Resources.ResourceManager, typeof(Resources));
		private const string Category = "Implementation";

		public const string Id = "RPG002";
		public static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
			Id, Title, MessageFormat, Category,
			DiagnosticSeverity.Info, isEnabledByDefault: true,
			description: Description);

		public static async Task<Solution> ApplyCodeFix(Document document, TextSpan diagnosticSpan, CancellationToken ct)
		{
			var root = await document.GetSyntaxRootAsync(ct).ConfigureAwait(false);
			var declaration = root.FindToken(diagnosticSpan.Start)
				.Parent
				.AncestorsAndSelf()
				.OfType<TypeDeclarationSyntax>()
				.First();

			if (!(declaration is ClassDeclarationSyntax ids))
				return document.Project.Solution;

			var syntax = await PassiveDeclarationSyntax.FromParseAsync(ids, document, ct);
			var semantics = SemanticsRoot.FromSyntax(syntax);
			var template = new PassiveProcessTemplate(semantics);
			return ApplyGeneratedCode(document, template);
		}

		private static Solution ApplyGeneratedCode(Document document, PassiveProcessTemplate template)
		{
			var code = template.TransformText();

			var fileName = $"{template.Root.DecorationName}.g.cs";
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
