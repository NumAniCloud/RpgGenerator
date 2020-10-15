using System.Collections.Generic;
using System.Linq;
using Deptorygen.Utilities;
using RpgGenerator.Syntax;
using RpgGenerator.Utilities;

namespace RpgGenerator.Generation.Analyzer
{
	public class ParameterAnalyzer
	{
		public TypeName TypeName { get; }
		public string Name { get; }

		public ParameterAnalyzer(TypeName typeName, string name)
		{
			TypeName = typeName;
			Name = name;
		}

		public static IEnumerable<ParameterAnalyzer> FromMethod(PhaseMethodSyntax method)
		{
			var context = method.ContextParameter.AsEnumerable()
				.Select(x => new ParameterAnalyzer(x.TypeName, x.Name));
			var additional = method.AdditionalParameters
				.Select(parameter => new ParameterAnalyzer(parameter.TypeName, parameter.Name));
			return context.Concat(additional);
		}
	}
}