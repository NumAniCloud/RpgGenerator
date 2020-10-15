using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Syntax
{
	public class AdditionalParameterSyntax
	{
		public TypeName TypeName { get; }
		public string Name { get; }

		public AdditionalParameterSyntax(TypeName typeName, string name)
		{
			TypeName = typeName;
			Name = name;
		}

		public static IEnumerable<AdditionalParameterSyntax> FromMethod(IMethodSymbol method)
		{
			foreach (var parameter in method.Parameters)
			{
				var isContext = parameter.GetAttributes()
					.Any(x => x.AttributeClass.Name == "PhaseContextAttribute");
				if (!isContext)
				{
					yield return new AdditionalParameterSyntax(TypeName.FromSymbol(parameter.Type), parameter.Name);
				}
			}
		}
	}
}
