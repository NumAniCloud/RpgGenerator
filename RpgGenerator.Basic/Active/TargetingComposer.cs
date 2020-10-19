using System.Threading.Tasks;

namespace RpgGenerator.Basic.Active
{
	public class TargetingComposer<TRange, TResult> : ITargeting<TResult>
	{
		private readonly IRangeProvider<TRange> _range;
		private readonly ITargetChooser<TRange, TResult> _chooser;

		public TargetingComposer(IRangeProvider<TRange> range, ITargetChooser<TRange, TResult> chooser)
		{
			_range = range;
			_chooser = chooser;
		}

		public async Task<TResult> ChooseAsync() => await _chooser.ChooseAsync(_range.GetRange());
	}
}
