using RpgGenerator.Basic.Passive.PassiveProperty;

namespace RpgGenerator.Basic.Passive.PassiveModifierFunction
{
	public interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, IPassiveProperty<TDomain> self);
	}
}