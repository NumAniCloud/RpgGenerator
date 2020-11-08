using RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveProperty;

namespace RpgGenerator.Sandbox.Sample.PassiveAct2.Library.PassiveModifierFunction
{
	public interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, IPassiveProperty<TDomain> self);
	}
}