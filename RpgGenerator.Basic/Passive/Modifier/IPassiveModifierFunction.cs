using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Modifier
{
	public interface IPassiveModifierFunction<TDomain>
	{
		TData Modify<TData>(TData source, IPassiveProperty<TDomain> self);
	}
}