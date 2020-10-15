using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using RpgGenerator.Basic;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	class BattleEventHandler : IBattleEventHandler
	{
		private readonly IPassiveDecoratorHookHandler _passiveEventHook;
		private readonly Subject<Unit> _onBattleEventFinish = new Subject<Unit>();
		public IObservable<Unit> OnBattleEventFinish => _onBattleEventFinish;

		public BattleEventHandler(IPassiveDecoratorHookHandler passiveEventHook)
		{
			_passiveEventHook = passiveEventHook;
		}

		public async Task HandleAsync(IPassiveDecorationProviderBase eventSubject, IBattleEvent @event)
		{
			await _passiveEventHook.BeforeEventAsync(eventSubject, @event);
			await @event.RunAsync(this);
			await _passiveEventHook.AfterEventAsync(eventSubject, @event);

			_onBattleEventFinish.OnNext(Unit.Default);
		}
	}
}
