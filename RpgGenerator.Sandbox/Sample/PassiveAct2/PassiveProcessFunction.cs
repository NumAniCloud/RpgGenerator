using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IPassiveProcessFunction<TPassive, in TDomain>
	{
		Task RunAsync(IBattleEvent<TPassive> @event, TDomain context);
	}

	class PassiveProcessFunction<TPassive, TEvent, TDomain> : IPassiveProcessFunction<TPassive, TDomain>
		where TEvent : IBattleEvent<TPassive>
	{
		private readonly Func<TEvent, TDomain, Task> _processFunc;

		public PassiveProcessFunction(Func<TEvent, TDomain, Task> processFunc)
		{
			_processFunc = processFunc;
		}

		public async Task RunAsync(IBattleEvent<TPassive> @event, TDomain context)
		{
			if (@event is TEvent ev)
			{
				await _processFunc.Invoke(ev, context);
			}
		}
	}
}
