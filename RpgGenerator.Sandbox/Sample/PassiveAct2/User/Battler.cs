using System.Collections;
using System.Collections.Generic;
using Passive = RpgGenerator.Sandbox.Sample.PassiveAct2.PurePassiveProperty<RpgGenerator.Sandbox.Sample.PassiveAct2.BattleContext>;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class Battler : IEnumerable<Passive>
	{
		public ActorAbility Ability { get; }
		public List<Passive> Passives { get; } = new List<Passive>();

		public Battler(ActorAbility ability)
		{
			Ability = ability;
		}

		public ActorAbility GetModifiedAbility()
		{
			return Passives.Modify(Ability);
		}

		public IEnumerator<Passive> GetEnumerator()
		{
			return ((IEnumerable<Passive>)Passives).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)Passives).GetEnumerator();
		}
	}
}
