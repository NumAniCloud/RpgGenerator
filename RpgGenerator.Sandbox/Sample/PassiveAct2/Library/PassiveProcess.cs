using System;
using System.Collections.Generic;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	abstract class PassiveProcess<TDomain>
	{
		private IPassiveProcessFunction<TDomain>[]? _leadingFunctions;
		private IPassiveProcessFunction<TDomain>[]? _followingFunctions;
		private IPassiveModifierFunction<TDomain>[]? _modifiers;

		public IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses => GetFunctions(ref _leadingFunctions, RegisterLeadingFunctions);
		public IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses => GetFunctions(ref _followingFunctions, RegisterFollowingFunctions);
		public IEnumerable<IPassiveModifierFunction<TDomain>> Modifiers
		{
			get
			{
				if (_modifiers is null)
				{
					var aggregator = new ModifierAggregator();
					RegisterModifiers(aggregator);
					_modifiers = aggregator.Modifiers.ToArray();
				}

				return _modifiers;
			}
		}

		private IEnumerable<IPassiveProcessFunction<TDomain>> GetFunctions(
			ref IPassiveProcessFunction<TDomain>[]? functions,
			Action<FuncAggregator> registration)
		{
			if (functions is null)
			{
				var aggregator = new FuncAggregator();
				registration.Invoke(aggregator);
				functions = aggregator.Functions.ToArray();
			}

			return functions;
		}

		public virtual void Populate(PassiveProperty<TDomain> self)
		{
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
				Functions.Add(new PassiveProcessFunction<TEvent, TDomain>(processFunc));
			}
		}

		protected sealed class ModifierAggregator
		{
			public List<IPassiveModifierFunction<TDomain>> Modifiers { get; } = new List<IPassiveModifierFunction<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData> modifier)
			{
				Modifiers.Add(new PassiveModifierFunction<TDomain, TData>(modifier));
			}
		}
	}
}
