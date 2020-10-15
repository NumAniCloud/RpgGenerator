using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
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