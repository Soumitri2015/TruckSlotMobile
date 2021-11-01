using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TruckSlot.Models
{
    public class DataBinding : INotifyPropertyChanged
    {

        string name = string.Empty;
        string expiryDate = string.Empty;
        string cvv = string.Empty;
        string holdername = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertChanged(nameof(Name));
                OnPropertChanged(nameof(DisplayName));

            }

        }
        public string EDate
        {
            get => expiryDate;
            set
            {
                if (expiryDate == value)
                    return;
                expiryDate = value;
                OnPropertChanged(nameof(EDate));
                OnPropertChanged(nameof(DisplayExpiryDate));

            }

        }
        public string CVV
        {
            get => cvv;
            set
            {
                if (cvv == value)
                    return;
                cvv = value;
                OnPropertChanged(nameof(CVV));
                OnPropertChanged(nameof(DisplayCVV));

            }

        }
        public string HolderNameText
        {
            get => holdername;
            set
            {
                if (holdername == value)
                    return;
                holdername = value;
                OnPropertChanged(nameof(HolderNameText));
                OnPropertChanged(nameof(DisplayHolderName));

            }

        }


        public string DisplayName => $"{Name}";
        public string DisplayExpiryDate => $"{EDate}";
        public string DisplayCVV => $"{CVV}";
        public string DisplayHolderName => $"     {HolderNameText}";


        public event PropertyChangedEventHandler PropertyChanged;
      
        void OnPropertChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (name));
        }
      
    }
}
