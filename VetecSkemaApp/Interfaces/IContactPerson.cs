using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IContactPerson
    {
       int Id { get; set; }
       string Name { get; set; }
       int Phone     { get; set; }
       string Email { get; set; }
       DateTime OfficeHoursStart { get; set; }
       DateTime OfficeHoursEnd { get; set; }

    }
}
