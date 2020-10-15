using System;

namespace RpgGenerator.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var logic = new Gen.BattlePhaseLogic();
			var handler = new Gen.BattlePhasesHandler(logic);
			var result = handler.SkillSelection(2).Result;
			Console.WriteLine(result.UnWrapOrDefault());
		}
	}
}
