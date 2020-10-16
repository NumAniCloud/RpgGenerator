using System.Collections.Generic;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	class Battler : IPassiveDecorationProvider
	{
		public string Name { get; }
		public ActorAbility Ability { get; }
		public FinalActorAbility FinalActorAbility { get; }
		public List<PassiveDecoration> Passives { get; } = new List<PassiveDecoration>();

		public Battler(string name, ActorAbility ability)
		{
			Name = name;
			Ability = ability;
			FinalActorAbility = new FinalActorAbility(ability, this);
		}

		public IEnumerable<PassiveDecoration> GetPassiveDecorations()
		{
			// 武器や防具のパッシブ効果などもここで提供する
			return Passives;
		}
	}
}
