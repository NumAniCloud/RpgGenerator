using RpgGenerator.Generator.PhaseSystem.Analyzer;

namespace RpgGenerator.Generator.PhaseSystem.Template
{
	public partial class PhaseTemplate
	{
		public AnalyzerRoot Root { get; }

		public PhaseTemplate(AnalyzerRoot root)
		{
			Root = root;
		}
	}
}
