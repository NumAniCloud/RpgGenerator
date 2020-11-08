using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcessFunction;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library
{
	public interface IPassiveProcess<TDomain>
	{
		public IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses { get; }
		public IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses { get; }
		public IEnumerable<IPassiveModifierFunction<TDomain>> Modifiers { get; }
	}
}
