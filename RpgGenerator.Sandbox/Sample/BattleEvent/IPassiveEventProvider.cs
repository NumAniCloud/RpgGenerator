using System;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Sandbox.Sample.Passive;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	interface IPassiveEventProvider
	{
		IEnumerable<PassiveEffect> GetPassiveEffects();
	}
}
