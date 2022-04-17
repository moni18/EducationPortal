using System;
using System.Linq;
using Common.Attributes;
using Common.Extensions;
using Data.Domain.Education;
using Data.Domain.Identity;
using Data.Enums;
using DataAccessLayer.Contexts;

namespace Data.Seed
{
    public static class DataSeeder
    {
        public static void Seed(EducationDbContext context)
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
            if (!context.Universities.Any())
            {
                context.Universities.AddRange(new[]
                {
                    new University
                    {
                        Name = "Kazakh National University",
                        Address = "Al-Farabi 71",
                        InstitutionType =InstitutionType.University
                    },
                    new University
                    {
                        Name = "University of International Business",
                        Address = "8A Abay ave",
                        InstitutionType =InstitutionType.University
                    },
                    new University
                    {
                        Name = "Satbayev University",
                        Address = "22 Satbayev Str",
                        InstitutionType =InstitutionType.University
                    },
                    new School
                    {
                        Name = "Gymnasium school No.86",
                        Address = "6 microregion, building 63",
                        InstitutionType =InstitutionType.School
                    },
                    new School
                    {
                        Name = "Primary School No.72",
                        Address = "16 Suleimenova St.",
                        InstitutionType =InstitutionType.School
                    },
                    new School
                    {
                    Name = "Gymnasium school No.86",
                    Address = "6 microregion, building 63",
                    InstitutionType =InstitutionType.School,
                    }
                });

                context.SaveChanges();
            }
          
