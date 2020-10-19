using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpgGenerator.Basic.Active;

namespace RpgGenerator.Sandbox.Sample.Active
{
	class AttackActiveBehavior : ActiveBehavior<int[]>
	{
		public override ITargeting<int[]> Targeting { get; } = new SingleInteger();

		public override async Task RunAsync(object context)
		{
		}
	}
}
