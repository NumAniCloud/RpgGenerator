namespace RpgGenerator.Basic
{
	public interface IPhaseResult<out T>
	{
	}

	public class PhaseResult
	{
		public static IPhaseResult<T> Finish<T>(T value) => new Finished<T>(value);
		public static IPhaseResult<T> Cancel<T>() => new Cancelled<T>();
		internal static IPhaseResult<T> NeedsRetry<T>() => new NeedsRetry<T>();
	}

	internal sealed record Finished<T>(T Value) : IPhaseResult<T>;

	internal sealed record Cancelled<T> : IPhaseResult<T>;

	internal sealed record NeedsRetry<T> : IPhaseResult<T>;
}
