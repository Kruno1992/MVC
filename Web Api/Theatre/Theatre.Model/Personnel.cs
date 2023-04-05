using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model.Common;

namespace Theatre.Model
{
    public class Personnel : IPersonnel
    {
        public Guid Id { get; set; }
        public string PersonnelName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int HoursOfWork { get; set; }
    }
}
