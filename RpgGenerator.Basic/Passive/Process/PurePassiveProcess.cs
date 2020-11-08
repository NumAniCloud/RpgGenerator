using System.Collections.Generic;
using RpgGenerator.Basic.Passive.Event;
using RpgGenerator.Basic.Passive.Hooker;
using RpgGenerator.Basic.Passive.Modifier;

namespace RpgGenerator.Basic.Passive.Process
{
	public abstract class PurePassiveProcess<TDomain> : PassiveProcessBase<TDomain>
	{
		protected sealed override IPassiveHooker<TDomain>[] LoadLeadingProcesses()
		{
			var aggregator = new FuncAggregator();
			RegisterLeadingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveHooker<TDomain>[] LoadFollowingProcesses()
		{
			var aggregator = new FuncAggregator();
			RegisterFollowingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveModifier<TDomain>[] LoadModifiers()
		{
			var aggregator = new ModifierAggregator();
			RegisterModifiers(aggregator);
			return aggregator.Modifiers.ToArray();
		}

		protected virtual void RegisterLeadingFunctions(FuncAggregator aggregator)
		{
		}

		protected virtual void RegisterFollowingFunctions(FuncAggregator aggregator)
		{
		}

		protected virtual void RegisterModifiers(ModifierAggregator aggregator)
		{
		}

		protected sealed class FuncAggregator
		{
			public List<IPassiveHooker<TDomain>> Functions { get; } = new List<IPassiveHooker<TDomain>>();

			public void Register<TEvent>(PassiveProcessHook<TEvent, TDomain> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				Functions.Add(new PurePassiveHooker<TEvent, TDomain>(processFunc));
			}
		}

		protected sealed class ModifierAggregator
		{
			public List<IPassiveModifier<TDomain>> Modifiers { get; } = new List<IPassiveModifier<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData> modifier)
			{
				Modifiers.Add(new PurePassiveModifier<TDomain, TData>(modifier));
			}
		}
	}
}
