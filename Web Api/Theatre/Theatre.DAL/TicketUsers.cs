namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TicketUsers
    {
        public Guid Id { get; set; }

        public Guid TicketNumber { get; set; }

        public Guid UserUniqueId { get; set; }

        public int TicketsFree { get; set; }

        public int UserCount { get; set; }

        public int? SalesNumbers { get; set; }

        public virtual Ticket Ticket { get; set; }

        public virtual Users Users { get; set; }
    }
}
