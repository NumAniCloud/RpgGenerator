using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.BattleEvent.User;

namespace RpgGenerator.Sandbox.Sample.Passive
{
	// これは生成
	abstract class PassiveEffect
	{
		public virtual Task BeforeEventAsync(DamageBattleEvent @event) => Task.CompletedTask;
		public virtual Task BeforeEventAsync(AttackBattleEvent @event) => Task.CompletedTask;
		public virtual Task AfterEventAsync(DamageBattleEvent @event) => Task.CompletedTask;
		public virtual Task AfterEventAsync(AttackBattleEvent @event) => Task.CompletedTask;
		public virtual int ModifyAttack(int source) => source;
		public virtual int ModifyDefence(int source) => source;
	}
}
