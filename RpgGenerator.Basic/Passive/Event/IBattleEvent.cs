using System.Collections.Generic;
using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Event
{
	public interface IBattleEvent<TDomain>
	{
		IEnumerable<IPassiveProperty<TDomain>> PassiveProcessSubject { get; }

		Task RunAsync(BattleEventHandler<TDomain> handler, TDomain domain);
	}
}
