using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public class BattleEventHandler<TPassive>
	{
		private readonly IPassiveProcessHookHandler<TPassive> _passiveHook;

		public BattleEventHandler(IPassiveProcessHookHandler<TPassive> passiveHook)
		{
			_passiveHook = passiveHook;
		}

		public async Task HandleAsync(IBattleEvent<TPassive> @event)
		{
			await _passiveHook.BeforeEventAsync(@event);
			await @event.RunAsync(this);
			await _passiveHook.AfterEventAsync(@event);
		}
	}
}
