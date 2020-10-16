using System;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	class RagePassiveEffect : PassiveDecoration
	{
		private int _current = 0;
		public int Diff { get; set; }

		public RagePassiveEffect(int diff)
		{
			Diff = diff;
		}

		public override Task AfterEventAsync(AttackBattleEvent @event)
		{
			Console.WriteLine($"{@event.Target.Name} は攻撃を受けて怒っている。 攻撃＋{Diff}");
			_current += Diff;
			return Task.CompletedTask;
		}

		public override int ModifyAttack(int source)
		{
			return source + _current;
		}
	}
}
