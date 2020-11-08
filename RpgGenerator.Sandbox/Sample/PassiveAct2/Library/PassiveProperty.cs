using RpgGenerator.Sandbox.Sample.PassiveAct2.Library;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	public class PassiveProperty<TDomain>
	{
		private readonly PassiveProcess<TDomain> _passiveProcess;

		public PassiveProperty(PassiveProcess<TDomain> passiveProcess)
		{
			_passiveProcess = passiveProcess;
		}

		public async Task RunLeadingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _passiveProcess.LeadingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}
		
		public async Task RunFollowingProcessAsync(IBattleEvent<TDomain> @event, TDomain domain)
		{
			foreach (var process in _passiveProcess.FollowingProcesses)
			{
				await process.RunAsync(@event, this, domain);
			}
		}

		public TData Modify<TData>(TData source)
		{
			return _passiveProcess.Modifiers.Aggregate(source, (x, passive) => passive.Modify(x, this));
		}
	}

	public class StatefulPassiveProperty<TDomain, TDataStore> : PassiveProperty<TDomain>
	{
		public TDataStore DataStore { get; set; }

		public StatefulPassiveProperty(StatefulPassiveProcess<TDomain, TDataStore> process)
			: base(process)
		{
			DataStore = process.InitialValue;
		}
	}
}
