﻿using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction
{
	
	public delegate TData PassiveProcessModifier<TDomain, TData, TDataStore>(TData source,
		PassiveProperty<TDomain, TDataStore> self);

	public class PassiveModifierFunction<TDomain, TData, TDataStore> : IPassiveModifierFunction<TDomain>
	{
		private readonly PassiveProcessModifier<TDomain, TData, TDataStore> _selector;

		public PassiveModifierFunction(PassiveProcessModifier<TDomain, TData, TDataStore> selector)
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