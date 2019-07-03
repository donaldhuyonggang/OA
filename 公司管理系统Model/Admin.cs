namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        public int? ADTypeId { get; set; }

        public virtual ADType ADType { get; set; }
    }
}
