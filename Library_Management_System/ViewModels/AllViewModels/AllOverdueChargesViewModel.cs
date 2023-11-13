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
    public class AllOverdueChargesViewModel : CollectionViewModel<OverdueChargeForAllView>
    {
        #region Properties
        private OverdueChargeForAllView _ChosenCharge;
        public OverdueChargeForAllView ChosenCharge
        {
            get
            {
                return _ChosenCharge;
            }
            set
            {
                if (_ChosenCharge != value)
                {
                    _ChosenCharge = value;                  
                    base.OnPropertyChanged(() => _ChosenCharge);
                }
            }
        }
        #endregion
        #region Constructor
        public AllOverdueChargesViewModel()
            : base("Opłaty")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<OverdueChargeForAllView>
                (
                    from charge in LibraryIMSEntities.OverdueCharge
                    where charge.IsActive == true
                    select new OverdueChargeForAllView
                    {
                        IDOverdueCharge = charge.IDOverdueCharge,
                        UserName = charge.User.Name + " " + charge.User.Surname,
                        EmployeeName = charge.Employee.Name + " " + charge.Employee.Surname,
                        Title = charge.Borrowing.Publication.Title,
                        PaymentAmount = charge.PaymentAmount,
                        PaymentMethod = charge.PaymentMethod.Name,
                        PaymentStatus = charge.PaymentStatus.Name,
                        ReturningDate = charge.ReturnDate,
                        ReturningDeadline = charge.ReturnDeadline,
                        Remarks = charge.Remarks,
                    }
                );
        }
        public override void Delete()
        {
            var item = LibraryIMSEntities.OverdueCharge.First(x => x.IDOverdueCharge == ChosenCharge.IDOverdueCharge);
            item.IsActive = false;                       
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Użytkownik", "Data oddania", "Status płatności", "Kwota" };
        }
        public override void Sort()
        {
            if (SortField == "Użytkownik")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.OrderBy(item => item.UserName));
            }
            if (SortField == "Data oddania")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.OrderBy(item => item.ReturningDate));
            }
            if (SortField == "Status płatności")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.OrderBy(item => item.PaymentStatus));
            }
            if (SortField == "Kwota")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.OrderBy(item => item.PaymentAmount));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Użytkownik", "Data oddania", "Termin oddania" };
        }
        public override void Find()
        {
            if (FindField == "Użytkownik")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.Where(item => item.UserName != null && item.UserName.Contains(FindTextbox)));
            }
            if (FindField == "Data oddania")
            {              
                List = new ObservableCollection<OverdueChargeForAllView>(List.Where(item => item.ReturningDate != null && item.ReturningDate.Equals(DateTime.Parse(FindTextbox))));
            }
            if (FindField == "Termin oddania")
            {
                List = new ObservableCollection<OverdueChargeForAllView>(List.Where(item => item.ReturningDeadline != null && item.ReturningDeadline.Equals(DateTime.Parse(FindTextbox))));
            }
        }
        #endregion
    }
}
