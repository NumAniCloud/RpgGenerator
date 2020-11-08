using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcess;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcessFunction;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public abstract class PurePassiveProcess<TDomain> : PassiveProcessBase<TDomain>
	{
		protected sealed override IPassiveProcessFunction<TDomain>[] LoadLeadingProcesses()
		{
			var aggregator = new FuncAggregator();
			RegisterLeadingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveProcessFunction<TDomain>[] LoadFollowingProcesses()
		{
			var aggregator = new FuncAggregator();
			RegisterFollowingFunctions(aggregator);
			return aggregator.Functions.ToArray();
		}

		protected sealed override IPassiveModifierFunction<TDomain>[] LoadModifiers()
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
			public List<IPassiveProcessFunction<TDomain>> Functions { get; } = new List<IPassiveProcessFunction<TDomain>>();

			public void Register<TEvent>(PassiveProcessHook<TEvent, TDomain> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				Functions.Add(new PurePassiveProcessFunction<TEvent, TDomain>(processFunc));
			}
		}

		protected sealed class ModifierAggregator
		{
			public List<IPassiveModifierFunction<TDomain>> Modifiers { get; } = new List<IPassiveModifierFunction<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData> modifier)
			{
				Modifiers.Add(new PurePassiveModifierFunction<TDomain, TData>(modifier));
			}
		}
	}
}
