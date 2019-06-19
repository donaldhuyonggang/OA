namespace 公司管理系统Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class company : DbContext
    {
        public company()
            : base("name=company")
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<ADType> ADType { get; set; }
        public virtual DbSet<ClassTable> ClassTable { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<Replay> Replay { get; set; }
        public virtual DbSet<ReplayType> ReplayType { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Systems> Systems { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Web> Web { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .Property(e => e.actionhead)
                .IsUnicode(false);

            modelBuilder.Entity<Action>()
                .Property(e => e.actionresult)
                .IsUnicode(false);

            modelBuilder.Entity<Action>()
                .Property(e => e.actiontype)
                .IsUnicode(false);

            modelBuilder.Entity<ActionType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<ADType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<ClassTable>()
                .Property(e => e.Morning)
                .IsUnicode(false);

            modelBuilder.Entity<ClassTable>()
                .Property(e => e.Afertnoon)
                .IsUnicode(false);

            modelBuilder.Entity<ClassTable>()
                .Property(e => e.require)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .Property(e => e.Curlter)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .Property(e => e.CurlterHead)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.MonryResult)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.LeaveType)
                .IsUnicode(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.LeaveOver)
                .IsUnicode(false);

            modelBuilder.Entity<Replay>()
                .Property(e => e.ReplayResult)
                .IsUnicode(false);

            modelBuilder.Entity<ReplayType>()
                .Property(e => e.ReplayTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Systems>()
                .Property(e => e.systemName)
                .IsUnicode(false);

            modelBuilder.Entity<Systems>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Systems>()
                .Property(e => e.audat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPwd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Userimg)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Adderss)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ClassTable)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ClassTable1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserIde);

            modelBuilder.Entity<Web>()
                .Property(e => e.webHead)
                .IsUnicode(false);

            modelBuilder.Entity<Web>()
                .Property(e => e.webResult)
                .IsUnicode(false);
        }
    }
}
