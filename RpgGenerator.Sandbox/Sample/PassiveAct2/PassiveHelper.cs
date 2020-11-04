namespace RpgGenerator.Sandbox.Sample.PassiveAct2
{
	static class PassiveHelper
	{
		public static BattleEventHandler<TDomain> CreateBattleEventHandler<TDomain>(TDomain domain)
		{
			return new BattleEventHandler<TDomain>(new PassiveProcessHookHandler2<TDomain>(domain));
		}
	}
}
