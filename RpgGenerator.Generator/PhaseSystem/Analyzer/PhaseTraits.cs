using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class PhaseTraits
	{
		public string PhaseName { get; }
		public ParameterAnalyzer[] Parameters { get; }
		public ResultTypeAnalyzer ResultType { get; }
		public string HandlerMethodName => $"Handle{PhaseName}Async";
		public string LogicMethodName => $"Do{PhaseName}Async";
		public string ContextTypeName => $"{PhaseName}Phase";

		public PhaseTraits(
			string phaseName,
			ParameterAnalyzer[] parameters,
			ResultTypeAnalyzer resultType)
		{
			PhaseName = phaseName;
			Parameters = parameters;
			ResultType = resultType;
		}

		public static PhaseTraits FromPhaseMethod(PhaseMethodSyntax method)
		{
			return new PhaseTraits(method.MethodName,
				ParameterAnalyzer.FromMethod(method).ToArray(),
				ResultTypeAnalyzer.FromSyntax(method.ResultType));
		}
	}
}
