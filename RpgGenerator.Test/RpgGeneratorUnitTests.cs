using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using RpgGenerator.Generator;
using Xunit;

namespace RpgGenerator.Test
{
	public class RpgGeneratorUnitTests : ConventionCodeFixVerifier
	{
		[Fact]
		public void Basic() => VerifyCSharpByConvention();

		protected override CodeFixProvider GetCSharpCodeFixProvider() => new RpgGeneratorCodeFixProvider();

		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() => new RpgGeneratorAnalyzer();
	}
}
