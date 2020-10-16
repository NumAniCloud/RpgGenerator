using System;
using System.Threading.Tasks;
using RpgGenerator.Basic;
using RpgGenerator.Sandbox.Sample.Passive.User;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class DamageBattleEvent : IBattleEvent
	{
		private readonly Battler _target;

		public DamageBattleEvent(Battler target)
		{
			_target = target;
		}

		public async Task RunAsync(IBattleEventHandler handler)
		{
			Console.WriteLine($"{_target.Name} はダメージを受けました");
		}
	}
}
