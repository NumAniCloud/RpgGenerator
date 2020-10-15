using System.Linq;
using Microsoft.CodeAnalysis;
using RpgGenerator.Utilities;

namespace RpgGenerator.Syntax
{
	public class ContextParameterSyntax
	{
		public TypeName TypeName { get; }
		public string Name { get; }

		public ContextParameterSyntax(TypeName typeName, string name)
		{
			TypeName = typeName;
			Name = name;
		}

		public static ContextParameterSyntax? FromMethod(IMethodSymbol method)
		{
			foreach (var parameter in method.Parameters)
			{
				var isContext = parameter.GetAttributes()
					.Any(x => x.AttributeClass.Name == "PhaseContextAttribute");
				if (isContext)
				{
					return new ContextParameterSyntax(Utilities.TypeName.FromSymbol(parameter.Type), parameter.Name);
				}
			}

			return null;
		}
	}
}
