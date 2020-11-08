using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Modifier
{
	
	public delegate TData PassiveProcessModifier<TDomain, TData, TDataStore>(TData source,
		PassiveProperty<TDomain, TDataStore> self);

	public class PassiveModifier<TDomain, TData, TDataStore> : IPassiveModifier<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData, TDataStore> _selector;

		public PassiveModifier(PassiveProcessModifier<TDomain, TData, TDataStore> selector)
		{
			_selector = selector;
		}

		public TSource Modify<TSource>(TSource source, IPassiveProperty<TDomain> self)
		{
			if (_selector is PassiveProcessModifier<TDomain, TSource, TDataStore> modifier
				&& self is PassiveProperty<TDomain, TDataStore> stateful)
			{
				return modifier.Invoke(source, stateful);
			}

			return source;
		}
	}
}