using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class DamageEvent : IBattleEvent
	{
		public Battler Target { get; }
		public int Amount { get; }

		public DamageEvent(Battler target, int amount)
		{
			Target = target;
			Amount = amount;
		}

		public IPassiveProcessProvider PassiveProcessSubject => Target;
		public async Task RunAsync(BattleEventHandler handler)
		{
			Console.WriteLine("Damaged");
		}
	}
}
