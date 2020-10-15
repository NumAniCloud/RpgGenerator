using System.Threading.Tasks;
using RpgGenerator.Annotations;

namespace RpgGenerator.Test.DataSource.RpgGeneratorUnitTests.Basic
{
	[PhasesAttribute]
	interface IBattlePhases
	{
		Task<PhaseResult<string>> Phase1(int x, int y);
		Task<PhaseResult<string>> Phase2([PhaseContextAttribute]Phase1Phase context, int z);
	}
}
