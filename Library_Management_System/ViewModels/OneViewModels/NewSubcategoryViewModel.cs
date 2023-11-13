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
    public class NewSubcategoryViewModel : ItemViewModel<Subcategory>, IDataErrorInfo
    {
        #region Constructor
        public NewSubcategoryViewModel()
            : base("Podkategoria")
        {
            Item = new Subcategory();
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
        private Subcategory _ChosenSubcategory;
        public Subcategory ChosenSubcategory
        {
            get
            {
                return _ChosenSubcategory;
            }
            set
            {
                if (_ChosenSubcategory != value)
                {
                    _ChosenSubcategory = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenSubcategory);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => ChosenSubcategory);
                }
            }
        }
        public int IDSubcategory
        {
            get
            {
                return Item.IDSubcategory;
            }
            set
            {
                if (value != Item.IDSubcategory)
                {
                    Item.IDSubcategory = value;
                    base.OnPropertyChanged(() => IDSubcategory);
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
            DataBase.Subcategory.AddObject(Item);
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
