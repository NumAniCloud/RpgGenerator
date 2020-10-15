using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public interface IBattleEvent
	{
		Task RunAsync(IBattleEventHandler handler);
	}
}
