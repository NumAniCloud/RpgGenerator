namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public abstract class StatefulPassiveProcess<TDomain, TDataStore> : PassiveProcess<TDomain>
	{
		public abstract TDataStore InitialValue { get; }

		protected sealed override void RegisterLeadingFunctions(FuncAggregator aggregator)
		{
			RegisterLeadingFunctionsWithState(new FuncAggregatorWithState(aggregator));
		}

		protected sealed override void RegisterFollowingFunctions(FuncAggregator aggregator)
		{
			RegisterFollowingFunctionsWithState(new FuncAggregatorWithState(aggregator));
		}

		protected sealed override void RegisterModifiers(ModifierAggregator aggregator)
		{
			RegisterModifiersWithState(new ModifierAggregatorWithState(aggregator));
		}


		protected virtual void RegisterLeadingFunctionsWithState(FuncAggregatorWithState aggregator)
		{
		}

		protected virtual void RegisterFollowingFunctionsWithState(FuncAggregatorWithState aggregator)
		{
		}

		protected virtual void RegisterModifiersWithState(ModifierAggregatorWithState aggregator)
		{
		}

		protected sealed class FuncAggregatorWithState
		{
			private readonly FuncAggregator _baseAggregator;

			public FuncAggregatorWithState(FuncAggregator baseAggregator)
			{
				_baseAggregator = baseAggregator;
			}

			public void Register<TEvent>(PassiveProcessHook<TEvent, TDomain, TDataStore> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				_baseAggregator.Functions.Add(
					new StatefulPassiveProcessFunction<TEvent,TDomain, TDataStore>(processFunc));
			}
		}

		protected sealed class ModifierAggregatorWithState
		{
			private readonly ModifierAggregator _baseAggregator;

			public ModifierAggregatorWithState(ModifierAggregator baseAggregator)
			{
				_baseAggregator = baseAggregator;
			}

			public void Register<TData>(PassiveProcessModifier<TDomain, TData, TDataStore> modifier)
			{
				_baseAggregator.Modifiers.Add(
					new StatefulPassiveModifierFunction<TDomain, TData, TDataStore>(modifier));
			}
		}
	}
}
