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
    public class AllPublishersViewModel : CollectionViewModel<PublisherForAllView>
    {
        #region Properties
        private PublisherForAllView _ChosenPublisher;
        public PublisherForAllView ChosenPublisher
        {
            get
            {
                return _ChosenPublisher;
            }
            set
            {
                if (_ChosenPublisher != value)
                {
                    _ChosenPublisher = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenPublisher);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => _ChosenPublisher);
                }
            }
        }
        #endregion
        #region Constructor
        public AllPublishersViewModel()
            : base("Wydawnictwa")
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
            List = new ObservableCollection<PublisherForAllView>
                (
                    from publisher in LibraryIMSEntities.Publisher
                    where publisher.IsActive == true
                    select new PublisherForAllView
                    {
                        IDPublisher = publisher.IDPublisher,
                        Name = publisher.Name,
                        FoundingYear = publisher.FoundingYear,
                        Description = publisher.Description,
                        City = publisher.City,
                    }
                );
        }
        public override void Delete()
        {
            var item = LibraryIMSEntities.Publisher.First(x => x.IDPublisher == ChosenPublisher.IDPublisher);
            item.IsActive = false;
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Nazwa", "Rok założenia" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<PublisherForAllView>(List.OrderBy(item => item.IDPublisher));
            }            
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<PublisherForAllView>(List.OrderBy(item => item.Name));
            }
            if (SortField == "Rok założenia")
            {
                List = new ObservableCollection<PublisherForAllView>(List.OrderBy(item => item.FoundingYear));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ID", "Nazwa" };
        }
        public override void Find()
        {
            if (FindField == "ID")
            {
                List = new ObservableCollection<PublisherForAllView>(List.Where(item => item.IDPublisher.Equals(FindTextbox)));
            }
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<PublisherForAllView>(List.Where(item => item.Name != null && item.Name.Contains(FindTextbox)));
            }            
        }
        #endregion
    }
}
