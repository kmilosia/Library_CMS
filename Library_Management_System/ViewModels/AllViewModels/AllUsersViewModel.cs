using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Models.EntitiesForView;
using Library_Management_System.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels
{
    public class AllUsersViewModel : CollectionViewModel<UserForAllView>
    {
        #region Properties
        private UserForAllView _ChosenUser;
        public UserForAllView ChosenUser
        {
            get
            {
                return _ChosenUser;
            }
            set
            {
                if (_ChosenUser != value)
                {
                    _ChosenUser = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenUser);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => _ChosenUser);
                }
            }
        }
        #endregion
        #region Constructor
        public AllUsersViewModel()
            :base("Użytkownicy")
        {
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
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UserForAllView>
                (
                    from user in LibraryIMSEntities.User
                    where user.IsActive == true
                    select new UserForAllView
                    {
                     IDUser = user.IDUser,
                     Name = user.Name + " " + user.Surname,
                     Birthday = user.Birthday,
                     GenderName = user.Gender.Name,
                     Email = user.Contact.Email,
                     PhoneNumber = user.Contact.PhoneNumber,
                     Address = user.Address.Street + user.Address.HouseNumber + user.Address.Postcode + user.Address.City +" "+ user.Address.Country,
                    }
                );
        }
        public override void Delete()
        {
            var person = LibraryIMSEntities.User.First(x => x.IDUser == ChosenUser.IDUser);
            var address = LibraryIMSEntities.Address.First(x => x.IDAddress == person.IDAddress);
            var contact = LibraryIMSEntities.Contact.First(x => x.IDContact == person.IDContact);
            person.IsActive = false;
            address.IsActive = false;
            contact.IsActive = false;
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Imię i nazwisko", "Data urodzenia" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<UserForAllView>(List.OrderBy(item => item.IDUser));
            }
            if (SortField == "Imię i nazwisko")
            {
                List = new ObservableCollection<UserForAllView>(List.OrderBy(item => item.Name));
            }
            if (SortField == "Data urodzenia")
            {
                List = new ObservableCollection<UserForAllView>(List.OrderBy(item => item.Birthday));
            }                     
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ID", "Imię i nazwisko", "Data urodzenia" };
        }
        public override void Find()
        {
            if (FindField == "ID")
            {
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.IDUser.Equals(FindTextbox)));
            }
            if (FindField == "Imię i nazwisko")
            {
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.Name != null && item.Name.Contains(FindTextbox)));
            }
            if (FindField == "Data urodzenia")
            {
                List = new ObservableCollection<UserForAllView>(List.Where(item => item.Birthday != null && item.Birthday.Equals(DateTime.Parse(FindTextbox))));
            }            
        }
        #endregion

    }
}
