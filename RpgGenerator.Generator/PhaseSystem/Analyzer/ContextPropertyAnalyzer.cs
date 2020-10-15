using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class ContextPropertyAnalyzer
	{
		public TypeName Type { get; }
		public string PropertyName { get; }

		public ContextPropertyAnalyzer(TypeName type, string propertyName)
		{
			Type = type;
			PropertyName = propertyName;
		}

		public string GetParameterName() => PropertyName.ToLowerCamelCase();

		public static IEnumerable<ContextPropertyAnalyzer> FromMethod(PhaseMethodSyntax method)
		{
			return method.AdditionalParameters
				.Select(parameter => new ContextPropertyAnalyzer(parameter.TypeName, parameter.Name.ToUpperCamelCase()));
		}
	}
}