using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public interface IPassiveProperty<TDomain>
	{
		Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain);
		TData Modify<TData>(TData source);
	}
}
