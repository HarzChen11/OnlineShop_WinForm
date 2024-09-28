namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public Guid StockID { get; set; }

        public Guid ProductID { get; set; }

        public int ProductQuantity { get; set; }

        public int ProductSafeQuantity { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
