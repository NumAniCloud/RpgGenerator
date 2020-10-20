using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IBattleEvent
	{
		IPassiveProcessProvider PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler handler);
	}
}
