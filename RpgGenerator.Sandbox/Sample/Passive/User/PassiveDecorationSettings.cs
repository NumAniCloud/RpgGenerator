using RpgGenerator.Basic;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	[PassiveDecoration]
	class PassiveDecorationSettings
	{
		public ActorAbility Ability;
		public AttackBattleEvent Attack;
		public DamageBattleEvent Damage;
	}
}
