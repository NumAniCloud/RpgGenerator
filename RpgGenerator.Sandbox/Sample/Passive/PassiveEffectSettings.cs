using RpgGenerator.Sandbox.Sample.BattleEvent.User;
using RpgGenerator.Sandbox.Sample.Passive.User;

namespace RpgGenerator.Sandbox.Sample.Passive
{
	// 生成元
	class PassiveEffectSettings
	{
		// ActorAbility内のint, bool, float, stringなどのプリミティブ型が対象
		ActorAbility Ability;

		// 必ずBefore, Afterが両方作られる
		AttackBattleEvent AttackBattleEvent;
		DamageBattleEvent DamageBattleEvent;
	}
}
