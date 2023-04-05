using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theatre.WebApi
{
    public class PersonnelRest
    {
        public Guid Id { get; set; }
        public string PersonnelName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int HoursOfWork { get; set; }
        public string PositionAndHours { get; set; }
    }

}
