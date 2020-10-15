using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	interface IBattleEvent
	{
		Task RunAsync(IBattleEventHandler handler);
	}
}
