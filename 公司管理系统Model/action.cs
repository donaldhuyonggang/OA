namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("action")]
    public partial class action
    {
        [Key]
        public int actionId { get; set; }

        public int? actionTypeID { get; set; }

        [StringLength(50)]
        public string actionhead { get; set; }

        [StringLength(500)]
        public string actionresult { get; set; }

        public DateTime? actiontime { get; set; }

        public int? actionneedmoney { get; set; }

        public int? actionfactmoney { get; set; }

        public int? UserId { get; set; }

        [StringLength(20)]
        public string actiontype { get; set; }

        [Required]
        [StringLength(50)]
        public string action_Condition { get; set; }

        public virtual actionType actionType1 { get; set; }

        public virtual User User { get; set; }
    }
}
