using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class PassiveModifierSemantics
	{
		public string AttributeType { get; }
		public string AttributeName { get; }

		public PassiveModifierSemantics(string attributeType, string attributeName)
		{
			AttributeType = attributeType;
			AttributeName = attributeName;
		}

		public static PassiveModifierSemantics[] FromDeclaration(PassiveDeclarationSyntax syntax)
		{
			return syntax.Parameters
				.SelectMany(x => x.Members)
				.Select(x => new PassiveModifierSemantics(x.TypeName, x.PropertyName))
				.ToArray();
		}
	}
}