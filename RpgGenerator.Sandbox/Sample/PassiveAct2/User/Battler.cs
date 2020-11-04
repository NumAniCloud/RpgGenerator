using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Gen;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class Battler : IEnumerable<BattlePassive>
	{
		private List<BattlePassive> _passives = new List<BattlePassive>();

		public IEnumerator<BattlePassive> GetEnumerator()
		{
			return ((IEnumerable<BattlePassive>)_passives).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_passives).GetEnumerator();
		}
	}
}
