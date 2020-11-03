using System.Linq;
using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class SemanticsRoot
	{
		public TypeName SourceType { get; }
		public string DecorationName { get; }
		public string DomainContextName { get; }
		public PassiveDecoratorSemantics Decorator { get; }
		public FinalAttributeSemantics[] FinalAttribute { get; }

		public SemanticsRoot(PassiveDecoratorSemantics decorator,
			FinalAttributeSemantics[] finalAttribute,
			TypeName sourceType,
			string decorationName,
			string domainContextName)
		{
			Decorator = decorator;
			FinalAttribute = finalAttribute;
			SourceType = sourceType;
			DecorationName = decorationName;
			DomainContextName = domainContextName;
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
				FinalAttributeSemantics.FromSyntax(syntax),
				syntax.SourceType,
				syntax.DecorationName,
				syntax.DomainContextName);
		}
	}
}
