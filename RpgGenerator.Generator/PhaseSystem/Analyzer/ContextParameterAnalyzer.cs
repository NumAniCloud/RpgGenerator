using RpgGenerator.Syntax;
using RpgGenerator.Utilities;

namespace RpgGenerator.Generation.Analyzer
{
	public class ContextParameterAnalyzer
	{
		public TypeName TypeName { get; }
		public string Name { get; }

		public ContextParameterAnalyzer(TypeName typeName, string name)
		{
			TypeName = typeName;
			Name = name;
		}

		public static ContextParameterAnalyzer? FromMethod(PhaseMethodSyntax method)
		{
			return method.ContextParameter is {} p
				? new ContextParameterAnalyzer(p.TypeName, p.Name)
				: null;
		}
	}
}