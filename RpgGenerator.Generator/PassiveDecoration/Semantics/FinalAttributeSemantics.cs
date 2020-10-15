using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class FinalAttributeSemantics
	{
		public TypeName AttributeTypeName { get; }
		public FinalAttributeMemberSemantics[] Members { get; }

		public FinalAttributeSemantics(TypeName attributeTypeName, FinalAttributeMemberSemantics[] members)
		{
			AttributeTypeName = attributeTypeName;
			Members = members;
		}

		public static FinalAttributeSemantics[] FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return syntax.Parameters
				.Select(x => new FinalAttributeSemantics(x.TypeName,
					FinalAttributeMemberSemantics.FromSyntax(x)))
				.ToArray();
		}
	}
}