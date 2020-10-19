using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public interface IPassiveDecoratorHookHandler
	{
		Task BeforeEventAsync(IPassiveDecorationProviderBase passive, IBattleEvent @event);
		Task AfterEventAsync(IPassiveDecorationProviderBase passive, IBattleEvent @event);
	}
}
