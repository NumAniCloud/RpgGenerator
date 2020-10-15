using System.Threading.Tasks;
using RpgGenerator.Basic;

namespace RpgGenerator.Sandbox.Gen
{
	[Phases]
	interface IBattlePhases
	{
		Task<PhaseResult<string>> SkillSelection(int actorId);
		Task<PhaseResult<string>> TargetSelection([PhaseContext]SkillSelectionPhase phase, int skillId);
	}
}
