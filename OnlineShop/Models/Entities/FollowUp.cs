namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowUp")]
    public partial class FollowUp
    {
        public Guid FollowUpID { get; set; }

        public Guid ProductID { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [StringLength(35)]
        public string Email { get; set; }

        public virtual Product Product { get; set; }
    }
}
