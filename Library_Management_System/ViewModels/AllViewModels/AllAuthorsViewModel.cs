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
    public class AllAuthorsViewModel : CollectionViewModel<AuthorForAllView>
    {
        #region Properties
        private AuthorForAllView _ChosenAuthor;
        public AuthorForAllView ChosenAuthor
        {
            get
            {
                return _ChosenAuthor;
            }
            set
            {
                if (_ChosenAuthor != value)
                {
                    _ChosenAuthor = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenAuthor);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => ChosenAuthor);
                }
            }
        }
        #endregion
        #region Constructor
        public AllAuthorsViewModel()
            : base("Autorzy")
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
            List = new ObservableCollection<AuthorForAllView>
                (
                    from author in LibraryIMSEntities.Author
                    where author.IsActive == true
                    select new AuthorForAllView
                    {
                        IDAuthor = author.IDAuthor,
                        Name = author.Name,
                        Surname = author.Surname,
                        Description = author.Description,
                    }
                );
        }
        public override void Delete()
        {
            var item = LibraryIMSEntities.Author.First(x => x.IDAuthor == ChosenAuthor.IDAuthor);
            item.IsActive = false;                     
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Imię", "Nazwisko" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<AuthorForAllView>(List.OrderBy(item => item.IDAuthor));
            }
            if (SortField == "Imię")
            {
                List = new ObservableCollection<AuthorForAllView>(List.OrderBy(item => item.Name));
            }
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<AuthorForAllView>(List.OrderBy(item => item.Surname));
            }           
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }
        public override void Find()
        {
            if (FindField == "Imię")
            {
                List = new ObservableCollection<AuthorForAllView>(List.Where(item => item.Name != null && item.Name.Contains(FindTextbox)));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<AuthorForAllView>(List.Where(item => item.Surname != null && item.Surname.Contains(FindTextbox)));
            }
        }
        #endregion
    }
}
