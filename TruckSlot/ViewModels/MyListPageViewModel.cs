using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using TruckSlot.Models;

namespace TruckSlot.ViewModels
{
    public class MyListPageViewModel
    {
        public ObservableCollection<MyListModel> BookList { get; set; }
        public MyListPageViewModel(string SiteId="",string SlotId="")
        {
            BookList = new ObservableCollection<MyListModel>();
            var SlotId1 = CryptoEngine.Decrypt(SlotId);
            var SlotID = SlotId1.Substring(7);
            var Date = System.DateTime.Now.Date;

            APICall aPICall = new APICall();
            Uri url1 = new Uri("https://app.scalehouseai.com/api/BookingAPI/GetTruckLotBookBySlotId/" + SlotID + "?Date=" + Date);
            Task<string> task1 = Task.Run<string>(async () => await aPICall.GetURL(url1));
            TruckLotBook slotsVM1 = Newtonsoft.Json.JsonConvert.DeserializeObject<TruckLotBook>(task1.Result);

            Uri url = new Uri("https://app.scalehouseai.com/api/SlotsAPI/GetSlotBySiteId/" + SiteId);
            Task<string> task = Task.Run<string>(async () => await aPICall.GetURL(url));
            List<SlotsVM> slotsVM = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SlotsVM>>(task.Result);
            List<SlotModel> slotList = new List<SlotModel>();
            MyListModel objModel = null;
            foreach (var item in slotsVM)
            {
              
                if (slotsVM != null)
                {
                    SlotModel slotObj = new SlotModel();                    
                    slotObj.Name = item.SlotId.ToString();
                    slotObj.SlotId = item.SlotId;
                    if(slotsVM1 !=null)
                    {
                        if (slotsVM1.SlotId == item.SlotId)
                        {
                            //slotObj.Image = "https://app.scalehouseai.com/Scripts/booking-ui/assets/img/clicked-space.png";
                            slotObj.Image = "bookedspace.png";
                        }
                        
                        else
                        {
                            //slotObj.Image = "https://app.scalehouseai.com/Scripts/booking-ui/assets/img//empty-space.png";
                            slotObj.Image = "bookedspace.png";
                        }
                    }
                    else
                    {
                        //slotObj.Image = "https://app.scalehouseai.com/Scripts/booking-ui/assets/img//empty-space.png";
                        slotObj.Image = "bookedspace.png";
                    }
                 
                    if(slotList.Count == 10)
                    {
                        objModel = new MyListModel();
                        objModel.Slots = slotList;
                        BookList.Add(objModel);
                        slotList = new List<SlotModel>();
                        slotList.Add(slotObj);
                    }
                    else
                    {
                        slotList.Add(slotObj);
                    }
                }

            }
            objModel = new MyListModel();
            objModel.Slots = slotList;
            BookList.Add(objModel);

        }
    }
}
