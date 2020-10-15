using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
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