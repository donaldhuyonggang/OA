namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leave")]
    public partial class Leave
    {
        [Key]
        public int LeaveId { get; set; }

        public DateTime? LeaveTime { get; set; }

        public DateTime? LeaveResult { get; set; }

        public int? systemId { get; set; }

        [StringLength(20)]
        public string LeaveType { get; set; }

        public int? UserId { get; set; }

        [StringLength(20)]
        public string LeaveOver { get; set; }

        [Required]
        [StringLength(50)]
        public string Leave_Condition { get; set; }

        public virtual system system { get; set; }

        public virtual User User { get; set; }
    }
}
