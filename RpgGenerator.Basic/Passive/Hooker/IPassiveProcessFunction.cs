using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Hooker
{
	public interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, IPassiveProperty<TDomain> self, TDomain context);
	}
}