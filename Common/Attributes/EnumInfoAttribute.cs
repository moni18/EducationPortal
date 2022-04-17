using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumInfoAttribute : Attribute
    {
        public bool IsRegister { get; set; }
    }
}
