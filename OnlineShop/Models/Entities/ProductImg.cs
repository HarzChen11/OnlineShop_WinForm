namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductImg")]
    public partial class ProductImg
    {
        [Key]
        [Column(Order = 0)]
        public Guid ProductImgID { get; set; }

        [Key]
        [Column("ProductImg", Order = 1, TypeName = "text")]
        public string ProductImg1 { get; set; }

        public virtual Product Product { get; set; }
    }
}
