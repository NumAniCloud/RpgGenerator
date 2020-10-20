using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class PassiveProcessHookHandler
	{
		private readonly BattleContext _context;

		public PassiveProcessHookHandler(BattleContext context)
		{
			_context = context;
		}

		public Task BeforeEventAsync(IBattleEvent @event)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectLeadingTask(p, @event));
		}

		public Task AfterEventAsync(IBattleEvent @event)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectFollowingTask(p, @event));
		}

		private async Task RunAsync(IPassiveProcessProvider provider, Func<PassiveProcess, Task> selector)
		{
			foreach (var process in provider.GetPassiveProcesses())
			{
				await selector(process);
			}
		}

		private Task SelectLeadingTask(PassiveProcess passive, IBattleEvent @event)
			=> @event switch
			{
				DamageEvent ev0 => passive.BeforeEventAsync(ev0, _context),
				_ => Task.CompletedTask
			};

		private Task SelectFollowingTask(PassiveProcess passive, IBattleEvent @event)
			=> @event switch
			{
				DamageEvent ev0 => passive.AfterEventAsync(ev0, _context),
				_ => Task.CompletedTask,
			};
	}
}
