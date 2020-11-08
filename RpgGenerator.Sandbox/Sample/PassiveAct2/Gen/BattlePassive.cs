using RpgGenerator.Sandbox.Sample.PassiveAct2.Library;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Gen
{
	abstract class BattlePassive : PassiveProcess<BattleContext>
	{
	}

	abstract class BattlePassive<TDataStore> : StatefulPassiveProcess<BattleContext, TDataStore>
	{
	}
}
