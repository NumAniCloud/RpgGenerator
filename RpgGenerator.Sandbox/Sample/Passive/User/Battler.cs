using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.BattleEvent;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	class Battler : IPassiveDecorationProvider
	{
		public ActorAbility Ability { get; }
		public List<PassiveDecoration> Passives { get; } = new List<PassiveDecoration>();

		public Battler(ActorAbility ability)
		{
			Ability = ability;
		}

		public IEnumerable<PassiveDecoration> GetPassiveDecorations()
		{
			// 武器や防具のパッシブ効果などもここで提供する
			return Passives;
		}
	}
}
