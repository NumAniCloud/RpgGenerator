using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class ContextTypeAnalyzer
	{
		private readonly PhaseTraits _traits;
		public string TypeName => _traits.ContextTypeName;
		public ContextPropertyAnalyzer[] ContextProperties { get; }
		public ContextDelegationPropertyAnalyzer? ContextDelegationProperties { get; }

		public ContextTypeAnalyzer(PhaseTraits traits,
			ContextPropertyAnalyzer[] contextProperties,
			ContextDelegationPropertyAnalyzer? contextDelegationProperties)
		{
			_traits = traits;
			ContextProperties = contextProperties;
			ContextDelegationProperties = contextDelegationProperties;
		}

		public string GetCtorParamList()
		{
			var contextParam = ContextDelegationProperties.AsEnumerable()
				.Select(x => $"{x.ContextTypeName} {x.ParameterName}");
			var additionalParams = ContextProperties.Select(x => $"{x.Type.Name} {x.PropertyName.ToLowerCamelCase()}");
			return contextParam.Concat(additionalParams).Join(", ");
		}

		public static IEnumerable<ContextTypeAnalyzer> FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			foreach (var method in phaseGroup.Methods)
			{
				yield return new ContextTypeAnalyzer(PhaseTraits.FromPhaseMethod(method), 
					ContextPropertyAnalyzer.FromMethod(method).ToArray(),
					ContextDelegationPropertyAnalyzer.FromMethod(method, phaseGroup));
			}
		}
	}
}