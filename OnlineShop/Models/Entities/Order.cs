namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid OrderID { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [Required]
        [StringLength(3)]
        public string PaymentStatus { get; set; }

        public Guid? Deliver { get; set; }

        [Required]
        [StringLength(5)]
        public string Ordering { get; set; }

        [Required]
        [StringLength(20)]
        public string CreateTime { get; set; }

        public Guid TrolleyID { get; set; }

        public int? LockPoint { get; set; }

        [StringLength(20)]
        public string InvoiceNo { get; set; }

        [StringLength(20)]
        public string InvoiceDate { get; set; }

        [StringLength(20)]
        public string InvoiceStatus { get; set; }

        public virtual Deliver Deliver1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
