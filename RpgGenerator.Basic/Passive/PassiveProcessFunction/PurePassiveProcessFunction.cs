using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive.PassiveProcessFunction
{
	public delegate Task PassiveProcessHook<in TEvent, TDomain>(TEvent @event, IPassiveProperty<TDomain> self, TDomain domain);

	public sealed class PurePassiveProcessFunction<TEvent, TDomain> : IPassiveProcessFunction<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly PassiveProcessHook<TEvent, TDomain> _processFunc;

		public PurePassiveProcessFunction(PassiveProcessHook<TEvent, TDomain> processFunc)
		{
			_processFunc = processFunc;
		}

		public async Task RunAsync(IBattleEvent<TDomain> @event,
			IPassiveProperty<TDomain> self,
			TDomain context)
		{
			if (@event is TEvent ev)
			{
				await _processFunc.Invoke(ev, self, context);
			}
		}
	}
}
