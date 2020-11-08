using System;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class PassiveProcessHookHandler<TDomain> : IPassiveProcessHookHandler<TDomain>
	{
		private readonly TDomain _context;

		public PassiveProcessHookHandler(TDomain context)
		{
			_context = context;
		}

		public Task BeforeEventAsync(IBattleEvent<TDomain> @event)
			=> RunAsync(@event, p => p.RunLeadingProcessAsync(@event, _context));

		public Task AfterEventAsync(IBattleEvent<TDomain> @event)
			=> RunAsync(@event, p => p.RunFollowingProcessAsync(@event, _context));

		private async Task RunAsync(IBattleEvent<TDomain> @event, 
			Func<IPassiveProperty<TDomain>, Task> runner)
		{
			foreach (var property in @event.PassiveProcessSubject)
			{
				await runner.Invoke(property);
			}
		}
	}
}
