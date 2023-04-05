namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theatre")]
    public partial class Theatre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Theatre()
        {
            Proprietor = new HashSet<Proprietor>();
            TheatrePersonnel = new HashSet<TheatrePersonnel>();
            Ticket = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }

        public int TicketsSold { get; set; }

        public int NumberOfPeople { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfTheatreShow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proprietor> Proprietor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheatrePersonnel> TheatrePersonnel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
