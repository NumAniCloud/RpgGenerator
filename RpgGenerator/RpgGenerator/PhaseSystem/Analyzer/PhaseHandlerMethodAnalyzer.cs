using System.Collections.Generic;
using System.Linq;
using Deptorygen.Utilities;
using RpgGenerator.Syntax;
using RpgGenerator.Utilities;

namespace RpgGenerator.Generation.Analyzer
{
	public class PhaseHandlerMethodAnalyzer
	{
		private readonly PhaseTraits _traits;

		public string Name => _traits.PhaseName;
		public ResultTypeAnalyzer ResultType => _traits.ResultType;
		public string LogicMethodName => _traits.LogicMethodName;

		public PhaseHandlerMethodAnalyzer(PhaseTraits traits)
		{
			this._traits = traits;
		}

		public string GetContextTypeName() => _traits.ContextTypeName;

		public string GetParamList()
		{
			return _traits.Parameters.Select(x => $"{x.TypeName.Name} {x.Name}").Join(", ");
		}

		public string GetContextArgList() => _traits.Parameters.Select(x => x.Name).Join(", ");


		public static IEnumerable<PhaseHandlerMethodAnalyzer> FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			return phaseGroup.Methods
				.Select(method => new PhaseHandlerMethodAnalyzer(PhaseTraits.FromPhaseMethod(method)));
		}
	}
}