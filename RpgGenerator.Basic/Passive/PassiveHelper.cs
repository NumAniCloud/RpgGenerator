using System.Collections.Generic;
using System.Linq;
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
	}
}
