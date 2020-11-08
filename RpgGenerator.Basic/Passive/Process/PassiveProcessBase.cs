using System.Collections.Generic;
using RpgGenerator.Basic.Passive.Hooker;
using RpgGenerator.Basic.Passive.Modifier;

namespace RpgGenerator.Basic.Passive.Process
{
	public abstract class PassiveProcessBase<TDomain> : IPassiveProcess<TDomain>
	{
		private IPassiveHooker<TDomain>[]? _leadingFunctions;
		private IPassiveHooker<TDomain>[]? _followingFunctions;
		private IPassiveModifier<TDomain>[]? _modifiers;

		public IEnumerable<IPassiveHooker<TDomain>> LeadingProcesses => _leadingFunctions ??= LoadLeadingProcesses();
		public IEnumerable<IPassiveHooker<TDomain>> FollowingProcesses => _followingFunctions ??= LoadFollowingProcesses();
		public IEnumerable<IPassiveModifier<TDomain>> Modifiers => _modifiers ??= LoadModifiers();

		protected abstract IPassiveModifier<TDomain>[] LoadModifiers();
		protected abstract IPassiveHooker<TDomain>[] LoadLeadingProcesses();
		protected abstract IPassiveHooker<TDomain>[] LoadFollowingProcesses();
	}
}
