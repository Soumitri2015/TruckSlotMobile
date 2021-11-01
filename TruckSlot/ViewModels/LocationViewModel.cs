using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.ViewModels
{
    class LocationViewModel
    {   
        public int SiteId { get; set; }
      
        public string SiteName { get; set; }

        public int ID { get { return SiteId; } }
        public string NAME { get { return SiteName; } }

    }
}
