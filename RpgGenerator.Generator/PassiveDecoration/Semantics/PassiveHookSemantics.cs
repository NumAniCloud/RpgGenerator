using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class PassiveHookSemantics
	{
		public TypeName EventTypeName { get; }

		public PassiveHookSemantics(TypeName eventTypeName)
		{
			EventTypeName = eventTypeName;
		}

		public static PassiveHookSemantics[] FromDeclaration(PassiveDeclarationSyntax syntax)
		{
			return syntax.BattleEvents
				.Select(x => new PassiveHookSemantics(x.TypeName))
				.ToArray();
		}
	}
}