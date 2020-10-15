using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class SemanticsRoot
	{
		public TypeName SourceType { get; }
		public string ProviderName { get; }
		public string DecorationName { get; }
		public PassiveDecoratorSemantics Decorator { get; }
		public PassiveHookHandlerSemantics Handler { get; }
		public FinalAttributeSemantics[] FinalAttribute { get; }

		public SemanticsRoot(PassiveDecoratorSemantics decorator, PassiveHookHandlerSemantics handler, FinalAttributeSemantics[] finalAttribute, TypeName sourceType, string providerName, string decorationName)
		{
			Decorator = decorator;
			Handler = handler;
			FinalAttribute = finalAttribute;
			SourceType = sourceType;
			ProviderName = providerName;
			DecorationName = decorationName;
		}

		public string[] GetImports()
		{
			return FinalAttribute.Select(x => x.AttributeTypeName.FullNamespace)
				.Concat(Decorator.GetImports())
				.Except(new []{ SourceType.FullNamespace })
				.Distinct()
				.ToArray();
		}

		public static SemanticsRoot FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return new SemanticsRoot(
				PassiveDecoratorSemantics.FromSyntax(syntax),
				PassiveHookHandlerSemantics.FromSyntax(syntax),
				FinalAttributeSemantics.FromSyntax(syntax),
				syntax.SourceType,
				$"I{syntax.DecorationName}Provider",
				syntax.DecorationName);
		}
	}
}
