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
}
