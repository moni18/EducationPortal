using System;
using System.Linq;
using Common.Attributes;
using Common.Extensions;
using Data.Domain.Hospital;
using Data.Enums;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Identity;

namespace Data.Seed
{
    public static class DataSeeder
    {
        public static void Seed(HospitalDbContext context)
        {
            using var tran = context.Database.BeginTransaction();

            if (!context.Roles.Any())
            {
                foreach (RolesEnum role in (RolesEnum[])Enum.GetValues(typeof(RolesEnum)))
                {
                    context.Roles.Add(new HospitalRole
                    {
                        Name = role.ToString(),
                        NormalizedName = role.ToString().ToUpper(),
                        IsRegister = role.GetAttribute<EnumInfoAttribute>().IsRegister
                    });
                }

                context.SaveChanges();
            }

            if (!context.Hospitals.Any())
            {
                context.Hospitals.AddRange(new[]
                {
                    new Hospital
                    {
                        Name = "Калкаман",
                        Address = "проспект Аль Фараби 35",
                        Doctors = new[]
                        {
                            new Doctor
                            {
                                UserName = "Isa.Ahunbaev",
                                LastName = "Ahunbaev",
                                FirstName = "Isa",
                                CabinetNumber = 34,
                                Receptions = new[]
                                {
                                    new Reception
                                    {
                                        DateTime = new DateTime(2022, 3, 4, 12, 0, 0),
                                        /*Patient = new IdentityUser
                                        {
                                            LastName = "Aidarkulov",
                                            FirstName = "Nursultan",
                                            UserName = "Nursultan.Aidarkulov"
                                        }*/
                                        Patient = new IdentityUser("Nursultan.Aidarkulov")
                                    },
                                    new Reception
                                    {
                                        DateTime = new DateTime(2022, 3, 5, 15, 0, 0),
                                        /*Patient = new Patient
                                        {
                                            LastName = "Petrov",
                                            FirstName = "Vasilii",
                                            UserName = "Vasilii.Petrov"
                                        }*/
                                        Patient = new IdentityUser("Vasilii.Petrov")
                                    }
                                }
                            },
                            new Doctor
                            {
                                UserName = "Alymkadyr.Beishenaliev",
                                LastName = "Alymkadyr",
                                FirstName = "Beishenaliev",
                                CabinetNumber = 25,
                                Receptions = new[]
                                {
                                    new Reception
                                    {
                                        DateTime = new DateTime(2022, 3, 4, 11, 0, 0),
                                        /*Patient = new Patient
                                        {
                                            LastName = "Ivanov",
                                            FirstName = "Petr",
                                            UserName = "Petr.Ivanov"
                                        }*/
                                        Patient = new IdentityUser("Petr.Ivanov")
                                    }
                                }
                            }
                        }
                    },
                    new Hospital
                    {
                        Name = "Центр семейной медецины",
                        Address = "ул. Центральная 345",
                        Doctors = new[]
                        {
                            new Doctor
                            {
                                UserName = "Sabyrbek.Jumabekov",
                                LastName = "Сабырбек",
                                FirstName = "Джумабеков",
                                CabinetNumber = 1,
                                Receptions = new[]
                                {
                                    new Reception
                                    {
                                        DateTime = new DateTime(2022, 3, 5, 12, 0, 0),
                                        /*Patient = new Patient
                                        {
                                            LastName = "Alex",
                                            FirstName = "Ivan",
                                            UserName = "Ivan.Alex"
                                        }*/
                                        Patient = new IdentityUser("Ivan.Alex")
                                    }
                                }
                            }
                        }
                    }
                });

                context.SaveChanges();
            }

            tran.Commit();
        }
    }
}
