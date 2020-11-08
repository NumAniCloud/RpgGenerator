using RpgGenerator.Sandbox.Sample.PassiveAct2.Library;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcess;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Gen
{
	abstract class BattlePurePassive : PurePassiveProcess<BattleContext>
	{
	}

	abstract class BattlePassive<TDataStore> : PassiveProcess<BattleContext, TDataStore>
	{
	}
}
