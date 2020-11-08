using System.Collections.Generic;
using RpgGenerator.Basic.Passive.PassiveModifierFunction;
using RpgGenerator.Basic.Passive.PassiveProcessFunction;

namespace RpgGenerator.Basic.Passive.PassiveProcess
{
	public interface IPassiveProcess<TDomain>
	{
		public IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses { get; }
		public IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses { get; }
		public IEnumerable<IPassiveModifierFunction<TDomain>> Modifiers { get; }
	}
}
