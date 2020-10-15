using System;
using Microsoft.CodeAnalysis;
using RpgGenerator.Utilities;

namespace RpgGenerator.Syntax
{
	public class ResultTypeSyntax
	{
		public TypeName Name { get; }

		public ResultTypeSyntax(TypeName name)
		{
			Name = name;
		}

		public static ResultTypeSyntax FromMethod(IMethodSymbol method)
		{
			// 戻り値が Task<PhaseResult<T>> であるという前提
			if (method.ReturnType is INamedTypeSymbol nts && nts.Name == "Task")
			{
				if (nts.TypeArguments.Length == 1 && nts.TypeArguments[0] is INamedTypeSymbol nts2 && nts2.Name == "PhaseResult")
				{
					if (nts2.TypeArguments.Length == 1 && nts2.TypeArguments[0] is INamedTypeSymbol nts3)
					{
						return new ResultTypeSyntax(TypeName.FromSymbol(nts3));
					}
				}
			}

			throw new Exception();
		}
	}
}
