using System;
using System.Collections.Generic;
using System.Text;

namespace TruckSlot.Models
{
    public class MyListModel
    {
        public List<SlotModel> Slots { get; set; }
        public int Column { get; set; }
        public int Rows { get; set; }

    }

    public class SlotModel
    {
        public string Image { get; set; }
        public int SlotId { get; set; }
        public string Name { get; set; }
    }

    public class SitesListModel
    {
        public List<SiteList> Sites { get; set; }
        public int Column { get; set; }
        public int Rows { get; set; }
    }

    public class SiteList
    {
        public string Address { get; set; }
        public string SiteName { get; set; }
        public string Price { get; set; }
    }
}
