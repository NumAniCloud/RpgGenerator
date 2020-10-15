using System;
using System.Threading.Tasks;
using RpgGenerator.Annotations;

namespace RpgGenerator.Sandbox
{
	internal sealed class PhaseHandler : IBattlePhases
	{
		private readonly BattlePhaseLogicBase _logic;

		public PhaseHandler(BattlePhaseLogicBase logic)
		{
			_logic = logic;
		}

		public async Task<PhaseResult<string>> HandlePhase1Async(int x, int y)
		{
			var phase = new PhaseContext1(x, y);
			return await HandlePhaseFlowAsync(() => _logic.DoPhase1Async(phase, this));
		}

		public async Task<PhaseResult<string>> HandlePhase2Async(PhaseContext1 context, int z)
		{
			var phase = new PhaseContext2(context, z);
			return await HandlePhaseFlowAsync(() => _logic.DoPhase2Async(phase, this));
		}

		private async Task<PhaseResult<TResult>> HandlePhaseFlowAsync<TResult>(Func<Task<PhaseResult<TResult>>> logic) where TResult : class
		{
			while (true)
			{
				switch (await logic.Invoke())
				{
				case Cancelled<TResult> _: return new Backed<TResult>();
				case Finished<TResult> finished: return finished;
				}
			}
		}

		private sealed class Backed<T> : PhaseResult<T>
		{
			public override T UnWrapOrDefault() => default;
		}
	}

	internal abstract class BattlePhaseLogicBase
	{
		public abstract Task<PhaseResult<string>> DoPhase1Async(PhaseContext1 context, IBattlePhases handler);
		public abstract Task<PhaseResult<string>> DoPhase2Async(PhaseContext2 context, IBattlePhases handler);
	}
}
