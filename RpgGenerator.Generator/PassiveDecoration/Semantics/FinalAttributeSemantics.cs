using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class FinalAttributeSemantics
	{
		public string AttributeTypeName { get; }
		public FinalAttributeMemberSemantics[] Members { get; }

		public FinalAttributeSemantics(string attributeTypeName, FinalAttributeMemberSemantics[] members)
		{
			AttributeTypeName = attributeTypeName;
			Members = members;
		}

		public static FinalAttributeSemantics[] FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return syntax.Parameters
				.Select(x => new FinalAttributeSemantics("",
					FinalAttributeMemberSemantics.FromSyntax(x)))
				.ToArray();
		}
	}
}