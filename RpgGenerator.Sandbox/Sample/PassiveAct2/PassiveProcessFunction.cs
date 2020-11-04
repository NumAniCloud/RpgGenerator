using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	delegate Task PassiveProcessHook<in TEvent, TDomain>(TEvent @event, PassiveProperty<TDomain> self, TDomain domain);

	interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, PassiveProperty<TDomain> self, TDomain context);
	}

	sealed class PassiveProcessFunction<TEvent, TDomain> : IPassiveProcessFunction<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly PassiveProcessHook<TEvent, TDomain> _processFunc;

		public PassiveProcessFunction(PassiveProcessHook<TEvent, TDomain> processFunc)
		{
			_processFunc = processFunc;
		}

		public async Task RunAsync(IBattleEvent<TDomain> @event,
			PassiveProperty<TDomain> self,
			TDomain context)
		{
			if (@event is TEvent ev)
			{
				await _processFunc.Invoke(ev, self, context);
			}
		}
	}
}
