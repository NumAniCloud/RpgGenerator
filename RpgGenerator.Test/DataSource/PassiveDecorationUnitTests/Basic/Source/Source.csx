using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RpgGenerator.Test.DataSource.PassiveDecorationUnitTests.Basic.Source
{
	[PassiveDecorationAttribute]
	public class PassiveDecorationSettings
	{
		public Attributes Attributes;
		public DamageEvent DamageEvent;
	}

	public class Attributes
	{
		public int Attack { get; set; }
		public int Defence { get; set; }
	}

	public class DamageEvent : IBattleEvent
	{
		public async Task RunAsync(IBattleEventHandler handler)
		{
		}
	}
}
