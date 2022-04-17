using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Common.Attributes;
using Newtonsoft.Json.Serialization;

namespace Data.Enums
{
    public enum RolesEnum
    {
        [EnumInfo(IsRegister = true)]
        Manager,
        [EnumInfo(IsRegister = true)]
        Student,
        //Pupil,
        [EnumInfo(IsRegister = false)]
        Registrator,
        [EnumInfo(IsRegister = false)]
        Admin,
        [EnumInfo(IsRegister = false)]
        Reader

    }
}
