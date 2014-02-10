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


        public string CompanyName { get; set; }
        public string Name         { get; set; }
        public string Phone           { get; set; }
        public string Email        { get; set; }
        

        public override string ToString()
        {
            return Name + " " + Email + " " + Phone;
        }
    }
}
