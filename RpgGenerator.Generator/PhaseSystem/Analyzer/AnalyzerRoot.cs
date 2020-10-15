using System.Linq;
using RpgGenerator.Generator.PhaseSystem.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Analyzer
{
	public class AnalyzerRoot
	{
		public TypeName DefinitionTypeName { get; }
		public string PhaseGroupName { get; }
		public PhaseHandlerAnalyzer PhaseHandler { get; }
		public PhaseLogicAnalyzer PhaseLogic { get; }
		public ContextTypeAnalyzer[] ContextTypes { get; }

		public AnalyzerRoot(TypeName definitionTypeName,
			string phaseGroupName,
			PhaseHandlerAnalyzer phaseHandler,
			PhaseLogicAnalyzer phaseLogic,
			ContextTypeAnalyzer[] contextTypes)
		{
			DefinitionTypeName = definitionTypeName;
			PhaseGroupName = phaseGroupName;
			PhaseHandler = phaseHandler;
			PhaseLogic = phaseLogic;
			ContextTypes = contextTypes;
		}

		public static AnalyzerRoot FromPhaseGroup(PhaseGroupSyntax phaseGroup)
		{
			return new AnalyzerRoot(phaseGroup.InterfaceName,
				phaseGroup.InterfaceName.ToNonInterfaceName(),
				PhaseHandlerAnalyzer.FromPhaseGroup(phaseGroup),
				PhaseLogicAnalyzer.FromPhaseGroup(phaseGroup),
				ContextTypeAnalyzer.FromPhaseGroup(phaseGroup).ToArray());
		}
	}
}
