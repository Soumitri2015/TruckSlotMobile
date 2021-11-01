using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
   public class SlotsVM
    {
        public int SlotId { get; set; }

        public string SlotName { get; set; }
        public string Status { get; set; }
        public int SiteId { get; set; }
      
        public int CompanyId { get; set; }
        public Decimal Cost { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public SitesVM Site { get; set; }
    }
}
