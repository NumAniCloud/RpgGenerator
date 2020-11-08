using System;
using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Event
{
	public class BattleEventHandler<TDomain>
	{
		private readonly TDomain _domain;

		public BattleEventHandler(TDomain domain)
		{
			_domain = domain;
		}

		public async Task HandleAsync(IBattleEvent<TDomain> @event)
		{
			await RunAsync(@event, p => p.RunLeadingProcessAsync(@event, _domain));
			await @event.RunAsync(this);
			await RunAsync(@event, p => p.RunFollowingProcessAsync(@event, _domain));
		}

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
