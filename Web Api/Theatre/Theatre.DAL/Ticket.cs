namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Show = new HashSet<Show>();
            TicketUsers = new HashSet<TicketUsers>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string TicketId { get; set; }

        public decimal Cost { get; set; }

        [Required]
        [StringLength(50)]
        public string NicknameOfUser { get; set; }

        public Guid? TheatreId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Show { get; set; }

        public virtual Theatre Theatre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketUsers> TicketUsers { get; set; }
    }
}
