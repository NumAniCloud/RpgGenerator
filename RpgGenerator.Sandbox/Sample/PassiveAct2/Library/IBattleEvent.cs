using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IBattleEvent<TPassive>
	{
		IEnumerable<TPassive> PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler<TPassive> handler);
	}
}
