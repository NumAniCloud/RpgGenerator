using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Syntax
{
	public class PassiveDeclarationSyntax
	{
		public string DecorationName { get; }
		public BattleEventSyntax[] BattleEvents { get; }
		public TokenAttributeSyntax[] Parameters { get; }
		public TypeName SourceType { get; set; }

		public PassiveDeclarationSyntax(string decorationName, BattleEventSyntax[] battleEvents, TokenAttributeSyntax[] parameters, TypeName sourceType)
		{
			BattleEvents = battleEvents;
			Parameters = parameters;
			SourceType = sourceType;
			DecorationName = decorationName;
		}

		public static async Task<PassiveDeclarationSyntax> FromParseAsync(ClassDeclarationSyntax declaration, Document document, CancellationToken ct)
		{
			var ns = declaration.Parent is NamespaceDeclarationSyntax nsds
				? (nsds.Name is QualifiedNameSyntax qns ? qns.ToString() : throw new Exception())
				: throw new Exception();
			var symbol = await SymbolFinder.FindSourceDeclarationsAsync(
				document.Project,
				declaration.Identifier.ValueText,
				false,
				ct);
			var sourceType = symbol.OfType<INamedTypeSymbol>()
				.FirstOrDefault(x => x.GetFullNameSpace() == ns);

			return new PassiveDeclarationSyntax(
				Regex.Replace(declaration.Identifier.ValueText, "Settings$", ""),
				await BattleEventSyntax.FromParseAsync(declaration, document, ct),
				await TokenAttributeSyntax.FromParseAsync(declaration, document, ct),
				TypeName.FromSymbol(sourceType));
		}
	}
}
