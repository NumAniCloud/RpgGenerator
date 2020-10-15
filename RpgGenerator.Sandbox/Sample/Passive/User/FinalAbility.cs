using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGenerator.Sandbox.Sample.BattleEvent;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	// これは生成
	class FinalAbility
	{
		private readonly ActorAbility _baseAbility;
		private readonly IPassiveEventProvider _passiveEventProvider;

		public FinalAbility(ActorAbility baseAbility, IPassiveEventProvider passiveEventProvider)
		{
			this._baseAbility = baseAbility;
			_passiveEventProvider = passiveEventProvider;
		}

		public int Attack => Aggregate(_baseAbility.Attack, p => p.ModifyAttack);
		public int Defence => Aggregate(_baseAbility.Defence, p => p.ModifyDefence);

		private T Aggregate<T>(T source, Func<PassiveEffect, Func<T, T>> getModifier)
		{
			return _passiveEventProvider.GetPassiveEffects()
				.Aggregate(source, (arg1, effect) => getModifier.Invoke(effect).Invoke(arg1));
		}
	}
}
