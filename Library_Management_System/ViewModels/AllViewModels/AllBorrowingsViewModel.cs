using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Models.BusinessLogic;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.EntitiesForView;
using Library_Management_System.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Management_System.ViewModels
{
    public class AllBorrowingsViewModel : CollectionViewModel<BorrowingForAllView>
    {
        #region Properties
        private BorrowingForAllView _ChosenBorrowing;
        public BorrowingForAllView ChosenBorrowing
        {
            get
            {
                return _ChosenBorrowing;
            }
            set
            {
                if (_ChosenBorrowing != value)
                {
                    _ChosenBorrowing = value;
                    if (forward)
                    {
                      
                            forward = false;
                            Messenger.Default.Send(_ChosenBorrowing);
                            OnRequestClose();           
                    }
                    base.OnPropertyChanged(() => ChosenBorrowing);
                }
            }
        }
        #endregion
        #region Constructor
        public AllBorrowingsViewModel()
            : base("Wypożyczenia")
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
            List = new ObservableCollection<BorrowingForAllView>
                (
                    from borrowing in LibraryIMSEntities.Borrowing
                    where borrowing.IsActive == true
                    select new BorrowingForAllView
                    {
                        IDBorrowing = borrowing.IDBorrowing,
                        UserName = borrowing.User.Name + " " + borrowing.User.Surname,
                        EmployeeName = borrowing.Employee.Name + " " + borrowing.Employee.Surname,
                        IDPublication = borrowing.IDPublication,
                        Title = borrowing.Publication.Title,
                        BorrowingDate = borrowing.BorrowingDate,
                        ReturningDate = borrowing.ReturningDate,
                        ReturningDeadline = borrowing.ReturningDeadline,
                        Remarks = borrowing.Remarks,
                        Status = borrowing.BorrowingStatus.Name
                    }
                );
        }
        public override void Delete()
        {
            var item = LibraryIMSEntities.Borrowing.First(x => x.IDBorrowing == ChosenBorrowing.IDBorrowing);
            item.IsActive = false;            
            var result = LibraryIMSEntities.StockAmount.FirstOrDefault(p => p.IDPublication == item.IDPublication);
            if (item.ReturningDate == null)
            {
                result.BorrowedAmount -= 1;
            }
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Data wypożyczenia", "Użytkownik", "Tytuł", "Status" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.OrderBy(item => item.IDBorrowing));
            }
            if (SortField == "Data wypożyczenia")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.OrderBy(item => item.BorrowingDate));
            }
            if (SortField == "Użytkownik")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.OrderBy(item => item.UserName));
            }
            if (SortField == "Tytuł")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.OrderBy(item => item.Title));
            }
            if (SortField == "Status")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.OrderBy(item => item.Status));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Użytkownik", "Tytuł" };
        }
        public override void Find()
        {
            if (FindField == "Użytkownik")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.Where(item => item.UserName != null && item.UserName.Contains(FindTextbox)));
            }
            if (FindField == "Tytuł")
            {
                List = new ObservableCollection<BorrowingForAllView>(List.Where(item => item.Title != null && item.Title.Contains(FindTextbox)));
            }                    
        }
        #endregion
    }
}
