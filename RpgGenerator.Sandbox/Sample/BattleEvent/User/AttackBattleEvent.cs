using System;
using System.Threading.Tasks;
using RpgGenerator.Basic;
using RpgGenerator.Sandbox.Sample.Passive.User;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class AttackBattleEvent : IBattleEvent
	{
		private readonly Battler _doer;
		private readonly Battler _target;

		public AttackBattleEvent(Battler doer, Battler target)
		{
			_doer = doer;
			_target = target;
		}

		public Battler Doer => _doer;

		public Battler Target => _target;

		public async Task RunAsync(IBattleEventHandler handler)
		{
			Console.WriteLine($"{Doer.Name} が {Target.Name} に攻撃します");
			await handler.HandleAsync(Target, new DamageBattleEvent(Target));
		}
	}
}
