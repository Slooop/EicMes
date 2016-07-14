using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lm.App.Eic.Mes.EF.Model
{
    using System.Data.Entity;

    public class DbMes : DbContext
    {
        public DbMes()
            : base("name=DbMes")
        {
        }

        
        public virtual DbSet<Bpm_Daily> BpmDaily { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ClientName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ActualEndDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.DailyNum)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.WorkShop)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.JobNum)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessName)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ProcessSign)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
           .Property(e => e.MasterJobNum)
           .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
            .Property(e => e.MasterName)
            .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.EquipmentID)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Bpm_Daily>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            
        }
    }
}
