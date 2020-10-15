using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class ResultTypeAnalyzer
	{
		public TypeName TypeName { get; }

		public ResultTypeAnalyzer(TypeName typeName)
		{
			TypeName = typeName;
		}

		public static ResultTypeAnalyzer FromSyntax(ResultTypeSyntax methodResultType)
		{
			return new ResultTypeAnalyzer(methodResultType.Name);
		}
	}
}