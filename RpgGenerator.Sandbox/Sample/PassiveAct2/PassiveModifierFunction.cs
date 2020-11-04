namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	delegate TData PassiveProcessModifier<TDomain, TData>(TData source, PassiveProperty<TDomain> self);

	interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, PassiveProperty<TDomain> self);
	}

	class PassiveModifierFunction<TDomain, TData> : IPassiveModifierFunction<TDomain>
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
}
