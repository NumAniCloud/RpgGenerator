using System.Linq;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcess;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty
{
	public class PassiveProperty<TDomain, TDataStore> : IPassiveProperty<TDomain>
	{
		private readonly PassiveProcess<TDomain, TDataStore> _process;

		public TDataStore DataStore { get; set; }

		public PassiveProperty(PassiveProcess<TDomain, TDataStore> process)
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