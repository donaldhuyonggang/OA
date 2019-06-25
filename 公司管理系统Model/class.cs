namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("class")]
    public partial class _class
    {
        public int ClassId { get; set; }

        [StringLength(20)]
        public string Morning { get; set; }

        [StringLength(20)]
        public string Afertnoon { get; set; }

        public int? UserIde { get; set; }

        public int? UserId { get; set; }

        public DateTime? DataTime { get; set; }

        [StringLength(50)]
        public string require { get; set; }

        [Required]
        [StringLength(50)]
        public string class_Condition { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
