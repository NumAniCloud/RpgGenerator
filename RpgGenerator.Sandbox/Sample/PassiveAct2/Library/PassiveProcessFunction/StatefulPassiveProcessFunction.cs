using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcessFunction
{
	public delegate Task PassiveProcessHook<in TEvent, TDomain, TDataStore>(TEvent @event,
		StatefulPurePassiveProperty<TDomain, TDataStore> self,
		TDomain domain);

	public sealed class StatefulPassiveProcessFunction<TEvent, TDomain, TDataStore>
		: IPassiveProcessFunction<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly PassiveProcessHook<TEvent, TDomain, TDataStore> _processHook;

		public StatefulPassiveProcessFunction(PassiveProcessHook<TEvent, TDomain, TDataStore> processHook)
		{
			_processHook = processHook;
		}

		public async Task RunAsync(IBattleEvent<TDomain> @event, IPassiveProperty<TDomain> self, TDomain context)
		{
			if (@event is TEvent ev)
			{
				if (self is StatefulPurePassiveProperty<TDomain, TDataStore> property)
				{
					await _processHook.Invoke(ev, property, context);
				}
			}
		}
	}
}