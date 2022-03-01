using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class HospitalContext : DbContext
    {
        /*Поликлиника. Прием больных. Доврачебный прием. Консультация с конкретным врачом.
         Выдача больничных\справок. Госпитализация и выезд на место жительства пациента\больного.
        Содержание больных. Менеджмент пациентов и врачей.*/

        public DbSet<Reception> Receptions { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }
    }

    public class Reception
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int CabinetNumber { get; set; }
    }
}
