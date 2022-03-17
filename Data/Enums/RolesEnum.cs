using System;

namespace Data.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumAttribute : Attribute
    {
        public bool IsRegister { get; set; }
    }

    public enum RolesEnum
    {
        [Enum(IsRegister = true)]
        Doctor,
        [Enum(IsRegister = true)]
        Patient,
        [Enum(IsRegister = true)]
        Registrator,
        Admin,
        Reader
    }
}
