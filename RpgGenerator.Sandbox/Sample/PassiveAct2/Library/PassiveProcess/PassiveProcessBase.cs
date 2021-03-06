﻿using System.Collections.Generic;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction;
using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcessFunction;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProcess
{
	public abstract class PassiveProcessBase<TDomain> : IPassiveProcess<TDomain>
	{
		private IPassiveProcessFunction<TDomain>[]? _leadingFunctions;
		private IPassiveProcessFunction<TDomain>[]? _followingFunctions;
		private IPassiveModifierFunction<TDomain>[]? _modifiers;

		public IEnumerable<IPassiveProcessFunction<TDomain>> LeadingProcesses => _leadingFunctions ??= LoadLeadingProcesses();
		public IEnumerable<IPassiveProcessFunction<TDomain>> FollowingProcesses => _followingFunctions ??= LoadFollowingProcesses();
		public IEnumerable<IPassiveModifierFunction<TDomain>> Modifiers => _modifiers ??= LoadModifiers();

		protected abstract IPassiveModifierFunction<TDomain>[] LoadModifiers();
		protected abstract IPassiveProcessFunction<TDomain>[] LoadLeadingProcesses();
		protected abstract IPassiveProcessFunction<TDomain>[] LoadFollowingProcesses();
	}
}
