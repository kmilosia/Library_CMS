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
    public class NewPositionViewModel : ItemViewModel<Position>, IDataErrorInfo
    {
        #region Constructor
        public NewPositionViewModel()
            : base("Stanowisko")
        {
            Item = new Position();
        }
        #endregion
        #region Properties   
        public int IDPosition
        {
            get
            {
                return Item.IDPosition;
            }
            set
            {
                if (value != Item.IDPosition)
                {
                    Item.IDPosition = value;
                    base.OnPropertyChanged(() => IDPosition);
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
            DataBase.Position.AddObject(Item);
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
