using RpgGenerator.Basic.Passive.Property;

namespace RpgGenerator.Basic.Passive.Modifier
{
	public interface IPassiveModifier<TDomain>
	{
		TData Modify<TData>(TData source, IPassiveProperty<TDomain> self);
	}
}