            #region Universities and Schools
            /*if (!context.Universities.Any())
           {
               context.Universities.AddRange(new[]
               {
                   new University
               {
                   Name = "Kazakh National University",
                   Address = "Al-Farabi 71",
                   InstitutionType =InstitutionType.University,
                   Manager = new Manager
                   {
                       UserName = "tuimebayev.zhanseit",
                       FirstName = "Zhanseit",
                       LastName = "Tuimebayev"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                       UserName = "assem.narova",
                       LastName = "Assem",
                       FirstName = "Narova",
                       },
                       new Student
                       {
                           UserName = "murat.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Murat",
                       },
                       new Student
                       {
                           UserName = "zhanat.sharipov",
                           LastName = "Sharipov",
                           FirstName = "Zhanat",
                       },
                       new Student
                       {
                           UserName = "marat.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Marat",
                       },
                       new Student
                       {
                           UserName = "semyon.aidanov",
                           LastName = "Aidanov",
                           FirstName = "Semyon",
                       },
                       new Student
                       {
                           UserName = "anna.vassilieva",
                           LastName = "Vassilieva",
                           FirstName = "Anna",
                       }
                   }
               },
                   new University
               {
                   Name = "University of International Business",
                   Address = "8A Abay ave",
                   InstitutionType =InstitutionType.University,
                   Manager = new Manager
                   {
                       UserName = "galymbek.seralin",
                       FirstName = "Galymbek",
                       LastName = "Seralin"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                           UserName = "zhanna.karimova",
                           LastName = "Karimova",
                           FirstName = "Zhanna",
                       },
                       new Student
                       {
                           UserName = "akhmet.mailin",
                           LastName = "Mailin",
                           FirstName = "Akhmet",
                       },
                       new Student
                       {
                           UserName = "aidyn.zhaparov",
                           LastName = "Zhaparov",
                           FirstName = "Aidyn",
                       },
                       new Student
                       {
                           UserName = "adlet.ryspayev",
                           LastName = "Ryspayev",
                           FirstName = "Adlet",
                       },
                       new Student
                       {
                           UserName = "semyon.sidorov",
                           LastName = "Sidorov",
                           FirstName = "Semyon",
                       },
                       new Student
                       {
                           UserName = "anna.moroz",
                           LastName = "Moroz",
                           FirstName = "Anna",
                       }
                   }
               },
                   new University
               {
                   Name = "Satbayev University",
                   Address = "22 Satbayev Str",
                   InstitutionType =InstitutionType.University,
                   Manager = new Manager
                   {
                       UserName = "meiram.begentayev",
                       FirstName = "Meiram",
                       LastName = "Begentayev"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                           UserName = "aliya.kanat",
                           LastName = "Kanat",
                           FirstName = "Aliya",
                       },
                       new Student
                       {
                           UserName = "askhat.mamyr",
                           LastName = "Mamyr",
                           FirstName = "Askhat",
                       },
                       new Student
                       {
                           UserName = "aidyn.zhaparov",
                           LastName = "Zhaparov",
                           FirstName = "Aidyn",
                       },
                       new Student
                       {
                           UserName = "eugeniy.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Eugeniy",
                       },
                       new Student
                       {
                           UserName = "ivan.mrych",
                           LastName = "Mrych",
                           FirstName = "Ivan",
                       },
                       new Student
                       {
                           UserName = "anna.karenina",
                           LastName = "Karenina",
                           FirstName = "Anna",
                       }
                   }
               }
               });

               context.SaveChanges();
           }
           if (!context.Schools.Any())
           {
               context.Schools.AddRange(new[]
               {
                   new School
               {
                   Name = "Primary School No.42",
                   Address = "Aksay-2 microregion, building 33",
                   InstitutionType =InstitutionType.School,
                   Manager = new Manager
                   {
                       UserName = "marat.maratov",
                       FirstName = "Marat",
                       LastName = "Maratov"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                       UserName = "zhanar.aidanova",
                       LastName = "Aidanova",
                       FirstName = "Zhanar",
                       },
                       new Student
                       {
                           UserName = "kanat.sharipov",
                           LastName = "Sharipov",
                           FirstName = "Kanat",
                       },
                       new Student
                       {
                           UserName = "zhanat.makashev",
                           LastName = "Makashev",
                           FirstName = "Zhanat",
                       },
                       new Student
                       {
                           UserName = "marat.aidanov",
                           LastName = "Aidanov",
                           FirstName = "Marat",
                       },
                       new Student
                       {
                           UserName = "semyon.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Semyon",
                       },
                       new Student
                       {
                           UserName = "anna.vassilieva",
                           LastName = "Vassilieva",
                           FirstName = "Anna",
                       }
                   }
               },
                   new School
               {
                   Name = "Primary School No.72",
                   Address = "16 Suleimenova St.",
                   InstitutionType =InstitutionType.School,
                   Manager = new Manager
                   {
                       UserName = "alexandr.ivanov",
                       FirstName = "Alexandr",
                       LastName = "Ivanov"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                           UserName = "zhanar.narova",
                           LastName = "Narova",
                           FirstName = "Zhanar",
                       },
                       new Student
                       {
                           UserName = "kanat.sharipov",
                           LastName = "Sharipov",
                           FirstName = "Kanat",
                       },
                       new Student
                       {
                           UserName = "aidyn.zharov",
                           LastName = "Zharov",
                           FirstName = "Aidyn",
                       },
                       new Student
                       {
                           UserName = "marat.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Marat",
                       },
                       new Student
                       {
                           UserName = "semyon.sidorov",
                           LastName = "Sidorov",
                           FirstName = "Semyon",
                       },
                       new Student
                       {
                           UserName = "anna.moroz",
                           LastName = "Moroz",
                           FirstName = "Anna",
                       }
                   }
               },
                   new School
               {
                   Name = "Gymnasium school No.86",
                   Address = "6 microregion, building 63",
                   InstitutionType =InstitutionType.School,
                   Manager = new Manager
                   {
                       UserName = "zhamilya.edilova",
                       FirstName = "Zhamilya",
                       LastName = "Edilova"
                   },
                   Students = new[]
                   {
                       new Student
                       {
                           UserName = "aliya.kanat",
                           LastName = "Kanat",
                           FirstName = "Aliya",
                       },
                       new Student
                       {
                           UserName = "askhat.mamyr",
                           LastName = "Mamyr",
                           FirstName = "Askhat",
                       },
                       new Student
                       {
                           UserName = "aidyn.zhaparov",
                           LastName = "Zhaparov",
                           FirstName = "Aidyn",
                       },
                       new Student
                       {
                           UserName = "eugeniy.ivanov",
                           LastName = "Ivanov",
                           FirstName = "Eugeniy",
                       },
                       new Student
                       {
                           UserName = "ivan.mrych",
                           LastName = "Mrych",
                           FirstName = "Ivan",
                       },
                       new Student
                       {
                           UserName = "anna.karenina",
                           LastName = "Karenina",
                           FirstName = "Anna",
                       }
                   }
               }
               });

               context.SaveChanges();
           }*/
            #endregion

            tran.Commit();
        }
    }
}
