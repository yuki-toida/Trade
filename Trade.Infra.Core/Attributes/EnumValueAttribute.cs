using System;

namespace Trade.Infra.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public object Value { get; private set; }

        public EnumValueAttribute(object val)
        {
            Value = val;
        }
    }
}
