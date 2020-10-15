using RpgGenerator.Syntax;
using RpgGenerator.Utilities;

namespace RpgGenerator.Generation.Analyzer
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