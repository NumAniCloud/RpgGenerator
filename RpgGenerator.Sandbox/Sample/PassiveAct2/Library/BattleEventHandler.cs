using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class BattleEventHandler<TDomain>
	{
		private readonly IPassiveProcessHookHandler<TDomain> _passiveHook;

		public BattleEventHandler(IPassiveProcessHookHandler<TDomain> passiveHook)
		{
			_passiveHook = passiveHook;
		}

		public async Task HandleAsync(IBattleEvent<TDomain> @event)
		{
			await _passiveHook.BeforeEventAsync(@event);
			await @event.RunAsync(this);
			await _passiveHook.AfterEventAsync(@event);
		}
	}
}
