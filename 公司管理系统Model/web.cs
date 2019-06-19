namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Web")]
    public partial class Web
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Web()
        {
            Replay = new HashSet<Replay>();
        }

        public int webId { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string webHead { get; set; }

        [StringLength(50)]
        public string webResult { get; set; }

        public DateTime? webtime { get; set; }

        public int? like { get; set; }

        public int? ReplayTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Replay> Replay { get; set; }

        public virtual ReplayType ReplayType { get; set; }

        public virtual User User { get; set; }
    }
}
