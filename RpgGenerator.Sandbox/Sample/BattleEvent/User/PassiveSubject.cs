using System;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Sandbox.Sample.Passive;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class PassiveSubject : IPassiveEventProvider
	{
		public IEnumerable<PassiveEffect> GetPassiveEffects()
		{
			return new List<PassiveEffect>();
		}
	}
}
