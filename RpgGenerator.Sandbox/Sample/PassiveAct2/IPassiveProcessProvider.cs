using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IPassiveProcessProvider
	{
		IEnumerable<PassiveProcess> GetPassiveProcesses();
	}
}
