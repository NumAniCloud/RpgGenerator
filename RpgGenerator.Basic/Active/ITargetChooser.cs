using System.Threading.Tasks;

namespace RpgGenerator.Basic.Active
{
	public interface ITargetChooser<in TRange, TResult>
	{
		Task<TResult> ChooseAsync(TRange range);
	}
}
