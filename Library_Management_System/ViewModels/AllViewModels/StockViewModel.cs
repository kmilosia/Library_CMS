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
    public class StockViewModel : CollectionViewModel<StockForAllView>
    {
        #region Properties
        private StockForAllView _ChosenPosition;
        public StockForAllView ChosenPosition
        {
            get
            {
                return _ChosenPosition;
            }
            set
            {
                if (_ChosenPosition != value)
                {
                    _ChosenPosition = value;                  
                    base.OnPropertyChanged(() => _ChosenPosition);
                }
            }
        }
        #endregion
        #region Constructor
        public StockViewModel()
            : base("Stan magazynu")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<StockForAllView>
                (
                    from stock in LibraryIMSEntities.StockAmount
                    where stock.IsActive == true
                    select new StockForAllView
                    {
                        IDPublication = stock.IDPublication,
                        IDStockAmount = stock.IDStockAmount,
                        PublicationTitle = stock.Publication.Title,
                        PublicationAuthor = stock.Publication.Author.Name + " " + stock.Publication.Author.Surname,
                        BorrowedAmount = stock.BorrowedAmount,
                        Amount = stock.Amount,
                        LastModified = stock.LastModified,
                        EmployeeName = stock.Employee.Name + " " +  stock.Employee.Surname
                    }
                );
        }
        public override void Delete()
        {
            var item = LibraryIMSEntities.StockAmount.First(x => x.IDStockAmount == ChosenPosition.IDStockAmount);
            item.IsActive = false;
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Tytuł", "Autor", "Ostatnia modyfikacja" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<StockForAllView>(List.OrderBy(item => item.IDStockAmount));
            }
            if (SortField == "Tytuł")
            {
                List = new ObservableCollection<StockForAllView>(List.OrderBy(item => item.PublicationTitle));
            }
            if (SortField == "Autor")
            {
                List = new ObservableCollection<StockForAllView>(List.OrderBy(item => item.PublicationAuthor));
            }
            if (SortField == "Ostatnia modyfikacja")
            {
                List = new ObservableCollection<StockForAllView>(List.OrderBy(item => item.LastModified));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "Ostatnia modyfikacja", "Pracownik modyfikujący" };
        }
        public override void Find()
        {            
            if (FindField == "Tytuł")
            {
                List = new ObservableCollection<StockForAllView>(List.Where(item => item.PublicationTitle != null && item.PublicationTitle.Contains(FindTextbox)));
            }
            if (FindField == "Ostatnia modyfikacja")
            {
                List = new ObservableCollection<StockForAllView>(List.Where(item => item.LastModified != null && item.LastModified.Equals(FindTextbox)));
            }
            if (FindField == "Pracownik modyfikujący")
            {
                List = new ObservableCollection<StockForAllView>(List.Where(item => item.EmployeeName != null && item.EmployeeName.Contains(FindTextbox)));
            }
        }
        #endregion

    }
}
