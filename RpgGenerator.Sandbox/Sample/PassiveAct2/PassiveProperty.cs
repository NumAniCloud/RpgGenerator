using System;
using System.Linq;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	sealed class PassiveProperty<TDomain>
	{
		private readonly PassiveProcess<TDomain> _passiveProcess;

		public object? DataStore { get; set; }

		public PassiveProperty(PassiveProcess<TDomain> passiveProcess)
		{
			_passiveProcess = passiveProcess;
			_passiveProcess.Populate(this);
		}

		public T GetData<T>()
		{
			if (!(DataStore is T data))
			{
				throw new Exception();
			}

			return data;
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
}
