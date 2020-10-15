using System;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;

namespace RpgGenerator.Sandbox.Sample.Passive.User
{
	class RagePassiveEffect : PassiveDecoration
	{
		private readonly RagePassiveEffectDataStore _dataStore;

		public RagePassiveEffect(RagePassiveEffectDataStore dataStore)
		{
			_dataStore = dataStore;
		}

		public override Task AfterEventAsync(AttackBattleEvent @event)
		{
			Console.WriteLine($"攻撃を受けて怒った！ 攻撃＋{_dataStore.Diff}");
			_dataStore.Current += _dataStore.Diff;
			return Task.CompletedTask;
		}

		public override int ModifyAttack(int source)
		{
			return source + _dataStore.Current;
		}
	}
}
