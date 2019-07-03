namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detail")]
    public partial class detail
    {
        [Key]
        public int MonryId { get; set; }

        [StringLength(20)]
        public string MonryResult { get; set; }

        public int? sum { get; set; }

        public DateTime? MoneyTime { get; set; }

        public int? UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string detail_Condition { get; set; }

        public virtual User User { get; set; }
    }
}
