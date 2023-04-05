using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Model.Common;

namespace Theatre.Model.Common
{
    public interface IPersonnel
    {
        Guid Id { get; set; }
        string PersonnelName { get; set; }
        string Surname { get; set; }
        string Position { get; set; }
        int HoursOfWork { get; set; }
    }
}
