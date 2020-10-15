using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class PhaseHandlerAnalyzer
	{
		public string TypeName { get; }
		public PhaseHandlerMethodAnalyzer[] PhaseHandlerMethods { get; }

		public PhaseHandlerAnalyzer(string typeName,
			PhaseHandlerMethodAnalyzer[] phaseHandlerMethods)
		{
			TypeName = typeName;
			PhaseHandlerMethods = phaseHandlerMethods;
		}

		public static PhaseHandlerAnalyzer FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			return new PhaseHandlerAnalyzer(phaseGroup.InterfaceName.ToNonInterfaceName() + "Handler",
				PhaseHandlerMethodAnalyzer.FromPhaseGroup(phaseGroup).ToArray());
		}
	}
}