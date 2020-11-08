using System.Collections.Generic;
using RpgGenerator.Basic.Passive.PassiveModifierFunction;
using RpgGenerator.Basic.Passive.PassiveProcessFunction;

namespace RpgGenerator.Basic.Passive.PassiveProcess
{
	public abstract class PassiveProcess<TDomain, TDataStore> : PassiveProcessBase<TDomain>
	{
		public abstract TDataStore InitialValue { get; }
		
		protected sealed override IPassiveProcessFunction<TDomain>[] LoadLeadingProcesses()
		{
			var aggregator = new FuncAggregatorWithState();
			RegisterLeadingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveProcessFunction<TDomain>[] LoadFollowingProcesses()
		{
			var aggregator = new FuncAggregatorWithState();
			RegisterFollowingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveModifierFunction<TDomain>[] LoadModifiers()
		{
			var aggregator = new ModifierAggregatorWithState();
			RegisterModifiers(aggregator);
			return aggregator.Modifiers.ToArray();
		}

		protected virtual void RegisterLeadingFunctions(FuncAggregatorWithState aggregator)
		{
		}

		protected virtual void RegisterFollowingFunctions(FuncAggregatorWithState aggregator)
		{
		}

		protected virtual void RegisterModifiers(ModifierAggregatorWithState aggregator)
		{
		}

		protected sealed class FuncAggregatorWithState
		{
			public List<IPassiveProcessFunction<TDomain>> Functions { get; } = new List<IPassiveProcessFunction<TDomain>>();

			public void Register<TEvent>(PassiveProcessHook<TEvent, TDomain, TDataStore> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				Functions.Add(new PassiveProcessFunction<TEvent,TDomain, TDataStore>(processFunc));
			}
		}

		protected sealed class ModifierAggregatorWithState
		{
			public List<IPassiveModifierFunction<TDomain>> Modifiers { get; } = new List<IPassiveModifierFunction<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData, TDataStore> modifier)
			{
				Modifiers.Add(new PassiveModifierFunction<TDomain, TData, TDataStore>(modifier));
			}
		}
	}
}
