using RpgGenerator.Generator.PassiveDecoration.Syntax;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PassiveDecoration.Semantics
{
	public class SemanticsRoot
	{
		public TypeName SourceType { get; }
		public PassiveDecoratorSemantics Decorator { get; }
		public PassiveHookHandlerSemantics Handler { get; }
		public FinalAttributeSemantics[] FinalAttribute { get; }

		public SemanticsRoot(PassiveDecoratorSemantics decorator, PassiveHookHandlerSemantics handler, FinalAttributeSemantics[] finalAttribute, TypeName sourceType)
		{
			Decorator = decorator;
			Handler = handler;
			FinalAttribute = finalAttribute;
			SourceType = sourceType;
		}

		public static SemanticsRoot FromSyntax(PassiveDeclarationSyntax syntax)
		{
			return new SemanticsRoot(
				PassiveDecoratorSemantics.FromSyntax(syntax),
				PassiveHookHandlerSemantics.FromSyntax(syntax),
				FinalAttributeSemantics.FromSyntax(syntax),
				syntax.SourceType);
		}
	}
}
