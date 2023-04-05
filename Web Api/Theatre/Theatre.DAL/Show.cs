namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Show")]
    public partial class Show
    {
        public Guid Id { get; set; }

        public int TicketsSold { get; set; }

        public decimal? TicketPrice { get; set; }

        public int? SeatingsAvailable { get; set; }

        public Guid? TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
