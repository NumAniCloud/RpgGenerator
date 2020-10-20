using System;
using System.Linq;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	class FinalActorAbility
	{
		private readonly IPassiveProcessProvider _provider;
		private readonly ActorAbility _baseProperty;

		public FinalActorAbility(ActorAbility baseProperty, IPassiveProcessProvider provider)
		{
			_baseProperty = baseProperty;
			_provider = provider;
		}

		public int Attack => Aggregate(_baseProperty.Attack, p => p.ModifyAttack);

		public int Defence => Aggregate(_baseProperty.Defence, p => p.ModifyDefence);
		
		private T Aggregate<T>(T source, Func<PassiveProcess, Func<T, T>> getModifier)
		{
			return _provider.GetPassiveProcesses()
				.Aggregate(source, (arg1, effect) => getModifier.Invoke(effect).Invoke(arg1));
		}
	}
}
