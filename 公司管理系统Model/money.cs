namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Money")]
    public partial class Money
    {
        [Key]
        public int sunId { get; set; }

        public int? overmoney { get; set; }

        public int? openmoney { get; set; }
    }
}
