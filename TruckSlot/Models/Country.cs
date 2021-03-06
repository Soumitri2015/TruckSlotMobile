using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
    public class Country1
    {
        public int ID { get; set; }
        public string NAME { get; set; }

        public string Location { get; set; }

        public string Slot { get; set; }

        public string PhoneNo { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string ExpiredDate { get; set; }

        public string CVV { get; set; }

        public override string ToString()

        {
            return this.NAME;
        }
    }


}
