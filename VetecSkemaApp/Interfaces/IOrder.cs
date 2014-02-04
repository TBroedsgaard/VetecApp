using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }
        IForm Form { get; set; }
        ICustomer Customer { get; set; }
        DateTime OrderDate { get; set; }

    }
}
