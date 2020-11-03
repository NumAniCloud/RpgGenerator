using System;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Generator.PassiveDecoration.Semantics;

namespace RpgGenerator.Generator.PassiveDecoration.Template
{
	partial class IBattleEventTemplate
	{
		public SemanticsRoot Root { get; }

		public IBattleEventTemplate(SemanticsRoot root)
		{
			Root = root;
		}
	}
}
