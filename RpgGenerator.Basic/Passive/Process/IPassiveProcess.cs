using System.Collections.Generic;
using RpgGenerator.Basic.Passive.Hooker;
using RpgGenerator.Basic.Passive.Modifier;

namespace RpgGenerator.Basic.Passive.Process
{
	public interface IPassiveProcess<TDomain>
	{
		IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses { get; }
		IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses { get; }
		IEnumerable<IPassiveModifierFunction<TDomain>> Modifiers { get; }
	}
}
