using System.Threading.Tasks;
using RpgGenerator.Annotations;

namespace RpgGenerator.Sandbox
{
	interface IBattlePhases
	{
		Task<PhaseResult<string>> HandlePhase1Async(int x, int y);
		Task<PhaseResult<string>> HandlePhase2Async(PhaseContext1 context, int z);
	}
}
