using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.BattleEvent;

namespace RpgGenerator.Sandbox.Sample.Passive
{
	interface IPassiveEventHook
	{
		Task BeforeEventAsync(IPassiveEventProvider passive, IBattleEvent @event);
		Task AfterEventAsync(IPassiveEventProvider passive, IBattleEvent @event);
	}
}
