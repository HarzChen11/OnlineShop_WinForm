namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrolleyDetails
    {
        public Guid TrolleyDetailsID { get; set; }

        public Guid TrolleyID { get; set; }

        public Guid ProductID { get; set; }

        public int ProductQuantity { get; set; }

        [Required]
        [StringLength(12)]
        public string ProductSpec { get; set; }

        [Required]
        [StringLength(3)]
        public string ProductColor { get; set; }

        public virtual Product Product { get; set; }

        public virtual Trolley Trolley { get; set; }
    }
}
