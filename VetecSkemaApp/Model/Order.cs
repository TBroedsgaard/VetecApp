﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class Order : IOrder
    {
        // public int Id { get; set; }
        public IForm Form { get; set; }
        public DateTime OrderDate { get; set; }
        public IContactPerson ContactPerson { get; set; }


        [JsonConstructor]
        public Order(Form form, ContactPerson contactperson)
        {
            Form = form;
            ContactPerson = contactperson;

        }

        public Order() { }
    }
}
