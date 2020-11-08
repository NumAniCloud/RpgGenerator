using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Basic.Passive.Process;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive
{
	public static class PassiveHelper
	{
		public static TData Modify<TDomain, TData>(
			this IEnumerable<IPassiveProperty<TDomain>> passiveProperties,
			TData source)
		{
			return passiveProperties.Aggregate(source, (data, property) => property.Modify(source));
		}

		public static PurePassiveProperty<TDomain> WrapInProperty<TDomain>(this PurePassiveProcess<TDomain> passive)
		{
			return new PurePassiveProperty<TDomain>(passive);
		}

		public static PassiveProperty<TDomain, TDataStore> WrapInProperty<TDomain, TDataStore>(
			this PassiveProcess<TDomain, TDataStore> passive)
		{
			return new PassiveProperty<TDomain, TDataStore>(passive);
		}
	}
}
