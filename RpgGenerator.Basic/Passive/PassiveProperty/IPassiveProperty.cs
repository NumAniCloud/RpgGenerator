using System.Threading.Tasks;

namespace RpgGenerator.Basic.Passive.PassiveProperty
{
	public interface IPassiveProperty<TDomain>
	{
		Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		TData Modify<TData>(TData source);
	}
}
