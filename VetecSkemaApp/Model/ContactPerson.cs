using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    [Serializable]
    public class ContactPerson : IContactPerson
    {
        public int Id              { get; set; }
        public string CompanyName     { get; set; }
        public string Name         { get; set; }
        public string Phone           { get; set; }
        public string Email        { get; set; }
        public DateTime OfficeHoursStart { get; set; }
        public DateTime OfficeHoursEnd { get; set; }

        public override string ToString()
        {
            return Name + " " + Email + " " + Phone;
        }
    }
}
