using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Syntax
{
	public class PhaseGroupSyntax
	{
		public TypeName InterfaceName { get; }
		public PhaseMethodSyntax[] Methods { get; }

		public PhaseGroupSyntax(TypeName interfaceName,
			PhaseMethodSyntax[] methods)
		{
			InterfaceName = interfaceName;
			Methods = methods;
		}

		public static async Task<PhaseGroupSyntax> FromDeclarationAsync(InterfaceDeclarationSyntax syntax, Document document,
			CancellationToken ct)
		{
			async Task<INamedTypeSymbol> GetSymbol()
			{
				var ns = syntax.Parent is NamespaceDeclarationSyntax nsds
					? (nsds.Name is QualifiedNameSyntax qns ? qns.ToString() : throw new Exception())
					: throw new Exception();

				var symbols = await SymbolFinder.FindSourceDeclarationsAsync(
					document.Project,
					syntax.Identifier.ValueText,
					false,
					ct);

				var namedTypeSymbol = symbols.OfType<INamedTypeSymbol>()
					.First(x => x.GetFullNameSpace() == ns);
				return namedTypeSymbol;
			}

			var symbol = await GetSymbol();
			return new PhaseGroupSyntax(TypeName.FromSymbol(symbol), 
				PhaseMethodSyntax.FromPhaseGroupType(symbol).ToArray());
		}
	}
}
