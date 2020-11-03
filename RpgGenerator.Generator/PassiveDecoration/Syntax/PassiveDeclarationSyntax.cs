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
		public string DomainContextName { get; }
		public string EventTypeName { get; }

		public PassiveDeclarationSyntax(string decorationName,
			BattleEventSyntax[] battleEvents,
			TokenAttributeSyntax[] parameters,
			TypeName sourceType,
			string domainContextName,
			string eventTypeName)
		{
			BattleEvents = battleEvents;
			Parameters = parameters;
			SourceType = sourceType;
			DomainContextName = domainContextName;
			EventTypeName = eventTypeName;
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

			var attr = sourceType.GetAttributes()
				.First(x => x.AttributeClass.Name == "PassiveDecorationAttribute");

			if (!(attr.ConstructorArguments[0].Value is string domainName))
			{
				throw new Exception();
			}

			if (!(attr.ConstructorArguments[1].Value is string eventName))
			{
				throw new Exception();
			}

			return new PassiveDeclarationSyntax(
				Regex.Replace(declaration.Identifier.ValueText, "Settings$", ""),
				await BattleEventSyntax.FromParseAsync(declaration, eventName, document, ct),
				await TokenAttributeSyntax.FromParseAsync(declaration, document, ct),
				TypeName.FromSymbol(sourceType),
				domainName,
				eventName);
		}
	}
}
