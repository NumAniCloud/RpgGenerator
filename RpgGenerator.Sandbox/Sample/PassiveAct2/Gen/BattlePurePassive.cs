using RpgGenerator.Sandbox.Sample.PassiveAct2.Library;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Gen
{
	abstract class BattlePurePassive : PurePassiveProcess<BattleContext>
	{
	}

	abstract class BattlePassive<TDataStore> : StatefulPassiveProcess<BattleContext, TDataStore>
	{
	}
}
