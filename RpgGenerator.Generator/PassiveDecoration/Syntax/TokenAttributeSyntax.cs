using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Syntax
{
	public class TokenAttributeSyntax
	{
		public TypeName TypeName { get; }
		public AttributeMemberSyntax[] Members { get; }

		public TokenAttributeSyntax(TypeName typeName, AttributeMemberSyntax[] members)
		{
			TypeName = typeName;
			Members = members;
		}

		public static async Task<TokenAttributeSyntax[]> FromParseAsync(ClassDeclarationSyntax declaration, Document document, CancellationToken ct)
		{
			async Task<INamedTypeSymbol?> GetClassAsync(FieldDeclarationSyntax field)
			{
				if (field.Declaration.Variables.Count != 1)
				{
					return null;
				}

				var fieldName = field.Declaration.Type.ToString();
				var symbol = await SymbolFinder.FindSourceDeclarationsAsync(
					document.Project,
					fieldName,
					false,
					ct);

				return symbol.OfType<INamedTypeSymbol>()
					.FirstOrDefault(x => !x.Interfaces.Any(y => y.Name == "IBattleEvent"));
			}

			var symbols = declaration.Members
				.OfType<FieldDeclarationSyntax>()
				.Select(GetClassAsync);

			return (await Task.WhenAll(symbols))
				.FilterNull()
				.Select(x => new TokenAttributeSyntax(Utilities.TypeName.FromSymbol(x),
					AttributeMemberSyntax.FromAttributeType(x)))
				.ToArray();
		}
	}
}