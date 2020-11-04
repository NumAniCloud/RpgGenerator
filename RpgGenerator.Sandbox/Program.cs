﻿using System;
using RpgGenerator.Sandbox.Sample.PassiveAct2;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

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
			var domain = new BattleContext();
			var handler = PassiveHelper.CreateBattleEventHandler(domain);
			var battler = new Battler(new ActorAbility() { Attack = 1, Defence = 1 })
			{
				Passives =
				{
					new PassiveProperty<BattleContext>(new RagePassiveProcess()),
				},
			};
			var damage = new DamageEvent(battler, 10);

			Console.WriteLine($"攻撃力：{battler.GetModifiedAbility().Attack}");
			Console.WriteLine($"防御力：{battler.GetModifiedAbility().Defence}");
			handler.HandleAsync(damage).Wait();
			Console.WriteLine($"攻撃力：{battler.GetModifiedAbility().Attack}");
			Console.WriteLine($"防御力：{battler.GetModifiedAbility().Defence}");
		}
	}
}
