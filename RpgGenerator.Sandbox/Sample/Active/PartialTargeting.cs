using System.Collections.Generic;
using System.Threading.Tasks;
using RpgGenerator.Basic.Active;

namespace RpgGenerator.Sandbox.Sample.Active
{
	class IntegerTargeting<TResult> : TargetingComposer<int[], TResult>, ITargeting<object>
	{
		public IntegerTargeting(ITargetChooser<int[], TResult> chooser)
			: base(new IntegerRangeProvider(), chooser)
		{
		}

		async Task<object> ITargeting<object>.ChooseAsync()
		{
			return await base.ChooseAsync();
		}
	}

	class BooleanTargeting<TResult> : TargetingComposer<bool[], TResult>, ITargeting<object>
	{
		public BooleanTargeting(ITargetChooser<bool[], TResult> chooser)
			: base(new BooleanRangeProvider(), chooser)
		{
		}

		async Task<object> ITargeting<object>.ChooseAsync()
		{
			return await base.ChooseAsync();
		}
	}

	class ObjectTargeting<TResult> : TargetingComposer<object[], TResult>
	{
		public ObjectTargeting(ITargetChooser<IEnumerable<object>, TResult> chooser)
			: base(new ObjectRangeProvider(), chooser)
		{
		}
	}

	// 可能だが、あまり意味は無いかも
	// また、エンティティの型でも選択方式でも両方とも継承を用いることはできず、どうしてもインターフェースでやることになる
	class SingleTargeting<TEntity> : TargetingComposer<TEntity[], TEntity>
	{
		public SingleTargeting(IRangeProvider<TEntity[]> range)
			: base(range, new SingleTargetChooser<TEntity>())
		{
		}
	}
}
