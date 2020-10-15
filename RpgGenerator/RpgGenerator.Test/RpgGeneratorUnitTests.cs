using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using TestHelper;
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
