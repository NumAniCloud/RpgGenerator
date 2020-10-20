using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class PassiveProcessHookHandler
	{
		public Task BeforeEventAsync(IBattleEvent @event, BattleContext context)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectLeadingTask(p, @event, context));
		}

		public Task AfterEventAsync(IBattleEvent @event, BattleContext context)
		{
			return RunAsync(@event.PassiveProcessSubject, p => SelectFollowingTask(p, @event, context));
		}

		private async Task RunAsync(IPassiveProcessProvider provider, Func<PassiveProcess, Task> selector)
		{
			foreach (var process in provider.GetPassiveProcesses())
			{
				await selector(process);
			}
		}

		private Task SelectLeadingTask(PassiveProcess passive, IBattleEvent @event, BattleContext context)
			=> @event switch
			{
				DamageEvent ev0 => passive.BeforeEventAsync(ev0, context),
				_ => Task.CompletedTask
			};

		private Task SelectFollowingTask(PassiveProcess passive, IBattleEvent @event, BattleContext context)
			=> @event switch
			{
				DamageEvent ev0 => passive.AfterEventAsync(ev0, context),
				_ => Task.CompletedTask,
			};
	}
}
