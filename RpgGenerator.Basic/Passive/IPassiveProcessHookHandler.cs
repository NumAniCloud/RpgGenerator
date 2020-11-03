using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public interface IPassiveProcessHookHandler<TPassive>
	{
		Task BeforeEventAsync(IBattleEvent<TPassive> @event);
		Task AfterEventAsync(IBattleEvent<TPassive> @event);
	}
}
