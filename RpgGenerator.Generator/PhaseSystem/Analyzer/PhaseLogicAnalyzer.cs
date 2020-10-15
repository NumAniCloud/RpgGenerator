using System.Linq;
using RpgGenerator.Syntax;

namespace RpgGenerator.Generation.Analyzer
{
	public class PhaseLogicAnalyzer
	{
		public string TypeName { get; }
		public PhaseLogicMethodAnalyzer[] PhaseLogicMethods { get; }

		public PhaseLogicAnalyzer(string typeName,
			PhaseLogicMethodAnalyzer[] phaseLogicMethods)
		{
			TypeName = typeName;
			PhaseLogicMethods = phaseLogicMethods;
		}

		public static PhaseLogicAnalyzer FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			return new PhaseLogicAnalyzer(phaseGroup.InterfaceName.Name + "Logic",
				PhaseLogicMethodAnalyzer.FromPhaseGroup(phaseGroup).ToArray());
		}
	}
}