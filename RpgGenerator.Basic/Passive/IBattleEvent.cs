using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public interface IBattleEvent<TPassive>
	{
		Task RunAsync(BattleEventHandler<TPassive> handler);
	}
}
