namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public delegate TData PassiveProcessModifier<TDomain, TData>(TData source, IPassiveProperty<TDomain> self);
	public delegate TData PassiveProcessModifier<TDomain, TData, TDataStore>(TData source,
		StatefulPurePassiveProperty<TDomain, TDataStore> self);

	public interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, IPassiveProperty<TDomain> self);
	}

	public class PurePassiveModifierFunction<TDomain, TData> : IPassiveModifierFunction<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData> _selector;

		public PurePassiveModifierFunction(PassiveProcessModifier<TDomain, TData> selector)
		{
			_selector = selector;
		}

		public TSource Modify<TSource>(TSource source, IPassiveProperty<TDomain> self)
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

		public TSource Modify<TSource>(TSource source, IPassiveProperty<TDomain> self)
		{
			if (_selector is PassiveProcessModifier<TDomain, TSource, TDataStore> modifier
				&& self is StatefulPurePassiveProperty<TDomain, TDataStore> stateful)
			{
				return modifier.Invoke(source, stateful);
			}

			return source;
		}
	}
}
