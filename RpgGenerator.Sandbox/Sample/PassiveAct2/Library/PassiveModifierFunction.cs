namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	public delegate TData PassiveProcessModifier<TDomain, TData>(TData source, PassiveProperty<TDomain> self);
	public delegate TData PassiveProcessModifier<TDomain, TData, TDataStore>(TData source,
		StatefulPassiveProperty<TDomain, TDataStore> self);

	public interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, PassiveProperty<TDomain> self);
	}

	public class PassiveModifierFunction<TDomain, TData> : IPassiveModifierFunction<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData> _selector;

		public PassiveModifierFunction(PassiveProcessModifier<TDomain, TData> selector)
		{
			_selector = selector;
		}

		public TSource Modify<TSource>(TSource source, PassiveProperty<TDomain> self)
		{
			if (source is TData data
				&& _selector.Invoke(data, self) is TSource result)
			{
				return result;
			}

			return source;
		}
	}

	public class StatefulPassiveModifierFunction<TDomain, TData, TDataStore> : IPassiveModifierFunction<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData, TDataStore> _selector;

		public StatefulPassiveModifierFunction(PassiveProcessModifier<TDomain, TData, TDataStore> selector)
		{
			_selector = selector;
		}

		public TSource Modify<TSource>(TSource source, PassiveProperty<TDomain> self)
		{
			if (_selector is PassiveProcessModifier<TDomain, TSource, TDataStore> modifier
				&& self is StatefulPassiveProperty<TDomain, TDataStore> stateful)
			{
				return modifier.Invoke(source, stateful);
			}

			return source;
		}
	}
}
