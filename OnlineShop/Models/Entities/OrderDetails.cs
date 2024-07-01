namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        public Guid OrderDetailsID { get; set; }

        public Guid OrderID { get; set; }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductColor { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductSpec { get; set; }

        public int ProductQuantity { get; set; }

        public int Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
