namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("system")]
    public partial class system
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public system()
        {
            Leave = new HashSet<Leave>();
            score = new HashSet<score>();
        }

        public int systemId { get; set; }

        [StringLength(50)]
        public string systemName { get; set; }

        public int systemPoint { get; set; }

        [StringLength(4)]
        public string status { get; set; }

        [StringLength(12)]
        public string audat { get; set; }

        [Required]
        [StringLength(50)]
        public string sys_Condition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leave> Leave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<score> score { get; set; }
    }
}
