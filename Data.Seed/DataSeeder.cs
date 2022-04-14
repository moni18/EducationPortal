using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Attributes;
using Common.Extensions;
using Data.Entities.Domain.Hospital;
using Data.Entities.Domain.Identity;
using Data.Entities.Enums;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Identity;

namespace Data.Seed
{
    public static class DataSeeder
    {
        public static void Seed(HospitalDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            using var tran = context.Database.BeginTransaction();

            if (!context.Roles.Any())
            {
                foreach (RolesEnum role in (RolesEnum[])Enum.GetValues(typeof(RolesEnum)))
                {
                    context.Roles.Add(new ApplicationRole
                    {
                        Name = role.ToString(),
                        NormalizedName = role.ToString().ToUpper(),
                        IsRegister = role.GetAttribute<EnumInfoAttribute>().IsRegister
                    });
                }

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var adminUser = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "REwq$#21").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, RolesEnum.Admin.ToString()).ConfigureAwait(false);
                }
            }

            if (!context.Hospitals.Any())
            {
                context.Hospitals.AddRange(new[]
                {
                    new Hospital
                    {
                        Name = "Калкаман",
                        Address = "проспект Аль Фараби 35"
                    },
                    new Hospital
                    {
                        Name = "Центр семейной медецины",
                        Address = "ул. Центральная 345"
                    },
                    new Hospital
                    {
                        Name = "Институт кардиологии",
                        Address = "ул. Набережная 5"
                    },
                    new Hospital
                    {
                        Name = "Пункт травмотологии",
                        Address = "ул. Койбагарова 32"
                    }
                });

                context.SaveChanges();
            }

            /*if (!context.Hospitals.Any())
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
                                        Patient = new ApplicationUser
                                        {
                                            LastName = "Aidarkulov",
                                            FirstName = "Nursultan",
                                        }
                                    },
                                    new Reception
                                    {
                                        DateTime = new DateTime(2022, 3, 5, 15, 0, 0),
                                        Patient = new ApplicationUser
                                        {
                                            LastName = "Petrov",
                                            FirstName = "Vasilii",
                                        }
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
                                        Patient = new Patient
                                        {
                                            LastName = "Ivanov",
                                            FirstName = "Petr",
                                        }
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
                                        Patient = new ApplicationUser
                                        {
                                            LastName = "Alex",
                                            FirstName = "Ivan",
                                        }
                                    }
                                }
                            }
                        }
                    }
                });

                context.SaveChanges();
            }*/

            tran.Commit();
        }
    }
}
