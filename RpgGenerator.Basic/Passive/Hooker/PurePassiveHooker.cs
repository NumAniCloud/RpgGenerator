﻿using System.Threading.Tasks;
using RpgGenerator.Basic.Passive.Event;
using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Hooker
{
	public delegate Task PassiveProcessHook<in TEvent, TDomain>(TEvent @event, IPassiveProperty<TDomain> self, TDomain domain);

	public sealed class PurePassiveHooker<TEvent, TDomain> : IPassiveHooker<TDomain>
		where TEvent : IBattleEvent<TDomain>
	{
		private readonly PassiveProcessHook<TEvent, TDomain> _processFunc;

		public PurePassiveHooker(PassiveProcessHook<TEvent, TDomain> processFunc)
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
