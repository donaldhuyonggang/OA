namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Menu()
        {
            Sys_Menu1 = new HashSet<Sys_Menu>();
            Sys_Right = new HashSet<Sys_Right>();
        }

        [Key]
        public int MenuId { get; set; }

        public int? ParentId { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(500)]
        public string MenuPath { get; set; }

        [StringLength(50)]
        public string MenuType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Menu> Sys_Menu1 { get; set; }

        public virtual Sys_Menu Sys_Menu2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Right> Sys_Right { get; set; }
    }
}
