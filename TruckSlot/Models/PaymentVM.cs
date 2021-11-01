using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
    public class PaymentVM
    {
        public int Id { get; set; }
      
        public int? BookingId { get; set; }
       
        public int SiteId { get; set; }
        public int CompanyId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string DriverName { get; set; }
        public string DriverAddress { get; set; }
        public string SlotId { get; set; }
        public string DriverMob { get; set; }
        public string Driveremail { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public bool Active { get; set; }

    }
}
