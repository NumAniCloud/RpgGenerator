using System.Collections.Generic;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	public interface IBattleEvent<TDomain>
	{
		IEnumerable<IPassiveProperty<TDomain>> PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler<TDomain> handler);
	}
}
