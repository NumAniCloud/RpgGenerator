using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class Battler : IEnumerable<PassiveProcess<BattleContext>>
	{
		private List<PassiveProcess<BattleContext>> _passives = new List<PassiveProcess<BattleContext>>();

		public IEnumerator<PassiveProcess<BattleContext>> GetEnumerator()
		{
			return ((IEnumerable<PassiveProcess<BattleContext>>)_passives).GetEnumerator();
		}

		public IEnumerable<PassiveProcess<BattleContext>> GetPassiveProcesses()
		{
			return _passives;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_passives).GetEnumerator();
		}
	}
}
