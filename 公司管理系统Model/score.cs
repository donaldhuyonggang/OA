namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("score")]
    public partial class score
    {
        [Key]
        public int PointId { get; set; }

        public DateTime? PointTime { get; set; }

        public int? UserId { get; set; }

        public int? systemId { get; set; }

        [Required]
        [StringLength(50)]
        public string score_Condition { get; set; }

        public virtual system system { get; set; }

        public virtual User User { get; set; }
    }
}
