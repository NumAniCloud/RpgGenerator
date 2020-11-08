using System.Collections.Generic;
using System.Linq;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	static class PassiveHelper
	{
		public static BattleEventHandler<TDomain> CreateBattleEventHandler<TDomain>(TDomain domain)
		{
			return new BattleEventHandler<TDomain>(new PassiveProcessHookHandler2<TDomain>(domain));
		}

		public static TData Modify<TDomain, TData>(
			this IEnumerable<PassiveProperty<TDomain>> passiveProperties,
			TData source)
		{
			return passiveProperties.Aggregate(source, (data, property) => property.Modify(source));
		}
	}
}
