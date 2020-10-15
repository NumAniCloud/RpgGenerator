using System.Linq;
using RpgGenerator.Syntax;

namespace RpgGenerator.Generation.Analyzer
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
