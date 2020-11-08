using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive
{
	static class PassiveHelper
	{
		public static BattleEventHandler<TDomain> CreateBattleEventHandler<TDomain>(TDomain domain)
		{
			return new BattleEventHandler<TDomain>(new PassiveProcessHookHandler<TDomain>(domain));
		}

		public static TData Modify<TDomain, TData>(
			this IEnumerable<IPassiveProperty<TDomain>> passiveProperties,
			TData source)
		{
			return passiveProperties.Aggregate(source, (data, property) => property.Modify(source));
		}
	}
}
