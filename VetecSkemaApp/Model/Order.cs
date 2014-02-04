using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    [Serializable]
    public class Order : IOrder
    {
        public int Id { get; set; }
        public IForm Form { get; set; }
        public ICustomer Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
