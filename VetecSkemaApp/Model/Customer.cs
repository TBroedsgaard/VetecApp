using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    [Serializable]
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<IContactPerson> Contacts { get; set; }
    }
}
