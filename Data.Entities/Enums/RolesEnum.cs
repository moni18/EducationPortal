using Common.Attributes;

namespace Data.Entities.Enums
{
    public enum RolesEnum
    {
        [EnumInfo(IsRegister = true)]
        Doctor,
        [EnumInfo(IsRegister = true)]
        Patient,
        [EnumInfo(IsRegister = false)]
        Registrator,
        [EnumInfo(IsRegister = false)]
        Admin,
        [EnumInfo(IsRegister = false)]
        Reader
    }
}
