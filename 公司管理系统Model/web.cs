namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("web")]
    public partial class web
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public web()
        {
            Replay = new HashSet<Replay>();
        }
        [Key]

        public int webId { get; set; }

        public int? UserId { get; set; }

        public int? web_typeID { get; set; }

        [StringLength(50)]
        public string webHead { get; set; }

        [StringLength(50)]
        public string webResult { get; set; }

        public DateTime? webtime { get; set; }

        public int? like { get; set; }

        public int? ReplayTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string web_Condition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Replay> Replay { get; set; }

        public virtual ReplayType ReplayType { get; set; }

        public virtual User User { get; set; }

        public virtual web_type web_type { get; set; }
    }
}
