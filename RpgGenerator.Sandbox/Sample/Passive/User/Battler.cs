using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.BattleEvent;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	class Battler : IPassiveDecorationProvider
	{
		public ActorAbility Ability { get; }
		public FinalAbility FinalAbility { get; }
		public List<PassiveEffect> Passives { get; } = new List<PassiveEffect>();

		public Battler(ActorAbility ability)
		{
			Ability = ability;
			FinalAbility = new FinalAbility(ability, this);
		}

		public IEnumerable<PassiveEffect> GetPassiveEffects()
		{
			// 武器や防具のパッシブ効果などもここで提供する
			return Passives;
		}
	}
}
