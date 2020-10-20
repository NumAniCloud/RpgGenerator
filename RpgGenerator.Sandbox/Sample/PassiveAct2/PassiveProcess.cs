using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	abstract class PassiveProcess
	{
		public virtual Task BeforeEventAsync(DamageEvent @event, BattleContext context) => Task.CompletedTask;
		public virtual Task AfterEventAsync(DamageEvent @event, BattleContext context) => Task.CompletedTask;
		public virtual int ModifyAttack(int source) => source;
		public virtual int ModifyDefence(int source) => source;
	}
}
