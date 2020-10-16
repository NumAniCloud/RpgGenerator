using System;
using RpgGenerator.Sandbox.Sample.BattleEvent;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;
using RpgGenerator.Sandbox.Sample.Passive.User;

namespace RpgGenerator.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			TestPassiveSystem();
		}

		private static void TestPassiveSystem()
		{
			var handler = new BattleEventHandler(new PassiveDecorationHookHandler());
			var battler1 = new Battler("Me",
				new ActorAbility() {Attack = 5, Defence = 5});
			var battler2 = new Battler("Opponent",
				new ActorAbility() {Attack = 6, Defence = 6});
			battler2.Passives.Add(new RagePassiveEffect(4));
			var attack = new AttackBattleEvent(battler1, battler2);

			handler.HandleAsync(battler2, attack).Wait();

			Console.WriteLine($"{battler2.Name} の攻撃力 ＝ {battler2.FinalActorAbility.Attack}");
		}
	}
}
