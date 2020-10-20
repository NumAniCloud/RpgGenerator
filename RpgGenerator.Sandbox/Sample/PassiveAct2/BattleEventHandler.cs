using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class BattleEventHandler
	{
		private readonly PassiveProcessHookHandler _passiveHook;

		public BattleEventHandler(PassiveProcessHookHandler passiveHook)
		{
			_passiveHook = passiveHook;
		}

		public async Task HandleAsync(IBattleEvent @event)
		{
			await _passiveHook.BeforeEventAsync(@event);
			await @event.RunAsync(this);
			await _passiveHook.AfterEventAsync(@event);
		}
	}
}
