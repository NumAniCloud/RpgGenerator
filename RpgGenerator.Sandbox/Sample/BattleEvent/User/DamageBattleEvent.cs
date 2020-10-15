using System;
using System.Threading.Tasks;
using RpgGenerator.Basic;

namespace RpgGenerator.Sandbox.Sample.BattleEvent.User
{
	class DamageBattleEvent : IBattleEvent
	{
		public async Task RunAsync(IBattleEventHandler handler)
		{
			Console.WriteLine("ダメージ");
		}
	}
}
