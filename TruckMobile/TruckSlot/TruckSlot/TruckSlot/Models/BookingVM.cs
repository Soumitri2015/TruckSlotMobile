using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
 
    public class BookingVM
    {
        public int BookingId { get; set; }
        public string EncryptBookingId
        {
            get; set;
        }
        public int? SlotId { get; set; }
        public int? UserId { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal TareWeight { get; set; }
        public int CompanyId { get; set; }
        public string DecryptedId { get; set; }
        public int TruckId { get; set; }


        public System.DateTime TimeEntry { get; set; }
        public System.DateTime? TimeLeave { get; set; }
        public string Status { get; set; }
        public string DriverName { get; set; }
        public string DriverMob { get; set; }
        public string DriverEmail { get; set; }
        public string TruckTag { get; set; }
        public bool IsEntryVerified { get; set; }
        public bool IsExitVerified { get; set; }
        public string TruckNumber { get; set; }
        public string TruckColor { get; set; }
        public System.DateTime Date { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string SlotName { get; set; }
        public string ImageDataString { get; set; }
        public string ExitImageDataString { get; set; }
        public byte[] ImageData { get; set; }
        public bool IsValidImage { get; set; }
        public string ImageType { get; set; }
        public string ExitImageType { get; set; }
        public string ExitTime { get; set; }
        public string EntryTime { get; set; }
        public decimal TotalWeight { get; set; }
        public string TotalHour { get; set; }
        public string ProducerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Hour { get; set; }
        public int TotalHours { get; set; }

    }
}
