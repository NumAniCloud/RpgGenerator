using System;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Generator.PassiveDecoration.Semantics;

namespace RpgGenerator.Generator.PassiveDecoration.Template
{
	partial class DomainContextTemplate
	{
		public SemanticsRoot Root { get; }

		public DomainContextTemplate(SemanticsRoot root)
		{
			Root = root;
		}
	}
}
