using System.Threading.Tasks;
using RpgGenerator.Basic.Active;

namespace RpgGenerator.Sandbox.Sample.Active
{
	abstract class ActiveBehavior<TTarget>
	{
		public abstract ITargeting<TTarget> Targeting { get; }
		public abstract Task RunAsync(object context);
	}
}
