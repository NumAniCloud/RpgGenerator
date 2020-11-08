using System.Linq;
using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.PassiveProcess;

namespace RpgGenerator.Basic.Passive.PassiveProperty
{
	public class PurePassiveProperty<TDomain> : IPassiveProperty<TDomain>
	{
		private readonly PurePassiveProcess<TDomain> _purePassiveProcess;

		public PurePassiveProperty(PurePassiveProcess<TDomain> purePassiveProcess)
		{
			_purePassiveProcess = purePassiveProcess;
		}

		public async Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _purePassiveProcess.LeadingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}
		
		public async Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _purePassiveProcess.FollowingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}

		public TData Modify<TData>(TData source)
		{
			return _purePassiveProcess.Modifiers.Aggregate(source, (x, passive) => passive.Modify(x, this));
		}
	}
}
