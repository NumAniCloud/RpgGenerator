using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGenerator.Sandbox
{
	internal sealed class PhaseContext1
	{
		public PhaseContext1(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }
	}

	internal sealed class PhaseContext2
	{
		public PhaseContext2(PhaseContext1 context1, int z)
		{
			Context1 = context1;
			Z = z;
		}

		public PhaseContext1 Context1 { get; }
		public int Z { get; }
		public int X => Context1.X;
		public int Y => Context1.Y;
	}
}
