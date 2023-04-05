namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAddress")]
    public partial class UserAddress
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(70)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(200)]
        public string HouseNumber { get; set; }

        public Guid? UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
