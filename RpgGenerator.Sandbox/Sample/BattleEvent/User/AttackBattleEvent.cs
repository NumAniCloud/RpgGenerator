using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class AttackBattleEvent : IBattleEvent
	{
		public async Task RunAsync(IBattleEventHandler handler)
		{
			Console.WriteLine("攻撃");
			await handler.HandleAsync(new PassiveSubject(), new DamageBattleEvent());
		}
	}
}
