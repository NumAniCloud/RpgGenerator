using System.Threading.Tasks;

namespace RpgGenerator.Basic.Passive.Property
{
	public interface IPassiveProperty<TDomain>
	{
		Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		TData Modify<TData>(TData source);
	}
}
