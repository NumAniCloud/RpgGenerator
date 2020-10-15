using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.Passive.User;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class PassiveSubject : IPassiveDecorationProvider
	{
		public IEnumerable<PassiveDecoration> GetPassiveDecorations()
		{
			return new List<PassiveDecoration>();
		}
	}
}
