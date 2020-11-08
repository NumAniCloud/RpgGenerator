using RpgGenerator.Sandbox.Sample.PassiveAct2.Library;
using System.Linq;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
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

	public class StatefulPurePassiveProperty<TDomain, TDataStore> : IPassiveProperty<TDomain>
	{
		private readonly StatefulPassiveProcess<TDomain, TDataStore> _process;

		public TDataStore DataStore { get; set; }

		public StatefulPurePassiveProperty(StatefulPassiveProcess<TDomain, TDataStore> process)
		{
			_process = process;
			DataStore = process.InitialValue;
		}

		public async Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _process.LeadingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}

		public async Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _process.FollowingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}

		public TData Modify<TData>(TData source)
		{
			return _process.Modifiers.Aggregate(source, (x, passive) => passive.Modify(x, this));
		}
	}
}
