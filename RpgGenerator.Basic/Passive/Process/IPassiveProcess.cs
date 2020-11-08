using System.Collections.Generic;
using RpgGenerator.Basic.Passive.Hooker;
using RpgGenerator.Basic.Passive.Modifier;

namespace RpgGenerator.Basic.Passive.Process
{
	public interface IPassiveProcess<TDomain>
	{
		IEnumerable<IPassiveHooker<TDomain>> LeadingProcesses { get; }
		IEnumerable<IPassiveHooker<TDomain>> FollowingProcesses { get; }
		IEnumerable<IPassiveModifier<TDomain>> Modifiers { get; }
	}
}
