namespace Lm.App.Eic.Mes.EF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwoMes : DbContext
    {
        public TwoMes()
            : base("name=TwoMes")
        {
        }

        public virtual DbSet<BPM_UserFlowCard> BPM_UserFlowCard { get; set; }
        public virtual DbSet<HR_User> HR_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BPM_UserFlowCard>()
                .Property(e => e.Job_Num)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_UserFlowCard>()
                .Property(e => e.FlowCard)
                .IsUnicode(false);

            modelBuilder.Entity<BPM_UserFlowCard>()
                .Property(e => e.ID_Key)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Job_Num)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Workshop)
                .IsFixedLength();

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Workstation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.ClassType)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Job_Title)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Is_Job)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.PhotoPath)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Age)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.IsWedding)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Politics)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.ID_Card)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Nation)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Native_Place)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Major)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.School)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.IsWork)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.QQ)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Email_Address)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Present_Assress)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Emergency_Contact)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Emergency_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Resume)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R1)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R2)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R3)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R4)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.R5)
                .IsUnicode(false);

            modelBuilder.Entity<HR_User>()
                .Property(e => e.USI_ID)
                .HasPrecision(18, 0);
        }
    }
}
