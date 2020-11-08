using System.Collections.Generic;
using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive
{
	public interface IBattleEvent<TDomain>
	{
		IEnumerable<IPassiveProperty<TDomain>> PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler<TDomain> handler);
	}
}
