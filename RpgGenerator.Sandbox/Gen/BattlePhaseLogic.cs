using System;
using System.Threading.Tasks;
using RpgGenerator.Annotations;

namespace RpgGenerator.Sandbox.Gen
{
	class BattlePhaseLogic : IBattlePhasesLogic
	{
		public async Task<PhaseResult<string>> DoSkillSelectionAsync(SkillSelectionPhase phase, IBattlePhases handler)
		{
			Console.Write($"アクター{phase.ActorId}の行動 >");
			var input = Console.ReadLine();
			if (input == "cancel" || input == null)
			{
				return new Cancelled<string>();
			}

			return await handler.TargetSelection(phase, int.Parse(input));
		}

		public async Task<PhaseResult<string>> DoTargetSelectionAsync(TargetSelectionPhase phase, IBattlePhases handler)
		{
			Console.Write($"ターゲットを選択 >");
			var input = Console.ReadLine();
			if (input == "cancel" || input == null)
			{
				return new Cancelled<string>();
			}

			var targetId = int.Parse(input);
			var result = $"{phase.ActorId} は {targetId} に {phase.SkillId} を使った";
			return new Finished<string>(result);
		}
	}
}
