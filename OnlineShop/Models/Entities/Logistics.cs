namespace OnlineShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics
    {
        [Key]
        [StringLength(20)]
        public string TempLogisticsID { get; set; }

        public Guid? OrderID { get; set; }

        [Required]
        [StringLength(30)]
        public string ReceiverName { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverCellPhone { get; set; }

        [StringLength(50)]
        public string ReceiverAddress { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string StatusUpdate { get; set; }

        [StringLength(50)]
        public string LogisticsType { get; set; }

        [StringLength(50)]
        public string LogisticsSubType { get; set; }

        [StringLength(50)]
        public string ReceiverZipCode { get; set; }

        [StringLength(50)]
        public string ReceiverStoreName { get; set; }

        [StringLength(50)]
        public string ReceiverStoreID { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [StringLength(20)]
        public string LogisticsID { get; set; }
    }
}
