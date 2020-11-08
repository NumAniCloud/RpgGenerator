using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcessFunction
{
	public interface IPassiveProcessFunction<TDomain>
	{
		Task RunAsync(IBattleEvent<TDomain> @event, IPassiveProperty<TDomain> self, TDomain context);
	}
}