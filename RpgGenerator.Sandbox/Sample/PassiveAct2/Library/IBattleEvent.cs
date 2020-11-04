using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IBattleEvent<TDomain>
	{
		IEnumerable<PassiveProperty<TDomain>> PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler<TDomain> handler);
	}
}
