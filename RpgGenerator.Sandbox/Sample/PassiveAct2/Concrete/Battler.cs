using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Concrete
{
	class Battler : IPassiveProcessProvider
	{
		private List<PassiveProcess> _passives = new List<PassiveProcess>();

		public IEnumerable<PassiveProcess> GetPassiveProcesses()
		{
			return _passives;
		}
	}
}
