namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Replay")]
    public partial class Replay
    {
        public int ReplayId { get; set; }

        public int? webId { get; set; }

        public int? UserId { get; set; }

        [StringLength(500)]
        public string ReplayResult { get; set; }

        public DateTime? ReplayTime { get; set; }

        public virtual User User { get; set; }

        public virtual Web Web { get; set; }
    }
}
