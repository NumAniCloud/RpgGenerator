using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction
{
	
	public delegate TData PassiveProcessModifier<TDomain, TData, TDataStore>(TData source,
		StatefulPurePassiveProperty<TDomain, TDataStore> self);

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