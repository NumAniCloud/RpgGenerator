using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class DamageEvent : IBattleEvent<PassiveProcess>
	{
		public Battler Target { get; }
		public int Amount { get; }

		public DamageEvent(Battler target, int amount)
		{
			Target = target;
			Amount = amount;
		}

		public IEnumerable<PassiveProcess> PassiveProcessSubject => Target;

		public async Task RunAsync(BattleEventHandler<PassiveProcess> handler)
		{
			Console.WriteLine("Damaged");
		}
	}
}
