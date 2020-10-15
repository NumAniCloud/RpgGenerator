using System;
using System.Collections.Generic;
using System.Text;
using RpgGenerator.Generator.PassiveDecoration.Syntax;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class PassiveDecoratorSemantics
	{
		public string DecorationName { get; }
		public PassiveHookSemantics[] Hooks { get; }
		public PassiveModifierSemantics[] Modifiers { get; }

		public PassiveDecoratorSemantics(string decorationName, PassiveHookSemantics[] hooks, PassiveModifierSemantics[] modifiers)
		{
			DecorationName = decorationName;
			Hooks = hooks;
			Modifiers = modifiers;
		}

		public static PassiveDecoratorSemantics FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return new PassiveDecoratorSemantics(
				syntax.DecorationName,
				PassiveHookSemantics.FromDeclaration(syntax),
				PassiveModifierSemantics.FromDeclaration(syntax));
		}
	}
}
