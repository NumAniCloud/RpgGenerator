using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RpgGenerator.Generator.PassiveDecoration.Syntax
{
	public class AttributeMemberSyntax
	{
		public string TypeName { get; }
		public string PropertyName { get; }

		public AttributeMemberSyntax(string typeName, string propertyName)
		{
			TypeName = typeName;
			PropertyName = propertyName;
		}

		public static AttributeMemberSyntax[] FromAttributeType(INamedTypeSymbol namedTypeSymbol)
		{
			return namedTypeSymbol.GetMembers()
				.OfType<IPropertySymbol>()
				.Where(x => !x.Type.Interfaces.Any(y => y.Name == "IBattleEvent"))
				.Select(x =>
					new AttributeMemberSyntax(x.Type is INamedTypeSymbol nts ? Utilities.TypeName.FromSymbol(nts).Name : throw new Exception(),
						x.Name))
				.ToArray();
		}
	}
}