using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive.PassiveModifierFunction
{
	public delegate TData PassiveProcessModifier<TDomain, TData>(TData source, IPassiveProperty<TDomain> self);

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
}
