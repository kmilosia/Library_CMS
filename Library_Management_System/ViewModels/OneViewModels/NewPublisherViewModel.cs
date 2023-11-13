using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.EntitiesForView;
using Library_Management_System.Models.Validators;
using Library_Management_System.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Management_System.ViewModels
{
    public class NewPublisherViewModel : ItemViewModel<Publisher>, IDataErrorInfo
    {
        #region Constructor
        public NewPublisherViewModel()
            : base("Wydawnictwo")
        {
            Item = new Publisher();
        }
        #endregion
        #region Properties   
        public int IDPublisher
        {
            get
            {
                return Item.IDPublisher;
            }
            set
            {
                if (value != Item.IDPublisher)
                {
                    Item.IDPublisher = value;
                    base.OnPropertyChanged(() => IDPublisher);
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
        public string FoundingYear
        {
            get
            {
                return Item.FoundingYear;
            }
            set
            {
                if (value != Item.FoundingYear)
                {
                    Item.FoundingYear = value;
                    base.OnPropertyChanged(() => FoundingYear);
                }
            }
        }
        public string City
        {
            get
            {
                return Item.City;
            }
            set
            {
                if (value != Item.City)
                {
                    Item.City = value;
                    base.OnPropertyChanged(() => City);
                }
            }
        }
        public string Description
        {
            get
            {
                return Item.Description;
            }
            set
            {
                if (value != Item.Description)
                {
                    Item.Description = value;
                    base.OnPropertyChanged(() => Description);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            DataBase.Publisher.AddObject(Item);
            DataBase.SaveChanges();
            Messenger.Default.Send(Item);
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
                    var result =
                    DataBase.Publisher.FirstOrDefault(p => p.Name == Name);
                    if (result != null)
                    {
                        komunikat = "Istnieje już wydawnictwo o podanej nazwie!";
                    }                    
                }
                if (name == "FoundingYear")
                {
                    komunikat = StringValidator.IsYear(FoundingYear);
                }
                if (name == "City")
                {
                    komunikat = StringValidator.HasCapitalLetter(City);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Name"] == null && this["FoundingYear"] == null && Name != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
