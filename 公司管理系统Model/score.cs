namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        [Key]
        public int PointId { get; set; }

        public DateTime? PointTime { get; set; }

        public int? UserId { get; set; }

        public int? systemId { get; set; }

        public virtual Systems Systems { get; set; }

        public virtual User User { get; set; }
    }
}
