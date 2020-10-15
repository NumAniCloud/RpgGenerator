using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.Passive;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	interface IPassiveEventProvider
	{
	}

	interface IPassiveDecorationProvider : IPassiveEventProvider
	{
		IEnumerable<PassiveEffect> GetPassiveEffects();
	}
}
