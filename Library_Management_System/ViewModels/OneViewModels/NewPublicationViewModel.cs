using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Helper;
using Library_Management_System.Models.BusinessLogic;
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
using System.Windows.Input;

namespace Library_Management_System.ViewModels
{
    public class NewPublicationViewModel : ItemViewModel<Publication>, IDataErrorInfo
    {
        #region Command
        private BaseCommand _ShowAuthorsCommand;
        public ICommand ShowAuthorsCommand
        {
            get
            {
                if (_ShowAuthorsCommand == null)
                {
                    _ShowAuthorsCommand = new BaseCommand(() => showAuthors());
                }
                return _ShowAuthorsCommand;
            }
        }
        private BaseCommand _ShowPublishersCommand;
        public ICommand ShowPublishersCommand
        {
            get
            {
                if (_ShowPublishersCommand == null)
                {
                    _ShowPublishersCommand = new BaseCommand(() => showPublishers());
                }
                return _ShowPublishersCommand;
            }
        }
        private BaseCommand _AddCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if (_AddCategoryCommand == null)
                {
                    _AddCategoryCommand = new BaseCommand(() => addCategory());
                }
                return _AddCategoryCommand;
            }
        }
        private BaseCommand _AddSubcategoryCommand;
        public ICommand AddSubcategoryCommand
        {
            get
            {
                if (_AddSubcategoryCommand == null)
                {
                    _AddSubcategoryCommand = new BaseCommand(() => addSubcategory());
                }
                return _AddSubcategoryCommand;
            }
        }
        private BaseCommand _AddLocationCommand;
        public ICommand AddLocationCommand
        {
            get
            {
                if (_AddLocationCommand == null)
                {
                    _AddLocationCommand = new BaseCommand(() => addLocation());
                }
                return _AddLocationCommand;
            }
        }
        #endregion
        #region Constructor
        public StockAmount Item2 { get; set; }
        public NewPublicationViewModel()
            : base("Publikacja")
        {
            Item = new Publication();
            Item2 = new StockAmount();
            Messenger.Default.Register<PublisherForAllView>(this, getPublisher);
            Messenger.Default.Register<AuthorForAllView>(this, getAuthor);
            Messenger.Default.Register<Category>(this, getCategory);
            Messenger.Default.Register<Subcategory>(this, getSubcategory);
            Messenger.Default.Register<Location>(this, getLocation);
        }
        #endregion
        #region Properties
        public string Title
        {
            get
            {
                return Item.Title;
            }
            set
            {
                if (value != Item.Title)
                {
                    Item.Title = value;
                    base.OnPropertyChanged(() => Title);
                }
            }
        }
        public string ISBN
        {
            get
            {
                return Item.ISBN;
            }
            set
            {
                if (value != Item.ISBN)
                {
                    Item.ISBN = value;
                    base.OnPropertyChanged(() => ISBN);
                }
            }
        }
        public string Volume
        {
            get
            {
                return Item.Volume;
            }
            set
            {
                if (value != Item.Volume)
                {
                    Item.Volume = value;
                    base.OnPropertyChanged(() => Volume);
                }
            }
        }
        public string PublishedYear
        {
            get
            {
                return Item.PublishedYear;
            }
            set
            {
                if (value != Item.PublishedYear)
                {
                    Item.PublishedYear = value;
                    base.OnPropertyChanged(() => PublishedYear);
                }
            }
        }
        public string PagesNumber
        {
            get
            {
                return Item.PagesNumber;
            }
            set
            {
                if (value != Item.PagesNumber)
                {
                    Item.PagesNumber = value;
                    base.OnPropertyChanged(() => PagesNumber);
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
        public int? IDCategory
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
        public int? IDSubcategory
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
        public int? IDAuthor
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
        public int? IDPublisher
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
        public int? IDLocation
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
        public int? Amount
        {
            get
            {
                return Item2.Amount;
            }
            set
            {
                if (value != Item2.Amount)
                {
                    Item2.Amount = value;
                    base.OnPropertyChanged(() => Amount);
                }
            }
        }
        public IQueryable<KeyAndValue> CategoriesComboBoxItems
        {
            get
            {
                return
                (
                    from category in DataBase.Category
                    where category.IsActive == true
                    select new KeyAndValue
                    {
                        Key = category.IDCategory,
                        Value = category.Name
                    }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> SubcategoriesComboBoxItems
        {
            get
            {
                return
                (
                 from subcategory in DataBase.Subcategory
                 where subcategory.IsActive == true
                 select new KeyAndValue
                 {
                    Key = subcategory.IDSubcategory,
                    Value = subcategory.Name
                 }
               ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> LocationsComboBoxItems
        {
            get
            {
                return
                (
                 from location in DataBase.Location
                 where location.IsActive == true
                 select new KeyAndValue
                 {
                    Key = location.IDLocation,
                    Value = location.Name
                 }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> AuthorsComboBoxItems
        {
            get
            {
                return
                (
                 from author in DataBase.Author
                 where author.IsActive == true
                 select new KeyAndValue
                 {
                    Key = author.IDAuthor,
                    Value = author.Name + " " + author.Surname
                 }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> PublishersComboBoxItems
        {
            get
            {
                return
                (
                 from publisher in DataBase.Publisher
                 where publisher.IsActive == true
                 select new KeyAndValue
                 {
                    Key = publisher.IDPublisher,
                    Value = publisher.Name
                 }
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Helpers
        private void showAuthors()
        {
            Messenger.Default.Send("AuthorsAll");
        }
        private void showPublishers()
        {
            Messenger.Default.Send("PublishersAll");
        }
        private void addCategory()
        {
            Messenger.Default.Send("KategoriaAdd");
        }
        private void addSubcategory()
        {
            Messenger.Default.Send("PodkategoriaAdd");
        }
        private void addLocation()
        {
            Messenger.Default.Send("LokalizacjaAdd");
        }
        private void getPublisher(PublisherForAllView publisherForAllView)
        {
            IDPublisher = publisherForAllView.IDPublisher;
        }
        private void getAuthor(AuthorForAllView authorForAllView)
        {
            IDAuthor = authorForAllView.IDAuthor;
        }
        private void getCategory(Category category)
        {
            IDCategory = category.IDCategory;
        }
        private void getSubcategory(Subcategory subcategory)
        {
            IDSubcategory = subcategory.IDSubcategory;
        }
        private void getLocation(Location location)
        {
            IDLocation = location.IDLocation;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            Item2.IsActive = true;
            Item2.BorrowedAmount = 0;
            Item2.LastModified = DateTime.Now;
            Item2.IDPublication = Item.IDPublication;
            if (Amount == null) Amount = 0;
            DataBase.Publication.AddObject(Item);
            DataBase.StockAmount.AddObject(Item2);
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
                if (name == "Title")
                {
                    var result = DataBase.Publication.FirstOrDefault(p => p.Title == Title);
                    if (result != null)
                    {
                        komunikat = "Istnieje już publikacja o podanym tytule!";
                    }
                }
                if (name == "ISBN")
                {
                    komunikat = BusinessValidator.IsISBN(ISBN);
                }
                if (name == "Amount")
                {
                    komunikat = NumericValidator.IsCorrectNumber(Amount);
                }
                if (name == "PublishedYear")
                {
                    komunikat = StringValidator.IsYear(PublishedYear);
                }
                if (name == "PagesNumber")
                {
                    komunikat = StringValidator.IsNumber(PagesNumber);
                }
                if (name == "Volume")
                {
                    komunikat = StringValidator.IsNumber(Volume);
                }
                return komunikat;               
            }
        }
        public override bool IsValid()
        {
            if (Title != null && ISBN != null && IDCategory != null && IDSubcategory != null && IDSubcategory != null && IDPublisher != null && IDAuthor != null && IDLocation != null)
            {
                if (this["Title"] == null && this["ISBN"] == null && this["Amount"] == null && this["PublishedYear"] == null && this["PagesNumber"] == null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
