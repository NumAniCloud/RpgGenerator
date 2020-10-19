using System.Threading.Tasks;

namespace RpgGenerator.Basic.Active
{
	public interface ITargeting<TResult>
	{
		Task<TResult> ChooseAsync();
	}
}
