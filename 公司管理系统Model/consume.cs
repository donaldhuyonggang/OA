namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("consume")]
    public partial class consume
    {
        public int consumeID { get; set; }

        [StringLength(50)]
        public string consume_cause { get; set; }

        public int? consume_money { get; set; }

        public DateTime? consume_Time { get; set; }

        public int? Userid { get; set; }

        [Required]
        [StringLength(50)]
        public string consume_Condition { get; set; }

        public virtual User User { get; set; }
    }
}
