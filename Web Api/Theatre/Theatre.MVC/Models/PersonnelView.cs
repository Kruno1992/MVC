using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theatre.MVC.Models
{
    public class PersonnelView
    {
        public Guid Id { get; set; }
        public string PersonnelName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int HoursOfWork { get; set; }
     }
}