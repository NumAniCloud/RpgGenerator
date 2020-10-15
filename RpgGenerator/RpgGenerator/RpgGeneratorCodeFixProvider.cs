using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using RpgGenerator.Generation;

namespace RpgGenerator
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(RpgGeneratorCodeFixProvider)), Shared]
	public class RpgGeneratorCodeFixProvider : CodeFixProvider
	{
		private const string Title = "Generate phase system";

		public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(RpgGeneratorAnalyzer.DiagnosticId);

		public sealed override FixAllProvider GetFixAllProvider()
		{
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var diagnostic = context.Diagnostics.First();

			context.RegisterCodeFix(
				CodeAction.Create(
					title: Title,
					createChangedSolution: c => PhaseSystemGenerator.ApplyCodeFixAsync(context.Document, diagnostic.Location.SourceSpan, c), 
					equivalenceKey: Title),
				diagnostic);

			return Task.CompletedTask;
		}
	}
}
