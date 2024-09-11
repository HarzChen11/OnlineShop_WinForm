namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
<<<<<<< HEAD
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderDetails()
        {
            PointsSystem = new HashSet<PointsSystem>();
        }

=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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
<<<<<<< HEAD

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PointsSystem> PointsSystem { get; set; }
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}
