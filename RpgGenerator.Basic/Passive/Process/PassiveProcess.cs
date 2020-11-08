using System.Collections.Generic;
using RpgGenerator.Basic.Passive.Event;
using RpgGenerator.Basic.Passive.Hooker;
using RpgGenerator.Basic.Passive.Modifier;

namespace RpgGenerator.Basic.Passive.Process
{
	public abstract class PassiveProcess<TDomain, TDataStore> : PassiveProcessBase<TDomain>
	{
		public abstract TDataStore InitialValue { get; }
		
		protected sealed override IPassiveHooker<TDomain>[] LoadLeadingProcesses()
		{
			var aggregator = new FuncAggregatorWithState();
			RegisterLeadingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveHooker<TDomain>[] LoadFollowingProcesses()
		{
			var aggregator = new FuncAggregatorWithState();
			RegisterFollowingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveModifier<TDomain>[] LoadModifiers()
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
			public List<IPassiveHooker<TDomain>> Functions { get; } = new List<IPassiveHooker<TDomain>>();

			public void Register<TEvent>(PassiveProcessHook<TEvent, TDomain, TDataStore> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				Functions.Add(new PassiveHooker<TEvent,TDomain, TDataStore>(processFunc));
			}
		}

		protected sealed class ModifierAggregatorWithState
		{
			public List<IPassiveModifier<TDomain>> Modifiers { get; } = new List<IPassiveModifier<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData, TDataStore> modifier)
			{
				Modifiers.Add(new PassiveModifier<TDomain, TData, TDataStore>(modifier));
			}
		}
	}
}
