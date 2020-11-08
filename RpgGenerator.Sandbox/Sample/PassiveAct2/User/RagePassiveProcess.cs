using System;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Gen;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class RagePassiveProcess : BattlePassive<int>
	{
		public override int InitialValue => 0;

		protected override void RegisterFollowingFunctions(FuncAggregatorWithState aggregator)
		{
			aggregator.Register<DamageEvent>(OnAttackedAsync);
		}

		protected override void RegisterModifiers(ModifierAggregatorWithState aggregator)
		{
			aggregator.Register<ActorAbility>(ModifyAttack);
		}

		private async Task OnAttackedAsync(DamageEvent @event,
			PassiveProperty<BattleContext, int> property,
			BattleContext context)
		{
			Console.WriteLine("Rage");
			property.DataStore = property.DataStore + 1;
		}

		private ActorAbility ModifyAttack(ActorAbility ability,
			PassiveProperty<BattleContext, int> self)
		{
			return new ActorAbility()
			{
				Attack = ability.Attack + self.DataStore,
				Defence = ability.Defence
			};
		}
	}
}
