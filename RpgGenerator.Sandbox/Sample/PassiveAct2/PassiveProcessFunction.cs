using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, TDomain context);
	}

	sealed class PassiveProcessFunction<TEvent, TDomain> : IPassiveProcessFunction<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly Func<TEvent, TDomain, Task> _processFunc;

		public PassiveProcessFunction(Func<TEvent, TDomain, Task> processFunc)
		{
			_processFunc = processFunc;
		}

		public async Task RunAsync(IBattleEvent<TDomain> @event, TDomain context)
		{
			if (@event is TEvent ev)
			{
				await _processFunc.Invoke(ev, context);
			}
		}
	}
}
