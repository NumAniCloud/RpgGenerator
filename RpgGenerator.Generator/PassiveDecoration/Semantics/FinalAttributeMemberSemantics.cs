using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class FinalAttributeMemberSemantics
	{
		public string TypeName { get; }
		public string PropertyName { get; }

		public FinalAttributeMemberSemantics(string typeName, string propertyName)
		{
			TypeName = typeName;
			PropertyName = propertyName;
		}

		public static FinalAttributeMemberSemantics[] FromSyntax(TokenAttributeSyntax tokenAttributeSyntax)
		{
			return tokenAttributeSyntax.Members
				.Select(x => new FinalAttributeMemberSemantics(x.TypeName, x.PropertyName))
				.ToArray();
		}
	}
}