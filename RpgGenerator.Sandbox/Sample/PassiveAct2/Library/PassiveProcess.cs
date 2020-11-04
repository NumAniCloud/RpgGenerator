using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	abstract class PassiveProcess<TDomain>
	{
		private FuncAggregator? _leadingFunctions;
		private FuncAggregator? _followingFunctions;

		public IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses => GetFunctions(ref _leadingFunctions, RegisterLeadingFunctions);
		public IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses => GetFunctions(ref _followingFunctions, RegisterFollowingFunctions);

		public virtual int ModifyAttack(int source) => source;
		public virtual int ModifyDefence(int source) => source;

		private IEnumerable<IPassiveProcessFunction<TDomain>> GetFunctions(ref FuncAggregator? aggregator, Action<FuncAggregator> registration)
		{
			if (aggregator is null)
			{
				aggregator = new FuncAggregator();
				registration.Invoke(aggregator);
			}

			return aggregator.Functions;
		}

		protected virtual void RegisterLeadingFunctions(FuncAggregator aggregator)
		{
		}

		protected virtual void RegisterFollowingFunctions(FuncAggregator aggregator)
		{
		}

		protected sealed class FuncAggregator
		{
			public List<IPassiveProcessFunction<TDomain>> Functions { get; } = new List<IPassiveProcessFunction<TDomain>>();

			public void Register<TEvent>(Func<TEvent, TDomain, Task> processFunc)
				where TEvent : IBattleEvent<TDomain>
			{
				Functions.Add(new PassiveProcessFunction<TEvent, TDomain>(processFunc));
			}
		}
	}
}
