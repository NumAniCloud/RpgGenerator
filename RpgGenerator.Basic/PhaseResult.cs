namespace RpgGenerator.Annotations
{
	public abstract class PhaseResult<T>
	{
		public abstract T UnWrapOrDefault();
	}

	public sealed class Finished<T> : PhaseResult<T>
	{
		public T Value { get; }

		public Finished(T value)
		{
			Value = value;
		}

		public override T UnWrapOrDefault() => Value;
	}

	public sealed class Cancelled<T> : PhaseResult<T>
	{
		public override T UnWrapOrDefault() => default;
	}
}
