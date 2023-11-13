using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.Validators;
using Library_Management_System.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels
{
    public class NewLocationViewModel : ItemViewModel<Location>, IDataErrorInfo
    {
        #region Constructor
        public NewLocationViewModel()
            : base("Lokalizacja")
        {
            Item = new Location();
            Messenger.Default.Register<string>(this, listen);
        }
        bool forward = false;
        public void listen(string name)
        {
            if (name == "Forward")
            {
                forward = true;
            }
        }
        #endregion
        #region Properties 
        private Location _ChosenLocation;
        public Location ChosenLocation
        {
            get
            {
                return _ChosenLocation;
            }
            set
            {
                if (_ChosenLocation != value)
                {
                    _ChosenLocation = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenLocation);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => ChosenLocation);
                }
            }
        }
        public int IDLocation
        {
            get
            {
                return Item.IDLocation;
            }
            set
            {
                if (value != Item.IDLocation)
                {
                    Item.IDLocation = value;
                    base.OnPropertyChanged(() => IDLocation);
                }
            }
        }
        public string Name
        {
            get
            {
                return Item.Name;
            }
            set
            {
                if (value != Item.Name)
                {
                    Item.Name = value;
                    base.OnPropertyChanged(() => Name);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            DataBase.Location.AddObject(Item);
            DataBase.SaveChanges();
            Messenger.Default.Send(DisplayName + "Confirm");
            base.OnRequestClose();
        }
        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Name")
                {
                    komunikat = StringValidator.HasCapitalLetter(Name);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Name"] == null && Name != null)
            {
                return true;
            }
            return false;
        }
        #endregion      
    }
}
