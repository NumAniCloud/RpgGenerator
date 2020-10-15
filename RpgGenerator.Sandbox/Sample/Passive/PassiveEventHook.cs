using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.BattleEvent;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;

namespace RpgGenerator.Sandbox.Sample.Passive
{
	// これは生成
	class PassiveEventHook : IPassiveEventHook
	{
		public async Task BeforeEventAsync(IPassiveEventProvider passive1, IBattleEvent @event)
		{
			Task SelectFunc(PassiveEffect passive) => @event switch
			{
				DamageBattleEvent ev0 => passive.BeforeEventAsync(ev0),
				AttackBattleEvent ev1 => passive.BeforeEventAsync(ev1),
				_ => Task.CompletedTask,
			};

			foreach (var passiveEffect in passive1.GetPassiveEffects())
			{
				await SelectFunc(passiveEffect);
			}
		}

		public async Task AfterEventAsync(IPassiveEventProvider passive1, IBattleEvent @event)
		{
			Task SelectFunc(PassiveEffect passive) => @event switch
			{
				DamageBattleEvent ev0 => passive.AfterEventAsync(ev0),
				AttackBattleEvent ev1 => passive.AfterEventAsync(ev1),
				_ => Task.CompletedTask,
			};

			foreach (var passiveEffect in passive1.GetPassiveEffects())
			{
				await SelectFunc(passiveEffect);
			}
		}
	}
}
