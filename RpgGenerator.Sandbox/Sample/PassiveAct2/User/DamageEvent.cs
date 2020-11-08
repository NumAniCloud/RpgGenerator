using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class DamageEvent : IBattleEvent<BattleContext>
	{
		public Battler Target { get; }
		public int Amount { get; }

		public DamageEvent(Battler target, int amount)
		{
			Target = target;
			Amount = amount;
		}

		public IEnumerable<PurePassiveProperty<BattleContext>> PassiveProcessSubject => Target;

		public async Task RunAsync(BattleEventHandler<BattleContext> handler)
		{
			Console.WriteLine("Damaged");
		}
	}
}
