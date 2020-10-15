using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using RpgGenerator.Generator.Utilities;

namespace RpgGenerator.Generator.PhaseSystem.Syntax
{
	public class PhaseMethodSyntax
	{
		public string MethodName { get; }
		public ResultTypeSyntax ResultType { get; }
		public ContextParameterSyntax? ContextParameter { get; }
		public AdditionalParameterSyntax[] AdditionalParameters { get; }

		public PhaseMethodSyntax(string methodName,
			ResultTypeSyntax resultType,
			ContextParameterSyntax? contextParameter,
			AdditionalParameterSyntax[] additionalParameters)
		{
			MethodName = methodName;
			ResultType = resultType;
			ContextParameter = contextParameter;
			AdditionalParameters = additionalParameters;
		}

		public static IEnumerable<PhaseMethodSyntax> FromPhaseGroupType(INamedTypeSymbol phaseGroup)
		{
			return phaseGroup.GetMembers().MatchPattern<ISymbol, IMethodSymbol>()
				.Select(method => new PhaseMethodSyntax(
					method.Name,
					ResultTypeSyntax.FromMethod(method),
					ContextParameterSyntax.FromMethod(method), 
					AdditionalParameterSyntax.FromMethod(method).ToArray()));
		}
	}
}
