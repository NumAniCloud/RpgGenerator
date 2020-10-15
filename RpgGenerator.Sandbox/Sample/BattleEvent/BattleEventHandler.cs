using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using RpgGenerator.Sandbox.Sample.Passive;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	class BattleEventHandler : IBattleEventHandler
	{
		private readonly IPassiveEventHook _passiveEventHook;
		private readonly Subject<Unit> _onBattleEventFinish = new Subject<Unit>();
		public IObservable<Unit> OnBattleEventFinish => _onBattleEventFinish;

		public BattleEventHandler(IPassiveEventHook passiveEventHook)
		{
			_passiveEventHook = passiveEventHook;
		}

		public async Task HandleAsync(IPassiveEventProvider eventSubject, IBattleEvent @event)
		{
			await _passiveEventHook.BeforeEventAsync(eventSubject, @event);
			await @event.RunAsync(this);
			await _passiveEventHook.AfterEventAsync(eventSubject, @event);

			_onBattleEventFinish.OnNext(Unit.Default);
		}
	}
}
