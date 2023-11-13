using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Models.Entities;
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
    public class AllPublicationsViewModel : CollectionViewModel<PublicationForAllView>
    {
        #region Properties
        private PublicationForAllView _ChosenPublication;
        public PublicationForAllView ChosenPublication
        {
            get
            {
                return _ChosenPublication;
            }
            set
            {
                if (_ChosenPublication != value)
                {
                    _ChosenPublication = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenPublication);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => _ChosenPublication);
                }
            }
        }
        #endregion
        #region Constructor
        public AllPublicationsViewModel()
            : base("Publikacje")
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
            List = new ObservableCollection<PublicationForAllView>
                (
                    from publication in LibraryIMSEntities.Publication
                    where publication.IsActive == true
                    select new PublicationForAllView
                    {
                        IDPublication = publication.IDPublication,
                        PublisherName = publication.Publisher.Name,
                        CategoryName = publication.Category.Name,
                        SubcategoryName = publication.Subcategory.Name,
                        AuthorName = publication.Author.Name + " " + publication.Author.Surname,
                        Location = publication.Location.Name,
                        Title = publication.Title,
                        ISBN = publication.ISBN,
                        PublishedYear = publication.PublishedYear,
                        PagesNumber = publication.PagesNumber,
                        Volume = publication.Volume,
                        Description = publication.Description
                    }
                );
        }
        public override void Delete()
        {
            StockAmount result = (
                from p in LibraryIMSEntities.StockAmount
                where p.IDPublication == ChosenPublication.IDPublication
                select p
                ).SingleOrDefault();


            var item = LibraryIMSEntities.Publication.First(x => x.IDPublication == ChosenPublication.IDPublication);
            item.IsActive = false;
            result.IsActive = false;
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Tytuł", "Autor", "Wydawnictwo", "Kategoria", "Podkategoria", "ISBN", "Rok wydania" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.IDPublication));
            }
            if (SortField == "Tytuł")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.Title));
            }
            if (SortField == "Autor")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.AuthorName));
            }
            if (SortField == "Wydawnictwo")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.PublisherName));
            }
            if (SortField == "Kategoria")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.CategoryName));
            }
            if (SortField == "Podkategoria")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.SubcategoryName));
            }
            if (SortField == "ISBN")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.ISBN));
            }
            if (SortField == "Rok wydania")
            {
                List = new ObservableCollection<PublicationForAllView>(List.OrderBy(item => item.PublishedYear));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ID", "Tytuł", "Autor", "ISBN" };
        }
        public override void Find()
        {
            if (FindField == "ID")
            {
                List = new ObservableCollection<PublicationForAllView>(List.Where(item => item.IDPublication.Equals(FindTextbox)));
            }
            if (FindField == "Tytuł")
            {
                List = new ObservableCollection<PublicationForAllView>(List.Where(item => item.Title != null && item.Title.Contains(FindTextbox)));
            }
            if (FindField == "Autor")
            {
                List = new ObservableCollection<PublicationForAllView>(List.Where(item => item.AuthorName != null && item.AuthorName.Contains(FindTextbox)));
            }
            if (FindField == "ISBN")
            {
                List = new ObservableCollection<PublicationForAllView>(List.Where(item => item.ISBN != null && item.ISBN.Contains(FindTextbox)));
            }
        }
        #endregion
    }
}

