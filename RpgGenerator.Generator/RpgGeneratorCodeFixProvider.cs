using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using RpgGenerator.Generator.PassiveDecoration;
using RpgGenerator.Generator.PhaseSystem;

namespace RpgGenerator.Generator
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(RpgGeneratorCodeFixProvider)), Shared]
	public class RpgGeneratorCodeFixProvider : CodeFixProvider
	{
		public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.CreateRange(
			new List<string>
			{
				PhaseSystemGenerator.Id,
				PassiveDecorationGenerator.Id,
			});

		public sealed override FixAllProvider GetFixAllProvider()
		{
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var diagnostic = context.Diagnostics.First();

			var action = diagnostic.Id switch
			{
				PhaseSystemGenerator.Id => CodeAction.Create(
					title: "Generate phase system",
					createChangedSolution: c => PhaseSystemGenerator.ApplyCodeFixAsync(context.Document, diagnostic.Location.SourceSpan, c), 
					equivalenceKey: PhaseSystemGenerator.Id),
				PassiveDecorationGenerator.Id => CodeAction.Create(
					title: "Generate passive decorator system",
					createChangedSolution: c => PassiveDecorationGenerator.ApplyCodeFix(context.Document, diagnostic.Location.SourceSpan, c), 
					equivalenceKey: PassiveDecorationGenerator.Id),
				_ => null
			};

			if (action is {})
			{
				context.RegisterCodeFix(action, diagnostic);
			}

			return Task.CompletedTask;
		}
	}
}
