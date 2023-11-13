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
    public class NewCategoryViewModel : ItemViewModel<Category>, IDataErrorInfo
    {
        #region Constructor
        public NewCategoryViewModel()
            : base("Kategoria")
        {
            Item = new Category();
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
        private Category _ChosenCategory;
        public Category ChosenCategory
        {
            get
            {
                return _ChosenCategory;
            }
            set
            {
                if (_ChosenCategory != value)
                {
                    _ChosenCategory = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenCategory);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => ChosenCategory);
                }
            }
        }
        public int IDCategory
        {
            get
            {
                return Item.IDCategory;
            }
            set
            {
                if (value != Item.IDCategory)
                {
                    Item.IDCategory = value;
                    base.OnPropertyChanged(() => IDCategory);
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
            DataBase.Category.AddObject(Item);
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
