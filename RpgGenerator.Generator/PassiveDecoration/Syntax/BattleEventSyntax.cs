using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Syntax
{
	public class BattleEventSyntax
	{
		public TypeName TypeName { get; set; }

		public BattleEventSyntax(TypeName typeName)
		{
			TypeName = typeName;
		}

		public static async Task<BattleEventSyntax[]> FromParseAsync(ClassDeclarationSyntax declaration, string eventName, Document document, CancellationToken ct)
		{
			async Task<INamedTypeSymbol?> GetSymbol(FieldDeclarationSyntax field)
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
				return symbol
					.OfType<INamedTypeSymbol>()
					.FirstOrDefault(x => x.Interfaces.Any(y => y.Name == eventName));
			}

			var symbolTasks = declaration.Members
				.OfType<FieldDeclarationSyntax>()
				.Select(GetSymbol);

			return (await Task.WhenAll(symbolTasks))
				.FilterNull()
				.Select(x => new BattleEventSyntax(Utilities.TypeName.FromSymbol(x)))
				.ToArray();
		}
	}
}