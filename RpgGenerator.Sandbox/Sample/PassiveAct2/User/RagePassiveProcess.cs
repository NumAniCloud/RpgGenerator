using System;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class RagePassiveProcess : PassiveProcess<BattleContext>
	{
		protected override void RegisterFollowingFunctions(FuncAggregator aggregator)
		{
			aggregator.Register<DamageEvent>(OnAttackedAsync);
		}

		private async Task OnAttackedAsync(DamageEvent @event, BattleContext context)
		{
			Console.WriteLine("Rage");
		}
	}
}
