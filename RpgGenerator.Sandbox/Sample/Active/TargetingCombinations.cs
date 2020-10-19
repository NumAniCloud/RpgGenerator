using RpgGenerator.Basic.Active;
using System.Threading.Tasks;

namespace RpgGenerator.Sandbox.Sample.Active
{
	class SingleInteger : IntegerTargeting<int>, ITargeting<int[]>
	{
		public SingleInteger()
			: base(new SingleTargetChooser<int>())
		{
		}

		async Task<int[]> ITargeting<int[]>.ChooseAsync()
		{
			return new[] {await base.ChooseAsync()};
		}
	}

	class SingleBoolean : BooleanTargeting<bool>, ITargeting<bool[]>
	{
		public SingleBoolean()
			: base(new SingleTargetChooser<bool>())
		{
		}

		async Task<bool[]> ITargeting<bool[]>.ChooseAsync()
		{
			return new []{await base.ChooseAsync()};
		}
	}

	class EntireInteger : IntegerTargeting<int[]>
	{
		public EntireInteger()
			: base(new EntireTargetChooser<int>())
		{
		}
	}

	class EntireBoolean : BooleanTargeting<bool[]>
	{
		public EntireBoolean()
			: base(new EntireTargetChooser<bool>())
		{
		}
	}
}
