using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using RpgGenerator.Generator.PassiveDecoration;
using RpgGenerator.Generator.PhaseSystem;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class RpgGeneratorAnalyzer : DiagnosticAnalyzer
	{
		public const string DiagnosticId = "RpgGenerator";

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
			=> ImmutableArray.CreateRange(new[]
			{
				PhaseSystemGenerator.Rule,
				PassiveDecorationGenerator.Rule,
			});

		public override void Initialize(AnalysisContext context)
		{
			context.EnableConcurrentExecution();
			context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
		}

		private static void AnalyzeSymbol(SymbolAnalysisContext context)
		{
			var namedTypeSymbol = (INamedTypeSymbol)context.Symbol; 
			
			if (namedTypeSymbol.HasAttribute("PhasesAttribute"))
			{
				var diagnostic = Diagnostic.Create(
					PhaseSystemGenerator.Rule,
					namedTypeSymbol.Locations[0],
					namedTypeSymbol.Name);
				context.ReportDiagnostic(diagnostic);
			}

			if (namedTypeSymbol.HasAttribute("PassiveDecorationAttribute"))
			{
				var diagnostic = Diagnostic.Create(
					PassiveDecorationGenerator.Rule,
					namedTypeSymbol.Locations[0],
					namedTypeSymbol.Name);
				context.ReportDiagnostic(diagnostic);
			}
		}
	}
}
