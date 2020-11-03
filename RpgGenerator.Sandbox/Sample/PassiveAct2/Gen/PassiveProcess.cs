using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	abstract class PassiveProcess<TDomain>
	{
		private FuncAggregator? _leadingFunctions;
		private FuncAggregator? _followingFunctions;

		public IEnumerable<Proxy> LeadingProcesses => GetFunctions(ref _leadingFunctions, RegisterLeadingFunctions);
		public IEnumerable<Proxy> FollowingProcesses => GetFunctions(ref _followingFunctions, RegisterFollowingFunctions);

		public virtual int ModifyAttack(int source) => source;
		public virtual int ModifyDefence(int source) => source;

		private IEnumerable<Proxy> GetFunctions(ref FuncAggregator? aggregator, Action<FuncAggregator> registration)
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

		/// <summary>
		/// 型名の長さをごまかすプロキシ
		/// </summary>
		public sealed class Proxy
		{
			private readonly IPassiveProcessFunction<PassiveProcess<TDomain>, TDomain> _process;

			public Proxy(IPassiveProcessFunction<PassiveProcess<TDomain>, TDomain> processFunc)
			{
				_process = processFunc;
			}

			public async Task RunAsync(IBattleEvent<PassiveProcess<TDomain>> @event, TDomain context)
			{
				await _process.RunAsync(@event, context);
			}
		}

		protected sealed class FuncAggregator
		{
			public List<Proxy> Functions { get; } = new List<Proxy>();

			public void Register<TEvent>(Func<TEvent, TDomain, Task> processFunc)
				where TEvent : IBattleEvent<PassiveProcess<TDomain>>
			{
				Functions.Add(new Proxy(
					new PassiveProcessFunction<PassiveProcess<TDomain>,TEvent,TDomain>(processFunc)));
			}
		}
	}
}
