using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class PhaseLogicMethodAnalyzer
	{
		private readonly PhaseTraits _traits;
		public string Name => _traits.LogicMethodName;
		public string ContextTypeName => _traits.ContextTypeName;
		public string HandlerTypeName => _traits.HandlerMethodName;
		public string ResultTypeName => _traits.ResultType.TypeName.Name;

		public PhaseLogicMethodAnalyzer(PhaseTraits traits)
		{
			_traits = traits;
		}

		public static IEnumerable<PhaseLogicMethodAnalyzer> FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			return phaseGroup.Methods
				.Select(method => new PhaseLogicMethodAnalyzer(PhaseTraits.FromPhaseMethod(method)));
		}
	}
}