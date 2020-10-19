using System;
using System.Reactive;
using System.Threading.Tasks;

namespace RpgGenerator.Basic
{
	public interface IBattleEventHandler
	{
		IObservable<Unit> OnBattleEventFinish { get; }
		Task HandleAsync(IPassiveDecorationProviderBase eventSubject, IBattleEvent @event);
	}
}