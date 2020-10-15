using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using RpgGenerator.Generation.Analyzer;
using RpgGenerator.Syntax;
using RpgGenerator.Utilities;
using Xunit;

namespace RpgGenerator.Test.SimpleTests
{
	public class ContextTypeAnalyzerTest
	{
		public static PhaseGroupSyntax GetSamplePhaseGroupSyntax()
		{
			return new PhaseGroupSyntax(
				new TypeName("PlaceHolderNs", "IBattlePhases", Accessibility.Internal),
				new PhaseMethodSyntax[]
				{
					new PhaseMethodSyntax("Phase1",
						new ResultTypeSyntax(new TypeName("PlaceHolderNs", "Result", Accessibility.Public)),
						null,
						new AdditionalParameterSyntax[]
						{
							new AdditionalParameterSyntax(
								new TypeName("System", "int", Accessibility.Public), "x"),
							new AdditionalParameterSyntax(
								new TypeName("System", "int", Accessibility.Public), "y"),
						}),
					new PhaseMethodSyntax("Phase2",
						new ResultTypeSyntax(new TypeName("PlaceHolderNs", "Result", Accessibility.Public)),
						new ContextParameterSyntax(
							new TypeName("PlaceHolderNs", "Phase1Phase", Accessibility.Internal), "phase"),
						new AdditionalParameterSyntax[]
						{
							new AdditionalParameterSyntax(
								new TypeName("System", "int", Accessibility.Public), "z"), 
						}), 
				});
		}

		[Fact]
		public void ContextTypeAnalyzerを生成できる()
		{
			var contexts = ContextTypeAnalyzer.FromPhaseGroup(GetSamplePhaseGroupSyntax()).ToArray();
			Assert.Equal(2, contexts.Length);

			Assert.Equal("Phase1Phase", contexts[0].TypeName);
			Assert.Equal(2, contexts[0].ContextProperties.Length);
			Assert.Equal("int", contexts[0].ContextProperties[0].Type.Name);
			Assert.Equal("X", contexts[0].ContextProperties[0].PropertyName);
			Assert.Equal("int", contexts[0].ContextProperties[1].Type.Name);
			Assert.Equal("Y", contexts[0].ContextProperties[1].PropertyName);
			Assert.Null(contexts[0].ContextDelegationProperties);

			Assert.Equal("Phase2Phase", contexts[1].TypeName);
			Assert.Single(contexts[1].ContextProperties);
			Assert.Equal("int", contexts[1].ContextProperties[0].Type.Name);
			Assert.Equal("Z", contexts[1].ContextProperties[0].PropertyName);
			Assert.NotNull(contexts[1].ContextDelegationProperties);
			Assert.Equal("Phase1Phase", contexts[1].ContextDelegationProperties.ContextTypeName);

			var properties = contexts[1].ContextDelegationProperties.Properties;
			Assert.Equal(2, properties.Length);
			Assert.Equal("int", properties[0].Type.Name);
			Assert.Equal("X", properties[0].PropertyName);
			Assert.Equal("int", properties[1].Type.Name);
			Assert.Equal("Y", properties[1].PropertyName);
		}
	}
}
