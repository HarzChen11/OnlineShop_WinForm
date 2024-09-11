namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductImg1 = new HashSet<ProductImg>();
            TrolleyDetails = new HashSet<TrolleyDetails>();
        }

        public Guid ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public Guid ProductType { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ProductImg { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductDescription { get; set; }

        public int ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

<<<<<<< HEAD
        public int? ProductSafeQuantity { get; set; }

=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ProductType ProductType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImg> ProductImg1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrolleyDetails> TrolleyDetails { get; set; }
    }
}
