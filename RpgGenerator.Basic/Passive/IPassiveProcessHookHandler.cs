using System.Threading.Tasks;

namespace RpgGenerator.Basic.Passive
{
	public interface IPassiveProcessHookHandler<TDomain>
	{
		Task BeforeEventAsync(IBattleEvent<TDomain> @event);
		Task AfterEventAsync(IBattleEvent<TDomain> @event);
	}
}
