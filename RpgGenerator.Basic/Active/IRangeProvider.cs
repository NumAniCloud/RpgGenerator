namespace RpgGenerator.Basic.Active
{
	public interface IRangeProvider<out TResult>
	{
		TResult GetRange();
	}
}
