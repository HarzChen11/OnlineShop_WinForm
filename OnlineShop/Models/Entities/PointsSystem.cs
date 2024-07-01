namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointsSystem")]
    public partial class PointsSystem
    {
        [Key]
        public Guid PointSystemID { get; set; }

        public Guid? OrderDetailsID { get; set; }

        public Guid? OrderID { get; set; }

        public int Point { get; set; }

        public Guid CustomerID { get; set; }

        public bool Used { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(20)]
        public string CreatDate { get; set; }

        [StringLength(20)]
        public string ExpireTime { get; set; }

        [Required]
        [StringLength(100)]
        public string PointRemark { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }
    }
}
