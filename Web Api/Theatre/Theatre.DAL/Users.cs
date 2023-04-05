namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            TicketUsers = new HashSet<TicketUsers>();
            UserAddress = new HashSet<UserAddress>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(40)]
        public string UserTicketNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPaymentMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketUsers> TicketUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAddress> UserAddress { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
