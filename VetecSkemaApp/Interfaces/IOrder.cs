﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IOrder
    {
        //int Id { get; set; }
        IForm Form { get; set; }
        IContactPerson ContactPerson { get; set; }
        DateTime OrderDate { get; set; }
    }
}
