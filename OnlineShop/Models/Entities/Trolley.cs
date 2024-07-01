namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trolley")]
    public partial class Trolley
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trolley()
        {
            TrolleyDetails = new HashSet<TrolleyDetails>();
        }

        public Guid TrolleyID { get; set; }

        public Guid Customer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatDate { get; set; }

        public bool OrderStatus { get; set; }

        public virtual Customer Customer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrolleyDetails> TrolleyDetails { get; set; }
    }
}
