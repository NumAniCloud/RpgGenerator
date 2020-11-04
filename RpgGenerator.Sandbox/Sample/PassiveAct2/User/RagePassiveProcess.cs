using System;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Gen;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class RagePassiveProcess : BattlePassive
	{
		public override void Populate(PassiveProperty<BattleContext> self)
		{
			self.DataStore = 0;
		}

		protected override void RegisterFollowingFunctions(FuncAggregator aggregator)
		{
			aggregator.Register<DamageEvent>(OnAttackedAsync);
		}

		protected override void RegisterModifiers(ModifierAggregator aggregator)
		{
			aggregator.Register<ActorAbility>(ModifyAttack);
		}

		private async Task OnAttackedAsync(DamageEvent @event,
			PassiveProperty<BattleContext> property,
			BattleContext context)
		{
			Console.WriteLine("Rage");
			property.DataStore = property.GetData<int>() + 1;
		}

		private ActorAbility ModifyAttack(ActorAbility ability, PassiveProperty<BattleContext> self)
		{
			return new ActorAbility()
			{
				Attack = ability.Attack + self.GetData<int>(),
				Defence = ability.Defence
			};
		}
	}
}
