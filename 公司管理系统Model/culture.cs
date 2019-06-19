namespace 公司管理系统Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Culture")]
    public partial class Culture
    {
        [Key]
        public int CurlterId { get; set; }

        [Required]
        [StringLength(50)]
        public string img { get; set; }

        [StringLength(200)]
        public string Curlter { get; set; }

        public int? UserId { get; set; }

        public int? imgID { get; set; }

        [StringLength(50)]
        public string CurlterHead { get; set; }

        public DateTime? ReleaseTime { get; set; }

        public virtual Image Image { get; set; }

        public virtual User User { get; set; }
    }
}
