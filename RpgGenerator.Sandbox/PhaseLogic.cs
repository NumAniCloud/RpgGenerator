using System;
using System.Threading.Tasks;
using RpgGenerator.Basic;

namespace RpgGenerator.Sandbox
{
	class BattlePhaseLogic : BattlePhaseLogicBase
	{
		public override async Task<PhaseResult<string>> DoPhase1Async(PhaseContext1 context, IBattlePhases processor)
		{
			Console.Write($"{context.X} + {context.Y} + Z >");
			var input = Console.ReadLine();
			if (input == "cancel" || input is null)
			{
				return new Cancelled<string>();
			}

			return await processor.HandlePhase2Async(context, int.Parse(input));
		}

		public override async Task<PhaseResult<string>> DoPhase2Async(PhaseContext2 context, IBattlePhases processor)
		{
			Console.Write("yes/no >");
			if (Console.ReadLine() == "no")
			{
				return new Cancelled<string>();
			}

			var sum = context.X + context.Y + context.Z;
			return new Finished<string>($"{context.X} + {context.Y} + {context.Z} = {sum}");
		}
	}
}
