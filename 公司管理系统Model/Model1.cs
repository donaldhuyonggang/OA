namespace 公司管理系统Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<action> action { get; set; }
        public virtual DbSet<actionType> actionType { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<ADType> ADType { get; set; }
        public virtual DbSet<_class> _class { get; set; }
        public virtual DbSet<culture> culture { get; set; }
        public virtual DbSet<detail> detail { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<money> money { get; set; }
        public virtual DbSet<Replay> Replay { get; set; }
        public virtual DbSet<ReplayType> ReplayType { get; set; }
        public virtual DbSet<score> score { get; set; }
        public virtual DbSet<Sys_Department> Sys_Department { get; set; }
        public virtual DbSet<Sys_Menu> Sys_Menu { get; set; }
        public virtual DbSet<Sys_Role> Sys_Role { get; set; }
        public virtual DbSet<system> system { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<web> web { get; set; }
        public virtual DbSet<web_type> web_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<action>()
                .Property(e => e.actionhead)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.actionresult)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.actiontype)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.action_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<actionType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<ADType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.Morning)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.Afertnoon)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.require)
                .IsUnicode(false);

            modelBuilder.Entity<_class>()
                .Property(e => e.class_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<culture>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<culture>()
                .Property(e => e.Curlter)
                .IsUnicode(false);

            modelBuilder.Entity<culture>()
                .Property(e => e.CurlterHead)
                .IsUnicode(false);

            modelBuilder.Entity<culture>()
                .Property(e => e.culture_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<detail>()
                .Property(e => e.MonryResult)
                .IsUnicode(false);

            modelBuilder.Entity<detail>()
                .Property(e => e.detail_Condition)
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

            modelBuilder.Entity<Leave>()
                .Property(e => e.Leave_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<Replay>()
                .Property(e => e.ReplayResult)
                .IsUnicode(false);

            modelBuilder.Entity<Replay>()
                .Property(e => e.Replay_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<ReplayType>()
                .Property(e => e.ReplayTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<score>()
                .Property(e => e.score_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<Sys_Department>()
                .HasMany(e => e.Sys_Department1)
                .WithOptional(e => e.Sys_Department2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Sys_Department>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Sys_Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sys_Menu>()
                .HasMany(e => e.Sys_Menu1)
                .WithOptional(e => e.Sys_Menu2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Sys_Menu>()
                .HasMany(e => e.Sys_Role)
                .WithMany(e => e.Sys_Menu)
                .Map(m => m.ToTable("Sys_Right").MapLeftKey("MenuId").MapRightKey("RoleId"));

            modelBuilder.Entity<Sys_Role>()
                .HasMany(e => e.User)
                .WithMany(e => e.Sys_Role)
                .Map(m => m.ToTable("Sys_UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<system>()
                .Property(e => e.systemName)
                .IsUnicode(false);

            modelBuilder.Entity<system>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<system>()
                .Property(e => e.audat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<system>()
                .Property(e => e.sys_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.AdminId)
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
                .Property(e => e.User_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e._class)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.class1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserIde);

            modelBuilder.Entity<web>()
                .Property(e => e.webHead)
                .IsUnicode(false);

            modelBuilder.Entity<web>()
                .Property(e => e.webResult)
                .IsUnicode(false);

            modelBuilder.Entity<web>()
                .Property(e => e.web_Condition)
                .IsUnicode(false);

            modelBuilder.Entity<web_type>()
                .Property(e => e.web_typeName)
                .IsUnicode(false);
        }
    }
}
