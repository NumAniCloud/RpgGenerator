using System.Collections.Generic;
using System.Linq;
using Deptorygen.Utilities;
using RpgGenerator.Syntax;
using RpgGenerator.Utilities;

namespace RpgGenerator.Generation.Analyzer
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