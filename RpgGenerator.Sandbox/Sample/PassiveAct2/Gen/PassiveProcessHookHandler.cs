using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class PassiveProcessHookHandler : IPassiveProcessHookHandler<PassiveProcess>
	{
		private readonly BattleContext _context;

		public PassiveProcessHookHandler(BattleContext context)
		{
			_context = context;
		}

		public Task BeforeEventAsync(IBattleEvent<PassiveProcess> @event)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectLeadingTask(p, @event));
		}

		public Task AfterEventAsync(IBattleEvent<PassiveProcess> @event)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectFollowingTask(p, @event));
		}

		private async Task RunAsync(IEnumerable<PassiveProcess> provider, Func<PassiveProcess, Task> selector)
		{
			foreach (var process in provider)
			{
				await selector(process);
			}
		}

		private Task SelectLeadingTask(PassiveProcess passive, IBattleEvent<PassiveProcess> @event)
			=> @event switch
			{
				DamageEvent ev0 => passive.BeforeEventAsync(ev0, _context),
				_ => Task.CompletedTask
			};

		private Task SelectFollowingTask(PassiveProcess passive, IBattleEvent<PassiveProcess> @event)
			=> @event switch
			{
				DamageEvent ev0 => passive.AfterEventAsync(ev0, _context),
				_ => Task.CompletedTask,
			};
	}
}
