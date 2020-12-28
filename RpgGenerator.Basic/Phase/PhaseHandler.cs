using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace RpgGenerator.Basic.Phase
{
	public delegate Task<IPhaseResult<TResult>> PhaseMethod<TResult>();
	public delegate Task<IPhaseResult<TResult>> PhaseMapper<in TItem, TResult>(TItem current);

	public static class PhaseHandler
	{
		public static async Task<IPhaseResult<TResult>> HandlePhase<TResult>(
			PhaseMethod<TResult> logic)
		{
			while (true)
			{
				switch (await logic.Invoke())
				{
				case Finished<TResult> finished: return finished;
				case Cancelled<TResult>: return PhaseResult.NeedsRetry<TResult>();
				}
			}
		}
		
		public static async Task<TResult> HandleEntryPhase<TResult>(
			PhaseMethod<TResult> logic)
			where TResult : notnull
		{
			while (true)
			{
				if (await logic.Invoke() is Finished<TResult> finished)
				{
					return finished.Value;
				}
			}
		}

		public static IPhaseResult<TMapped> Map<TResult, TMapped>(
			this IPhaseResult<TResult> source,
			Func<TResult, TMapped> onFinalValue)
		{
			return source switch
			{
				Finished<TResult> finished => onFinalValue(finished.Value).AsFinished(),
				Cancelled<TResult> => PhaseResult.NeedsRetry<TMapped>(),
				NeedsRetry<TResult> => PhaseResult.NeedsRetry<TMapped>(),
				_ => throw new Exception()
			};
		}
		
		public static async Task<IPhaseResult<TMapped>> ContinueWith<TResult, TMapped>(
			this IPhaseResult<TResult> source,
			PhaseMapper<TResult, TMapped> onFinalValue)
		{
			return source switch
			{
				Finished<TResult> finished => await onFinalValue(finished.Value),
				Cancelled<TResult> => PhaseResult.Cancel<TMapped>(),
				NeedsRetry<TResult> => PhaseResult.NeedsRetry<TMapped>(),
				_ => throw new Exception()
			};
		}
		
		public static async Task<IPhaseResult<IEnumerable<TResult>>> ForEachPhase<TResult, TItem>(
			PhaseMapper<TItem, TResult> logic, TItem[] items)
		{
			async Task<IPhaseResult<IEnumerable<TResult>>> Iteration(TItem current, TItem[] rest)
			{
				var result = await HandlePhase(() => logic(current));
				return await result.ContinueWith(async value =>
				{
					if (!rest.Any())
					{
						return new []{ value }.AsEnumerable().AsFinished();
					}

					return (await Iteration(rest[0], rest[1..]))
						.Map(y => new []{ value }.Concat(y));
				});
			}

			return await Iteration(items[0], items[1..]);
		}

		public static IPhaseResult<TResult> AsFinished<TResult>(this TResult value)
			=> PhaseResult.Finish(value);
	}
}

namespace Hoge
{
	interface IMaybe<T>
	{
	}

	record Just<T>(T Value) : IMaybe<T>;

	record Nothing<T> : IMaybe<T>;

	struct Unit
	{
		public static Unit Id => new();
	}

	interface IPhaseIn<TArg, TFinal>
	{
		IMaybe<TFinal> Run(TArg arg);
		IPhaseIn<TArg, TNewFinal> Append<TNewFinal>(Func<TFinal, IMaybe<TNewFinal>> func);
	}

	record Phase<TArg, TResult, TFinal>(
		Func<TArg, IMaybe<TResult>> Function,
		IPhaseIn<TResult, TFinal> Rest) : IPhaseIn<TArg, TFinal>
	{
		public IMaybe<TFinal> Run(TArg arg)
		{
			while (true)
			{
				var result = Function.Invoke(arg)
					.Bind(x => new Just<IMaybe<TFinal>>(Rest.Run(x)));

				if (result is Just<IMaybe<TFinal>> { Value: Nothing<TFinal> })
				{
					continue;
				}

				return result.Join();
			}
		}

		public IPhaseIn<TArg, TNewFinal> Append<TNewFinal>(Func<TFinal, IMaybe<TNewFinal>> func)
		{
			return new Phase<TArg, TResult, TNewFinal>(
				Function,
				func is Func<TResult, IMaybe<TNewFinal>> final && Rest is PhaseTail<TResult>
					? new Phase<TResult, TNewFinal, TNewFinal>(final, new PhaseTail<TNewFinal>())
					: Rest.Append(func));
		}
	}

	class PhaseTail<TFinal> : IPhaseIn<TFinal, TFinal>
	{
		public IMaybe<TFinal> Run(TFinal arg)
		{
			return new Just<TFinal>(arg);
		}

		public IPhaseIn<TFinal, TNewFinal> Append<TNewFinal>(Func<TFinal, IMaybe<TNewFinal>> func)
		{
			return new Phase<TFinal, TFinal, TNewFinal>(Run,
				new Phase<TFinal, TNewFinal, TNewFinal>(func, new PhaseTail<TNewFinal>()));
		}

		public static IPhaseIn<TFinal, TFinal> Unit() => new PhaseTail<TFinal>();
	}
}
