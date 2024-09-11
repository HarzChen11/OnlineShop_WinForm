namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deliver")]
    public partial class Deliver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deliver()
        {
            Order = new HashSet<Order>();
        }

        public Guid DeliverID { get; set; }

        [Column("Deliver")]
        [Required]
<<<<<<< HEAD
        [StringLength(20)]
        public string Deliver1 { get; set; }

        [Required]
        [StringLength(10)]
=======
        [StringLength(10)]
        public string Deliver1 { get; set; }

        [Required]
        [StringLength(5)]
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public string Translation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
