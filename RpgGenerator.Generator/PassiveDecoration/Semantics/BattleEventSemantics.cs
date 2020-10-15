using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class BattleEventSemantics
	{
		public string TypeName { get; }

		public BattleEventSemantics(string typeName)
		{
			TypeName = typeName;
		}

		public static BattleEventSemantics[] FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return syntax.BattleEvents
				.Select(x => new BattleEventSemantics(x.TypeName.Name))
				.ToArray();
		}
	}
}