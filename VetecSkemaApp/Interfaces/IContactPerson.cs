using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IContactPerson
    {
       string CompanyName { get; set; }
       string Name { get; set; }
       string Phone     { get; set; }
       string Email { get; set; }
       
       

    }
}
