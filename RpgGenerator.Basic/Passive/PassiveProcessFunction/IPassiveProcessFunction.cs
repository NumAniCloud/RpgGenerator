using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive.PassiveProcessFunction
{
	public interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, IPassiveProperty<TDomain> self, TDomain context);
	}
}