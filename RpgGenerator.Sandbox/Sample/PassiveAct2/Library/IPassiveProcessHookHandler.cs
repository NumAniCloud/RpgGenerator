using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	interface IPassiveProcessHookHandler<TPassive>
	{
		Task BeforeEventAsync(IBattleEvent<TPassive> @event);
		Task AfterEventAsync(IBattleEvent<TPassive> @event);
	}
}
