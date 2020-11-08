using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	public delegate Task PassiveProcessHook<in TEvent, TDomain>(TEvent @event, PassiveProperty<TDomain> self, TDomain domain);
	public delegate Task PassiveProcessHook<in TEvent, TDomain, TDataStore>(TEvent @event,
		StatefulPassiveProperty<TDomain, TDataStore> self,
		TDomain domain);

	public interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, PassiveProperty<TDomain> self, TDomain context);
	}

	public sealed class PassiveProcessFunction<TEvent, TDomain> : IPassiveProcessFunction<TDomain>
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

	public sealed class StatefulPassiveProcessFunction<TEvent, TDomain, TDataStore>
		: IPassiveProcessFunction<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly PassiveProcessHook<TEvent, TDomain, TDataStore> _processHook;

		public StatefulPassiveProcessFunction(PassiveProcessHook<TEvent, TDomain, TDataStore> processHook)
		{
			_processHook = processHook;
		}

		public async Task RunAsync(IBattleEvent<TDomain> @event, PassiveProperty<TDomain> self, TDomain context)
		{
			if (@event is TEvent ev && self is StatefulPassiveProperty<TDomain, TDataStore> property)
			{
				await _processHook.Invoke(ev, property, context);
			}
		}
	}
}
