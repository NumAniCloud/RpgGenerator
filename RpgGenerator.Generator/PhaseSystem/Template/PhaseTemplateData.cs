using RpgGenerator.Generation.Analyzer;

namespace RpgGenerator.PhaseSystem.Template
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
