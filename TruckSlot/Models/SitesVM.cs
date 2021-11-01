using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
    public class SitesVM
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public string EntryCamera { get; set; }
        public string ExitCamera { get; set; }
        public string physicallyLocation { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string CompanyName { get; set; }
        public string Code { get; set; }
        public string NumberSlot { get; set; }
        public int CompanyId { get; set; }
        public Decimal PricePerSlot { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string FileData { get; set; }
        public string CameraId { get; set; }
        public int FileId { get; set; }
        public int? UserId { get; set; }
        public Nullable<int> LayoutId { get; set; }

        public string SlotsLayout { get; set; }
        public string Zip { get; set; }
    }
}
