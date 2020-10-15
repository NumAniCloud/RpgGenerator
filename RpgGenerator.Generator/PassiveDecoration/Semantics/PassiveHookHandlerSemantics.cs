using RpgGenerator.Generator.PassiveDecoration.Syntax;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class PassiveHookHandlerSemantics
	{
		public string DecoratorName { get; set; }
		public BattleEventSemantics[] BattleEvents { get; set; }
		
		public PassiveHookHandlerSemantics(string decoratorName, BattleEventSemantics[] battleEvents)
		{
			DecoratorName = decoratorName;
			BattleEvents = battleEvents;
		}

		public static PassiveHookHandlerSemantics FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return new PassiveHookHandlerSemantics("",
				BattleEventSemantics.FromSyntax(syntax));
		}
	}
}