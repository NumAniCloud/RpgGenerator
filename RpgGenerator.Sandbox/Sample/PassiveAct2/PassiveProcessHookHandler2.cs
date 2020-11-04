using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class PassiveProcessHookHandler2<TDomain> : IPassiveProcessHookHandler<TDomain>
	{
		private readonly TDomain _context;

		public PassiveProcessHookHandler2(TDomain context)
		{
			_context = context;
		}

		public Task BeforeEventAsync(IBattleEvent<TDomain> @event)
			=> RunAsync(@event, p => p.LeadingProcesses);

		public Task AfterEventAsync(IBattleEvent<TDomain> @event)
			=> RunAsync(@event, p => p.FollowingProcesses);

		private async Task RunAsync(IBattleEvent<TDomain> @event,
			Func<PassiveProcess<TDomain>, IEnumerable<IPassiveProcessFunction<TDomain>>> getFunctions)
		{
			foreach (var passive in @event.PassiveProcessSubject)
			{
				foreach (var process in getFunctions.Invoke(passive))
				{
					await process.RunAsync(@event, _context);
				}
			}
		}
	}
}
