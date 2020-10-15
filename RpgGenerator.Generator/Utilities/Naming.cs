using System.Text.RegularExpressions;

namespace RpgGenerator.Generator.Utilities
{
	static class Naming
	{
		public static string ContextTypeNameFromPhaseMethod(string phaseMethodName)
		{
			return phaseMethodName + "Phase";
		}

		public static string PhaseMethodNameFromContextType(string contextTypeName)
		{
			return Regex.Replace(contextTypeName, "Phase$", "");
		}

		public static string ToUpperCamelCase(this string name)
		{
			return name[0].ToString().ToUpper() + name.Substring(1);
		}
	}
}
