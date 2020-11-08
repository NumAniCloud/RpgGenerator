using System;
using System.Collections.Generic;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public abstract class StatefulPassiveProcess<TDomain, TDataStore> : IPassiveProcess<TDomain>
	{
		public abstract TDataStore InitialValue { get; }
		
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
					var aggregator = new ModifierAggregatorWithState();
					RegisterModifiers(aggregator);
					_modifiers = aggregator.Modifiers.ToArray();
				}

				return _modifiers;
			}
		}

		private IEnumerable<IPassiveProcessFunction<TDomain>> GetFunctions(
			ref IPassiveProcessFunction<TDomain>[]? functions,
			Action<FuncAggregatorWithState> registration)
		{
			if (functions is null)
			{
				var aggregator = new FuncAggregatorWithState();
				registration.Invoke(aggregator);
				functions = aggregator.Functions.ToArray();
			}

			return functions;
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
				Functions.Add(new StatefulPassiveProcessFunction<TEvent,TDomain, TDataStore>(processFunc));
			}
		}

		protected sealed class ModifierAggregatorWithState
		{
			public List<IPassiveModifierFunction<TDomain>> Modifiers { get; } = new List<IPassiveModifierFunction<TDomain>>();

			public void Register<TData>(PassiveProcessModifier<TDomain, TData, TDataStore> modifier)
			{
				Modifiers.Add(new StatefulPassiveModifierFunction<TDomain, TData, TDataStore>(modifier));
			}
		}
	}
}
