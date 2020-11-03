using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class BattleEventHandler<TPassive>
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
