using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class ContextDelegationPropertyAnalyzer
	{
		public string ContextTypeName { get; }
		public string PropertyName { get; }
		public string ParameterName => PropertyName.ToLowerCamelCase();
		public ContextPropertyAnalyzer[] Properties { get; }

		public ContextDelegationPropertyAnalyzer(string contextTypeName, string propertyName, ContextPropertyAnalyzer[] properties)
		{
			ContextTypeName = contextTypeName;
			PropertyName = propertyName;
			Properties = properties;
		}

		public string GetPropertyName() => PropertyName;

		public static ContextDelegationPropertyAnalyzer? FromMethod(PhaseMethodSyntax method, PhaseGroupSyntax phaseGroup)
		{
			var dictionary = phaseGroup.Methods.ToDictionary(x => x.MethodName, x => x);
			var properties = new List<ContextPropertyAnalyzer>();

			var delegatedContext = method.ContextParameter;
			if (delegatedContext is null)
			{
				return null;
			}

			var currentContextParameter = method.ContextParameter;
			while (!(currentContextParameter is null))
			{
				var methodName = Naming.PhaseMethodNameFromContextType(currentContextParameter.TypeName.Name);
				var dependencyMethod = dictionary[methodName];

				properties.AddRange(ContextPropertyAnalyzer.FromMethod(dependencyMethod));

				currentContextParameter = dependencyMethod.ContextParameter;
			}

			return new ContextDelegationPropertyAnalyzer(
				delegatedContext.TypeName.Name,
				delegatedContext.Name.ToUpperCamelCase(),
				properties.ToArray());
		}
	}
}