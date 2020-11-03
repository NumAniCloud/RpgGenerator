using System;
using System.Collections.Generic;
using System.Linq;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Gen;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class FinalActorAbility
	{
		private readonly IEnumerable<BattlePassive> _provider;
		private readonly ActorAbility _baseProperty;

		public FinalActorAbility(ActorAbility baseProperty, IEnumerable<BattlePassive> provider)
		{
			_baseProperty = baseProperty;
			_provider = provider;
		}

		public int Attack => Aggregate(_baseProperty.Attack, p => p.ModifyAttack);

		public int Defence => Aggregate(_baseProperty.Defence, p => p.ModifyDefence);
		
		private T Aggregate<T>(T source, Func<BattlePassive, Func<T, T>> getModifier)
		{
			return _provider.Aggregate(source, (arg1, effect) => getModifier.Invoke(effect).Invoke(arg1));
		}
	}
}
