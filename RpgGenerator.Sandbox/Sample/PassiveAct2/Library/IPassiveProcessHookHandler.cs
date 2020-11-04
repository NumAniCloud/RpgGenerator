using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IPassiveProcessHookHandler<TDomain>
	{
		Task BeforeEventAsync(IBattleEvent<TDomain> @event);
		Task AfterEventAsync(IBattleEvent<TDomain> @event);
	}
}
