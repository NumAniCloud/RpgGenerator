using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Modifier
{
	public delegate TData PassiveProcessModifier<TDomain, TData>(TData source, IPassiveProperty<TDomain> self);

	public class PurePassiveModifier<TDomain, TData> : IPassiveModifier<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData> _selector;

		public PurePassiveModifier(PassiveProcessModifier<TDomain, TData> selector)
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
