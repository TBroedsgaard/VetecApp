using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface ICustomer
    {
        int Id { get; set; }
        string CompanyName { get; set; }
        List<IContactPerson> Contacts { get; set; } 
    }
}
