using System;

namespace RpgGenerator.Basic
{
	[AttributeUsage(AttributeTargets.Class)]
	public class PassiveDecorationAttribute : Attribute
	{
		public string DomainContextTypeName { get; }
		public string EventTypeName { get; }

		public PassiveDecorationAttribute(string domainContextTypeName, string eventTypeName)
		{
			DomainContextTypeName = domainContextTypeName;
			EventTypeName = eventTypeName;
		}
	}
}
