using System.Linq;
using System.Threading.Tasks;
using RpgGenerator.Basic.Active;

namespace RpgGenerator.Sandbox.Sample.Active
{
	class IntegerRangeProvider : IRangeProvider<int[]>
	{
		public int[] GetRange() => Enumerable.Range(0, 10).ToArray();
	}

	class BooleanRangeProvider : IRangeProvider<bool[]>
	{
		public bool[] GetRange() => new[] {true, false};
	}

	class ObjectRangeProvider : IRangeProvider<object[]>
	{
		public object[] GetRange() => new object[] {1, false, "hoge"};
	}

	class SingleTargetChooser<TResult> : ITargetChooser<TResult[], TResult>
	{
		public async Task<TResult> ChooseAsync(TResult[] range)
		{
			return range.First();
		}
	}

	class EntireTargetChooser<TResult> : ITargetChooser<TResult[], TResult[]>
	{
		public async Task<TResult[]> ChooseAsync(TResult[] range)
		{
			return range;
		}
	}
}
