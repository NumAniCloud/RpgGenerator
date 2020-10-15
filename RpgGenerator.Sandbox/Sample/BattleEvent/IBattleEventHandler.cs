using System;
using System.Reactive;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.BattleEvent
{
	interface IBattleEventHandler
	{
		IObservable<Unit> OnBattleEventFinish { get; }
		Task HandleAsync(IPassiveEventProvider eventSubject, IBattleEvent @event);
	}
}
