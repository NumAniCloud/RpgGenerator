using System.Threading.Tasks;
using RpgGenerator.Basic;

namespace RpgGenerator.Sandbox.Sample.Passive
{
	interface IPassiveEventHook
	{
		Task BeforeEventAsync(IPassiveDecorationProviderBase passive, IBattleEvent @event);
		Task AfterEventAsync(IPassiveDecorationProviderBase passive, IBattleEvent @event);
	}
}
