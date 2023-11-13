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
    public class NewAuthorViewModel : ItemViewModel<Author>, IDataErrorInfo
    {
        #region Constructor
        public NewAuthorViewModel()
            : base("Autor")
        {
            Item = new Author();
        }
        #endregion
        #region Properties   
        public int IDAuthor
        {
            get
            {
                return Item.IDAuthor;
            }
            set
            {
                if (value != Item.IDAuthor)
                {
                    Item.IDAuthor = value;
                    base.OnPropertyChanged(() => IDAuthor);
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
        public string Surname
        {
            get
            {
                return Item.Surname;
            }
            set
            {
                if (value != Item.Surname)
                {
                    Item.Surname = value;
                    base.OnPropertyChanged(() => Surname);
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
            DataBase.Author.AddObject(Item);
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
                if(name == "Name")
                {
                    komunikat = StringValidator.HasCapitalLetter(Name);
                }
                if (name == "Surname")
                {
                    if (Name != null)
                    {
                        komunikat = StringValidator.HasCapitalLetter(Surname);
                        var result = DataBase.Author.FirstOrDefault(p => p.Name == Name && p.Surname == Surname);
                        if (result != null)
                        {
                            komunikat = "Istnieje już autor o podanym imieniu i nazwisku!";
                        }
                    }
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Surname"] == null && Surname != null && Name != null)
            {
                return true;
            }
            return false;
        }
        #endregion      
    }
}
