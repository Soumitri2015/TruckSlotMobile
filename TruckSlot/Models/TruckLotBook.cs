using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
   public class TruckLotBook
    {
        public int TruckLotBookId { get; set; }
        public int? SlotId { get; set; }
        public int? CompanyId { get; set; }
        public string SCompanyId { get; set; }
        public int? SiteId { get; set; }

        public string SSlotId { get; set; }
        public string SSiteId { get; set; }
        public int? DeiverId { get; set; }
        public int? Hours { get; set; }
        public bool LeftHours { get; set; }
        public int? Status { get; set; }
        public string DriverName { get; set; }
        public string Slot { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }
        public string SiteName { get; set; }
        public string SlotName { get; set; }
        public string UserName { get; set; }
        public string TimeLeave1 { get; set; }
        public string Cost { get; set; }
        public string Duration { get; set; }
        public string DriverAddr { get; set; }
        public System.DateTime TimeEntry { get; set; }
        public string STimeEntry { get; set; }
        public System.DateTime? TimeExit { get; set; }
        public System.DateTime TimeLeave { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public String IsTruckLot { get; set; }
        public string TotalHour { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string ComapnyEmail { get; set; }
        //public string UserName { get; set; }
        public string Tstatus { get; set; }
        public string token { get; set; }
        public int? PaymentId { get; set; }
    }
}
