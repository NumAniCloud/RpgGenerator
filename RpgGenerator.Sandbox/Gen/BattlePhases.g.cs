﻿// <autogenerated />
#nullable enable
using System;
using System.Threading.Tasks;
using RpgGenerator.Annotations;

namespace RpgGenerator.Sandbox.Gen
{
	internal sealed class SkillSelectionPhase
	{
		public int ActorId { get; }

		public SkillSelectionPhase(int actorId)
		{
			ActorId = actorId;
		}
	}

	internal sealed class TargetSelectionPhase
	{
		private SkillSelectionPhase Phase { get; }
		public int ActorId => Phase.ActorId;
		public int SkillId { get; }

		public TargetSelectionPhase(SkillSelectionPhase phase, int skillId)
		{
			Phase = phase;
			SkillId = skillId;
		}
	}

	internal sealed class BattlePhasesHandler : IBattlePhases
	{
		private readonly IBattlePhasesLogic _logic;

		public BattlePhasesHandler(IBattlePhasesLogic logic)
		{
			_logic = logic;
		}

		public async Task<PhaseResult<string>> SkillSelection(int actorId)
		{
			var __phase = new SkillSelectionPhase(actorId);
			return await HandlePhaseFlowAsync(() => _logic.DoSkillSelectionAsync(__phase, this));
		}

		public async Task<PhaseResult<string>> TargetSelection(SkillSelectionPhase phase, int skillId)
		{
			var __phase = new TargetSelectionPhase(phase, skillId);
			return await HandlePhaseFlowAsync(() => _logic.DoTargetSelectionAsync(__phase, this));
		}

		private async Task<PhaseResult<TResult>> HandlePhaseFlowAsync<TResult>(Func<Task<PhaseResult<TResult>>> logic)
			where TResult : class
		{
			while (true)
			{
				switch (await logic.Invoke())
				{
				case Cancelled<TResult> cancelled: return new Backed<TResult>();
				case Finished<TResult> finished: return finished;
				}
			}
		}

		private sealed class Backed<T> : PhaseResult<T>
		{
			public override T UnWrapOrDefault() => default;
		}
	}

	internal interface IBattlePhasesLogic
	{
		Task<PhaseResult<string>> DoSkillSelectionAsync(SkillSelectionPhase phase, IBattlePhases handler);
		Task<PhaseResult<string>> DoTargetSelectionAsync(TargetSelectionPhase phase, IBattlePhases handler);
	}
}