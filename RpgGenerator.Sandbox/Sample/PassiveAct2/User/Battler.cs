using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class Battler : IEnumerable<PassiveProcess>
	{
		private List<PassiveProcess> _passives = new List<PassiveProcess>();

		public IEnumerator<PassiveProcess> GetEnumerator()
		{
			return ((IEnumerable<PassiveProcess>)_passives).GetEnumerator();
		}

		public IEnumerable<PassiveProcess> GetPassiveProcesses()
		{
			return _passives;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_passives).GetEnumerator();
		}
	}
}
