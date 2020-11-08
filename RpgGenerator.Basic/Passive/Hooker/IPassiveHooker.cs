using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.Event;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Hooker
{
	public interface IPassiveHooker<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, IPassiveProperty<TDomain> self, TDomain context);
	}
}