using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class BattleEventHandler
	{
		private readonly BattleContext _context;
		private readonly PassiveProcessHookHandler _passiveHook = new PassiveProcessHookHandler();

		public BattleEventHandler(BattleContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(IBattleEvent @event)
		{
			await _passiveHook.BeforeEventAsync(@event, _context);
			await @event.RunAsync(this);
			await _passiveHook.AfterEventAsync(@event, _context);
		}
	}
}
