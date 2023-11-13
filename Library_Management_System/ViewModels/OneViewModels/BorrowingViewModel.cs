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
using System.Windows;
using System.Windows.Input;

namespace Library_Management_System.ViewModels
{
    public class BorrowingViewModel : ItemViewModel<Borrowing>, IDataErrorInfo
    {
        #region Command
        private BaseCommand _ShowAmountCommand;
        public ICommand ShowAmountCommand
        {
            get
            {
                if (_ShowAmountCommand == null)
                {
                    _ShowAmountCommand = new BaseCommand(() => showAmount());
                }
                return _ShowAmountCommand;
            }
        }
        private BaseCommand _ShowPublicationsCommand;
        public ICommand ShowPublicationsCommand
        {
            get
            {
                if (_ShowPublicationsCommand == null)
                {
                    _ShowPublicationsCommand = new BaseCommand(() => showPublications());
                }
                return _ShowPublicationsCommand;
            }
        }
        private BaseCommand _ShowUsersCommand;
        public ICommand ShowUsersCommand
        {
            get
            {
                if (_ShowUsersCommand == null)
                {
                    _ShowUsersCommand = new BaseCommand(() => showUsers());
                }
                return _ShowUsersCommand;
            }
        }
        private BaseCommand _ShowEmployeesCommand;
        public ICommand ShowEmployeesCommand
        {
            get
            {
                if (_ShowEmployeesCommand == null)
                {
                    _ShowEmployeesCommand = new BaseCommand(() => showEmployees());
                }
                return _ShowEmployeesCommand;
            }
        }
        private void showPublications()
        {
            Messenger.Default.Send("PublicationsAll");
        }
        private void showUsers()
        {
            Messenger.Default.Send("UsersAll");
        }
        private void showEmployees()
        {
            Messenger.Default.Send("EmployeesAll");
        }
        #endregion
        #region Constructor
        public BorrowingViewModel()
            : base("Wypożyczenie")
        {
            Item = new Borrowing();
            BorrowingDate = DateTime.Now;
            ReturningDeadline = DateTime.Now.AddDays(14);
            Messenger.Default.Register<PublicationForAllView>(this, getChosenPublication);
            Messenger.Default.Register<UserForAllView>(this, getChosenUser);
            Messenger.Default.Register<EmployeeForAllView>(this, getChosenEmployee);
        }
        #endregion
        #region Properties   
        public int? IDPublication
        {
            get
            {
                return Item.IDPublication;
            }
            set
            {
                if (value != Item.IDPublication)
                {
                    Item.IDPublication = value;
                    base.OnPropertyChanged(() => IDPublication);
                }
            }
        }
        public int? IDUser
        {
            get
            {
                return Item.IDUser;
            }
            set
            {
                if (value != Item.IDUser)
                {
                    Item.IDUser = value;
                    base.OnPropertyChanged(() => IDUser);
                }
            }
        }
        public int? IDEmployee
        {
            get
            {
                return Item.IDEmployee;
            }
            set
            {
                if (value != Item.IDEmployee)
                {
                    Item.IDEmployee = value;
                    base.OnPropertyChanged(() => IDEmployee);
                }
            }
        }
        public DateTime? BorrowingDate
        {
            get
            {
                return Item.BorrowingDate;
            }
            set
            {
                if (value != Item.BorrowingDate)
                {
                    Item.BorrowingDate = value;
                    base.OnPropertyChanged(() => BorrowingDate);
                }
            }
        }
        public DateTime? ReturningDate
        {
            get
            {
                return Item.ReturningDate;
            }
            set
            {
                if (value != Item.ReturningDate)
                {
                    Item.ReturningDate = value;
                    base.OnPropertyChanged(() => ReturningDate);
                }
            }
        }
        public DateTime? ReturningDeadline
        {
            get
            {
                return Item.ReturningDeadline;
            }
            set
            {
                if (value != Item.ReturningDeadline)
                {
                    Item.ReturningDeadline = value;
                    base.OnPropertyChanged(() => ReturningDeadline);
                }
            }
        }
        public string Remarks
        {
            get
            {
                return Item.Remarks;
            }
            set
            {
                if (value != Item.Remarks)
                {
                    Item.Remarks = value;
                    base.OnPropertyChanged(() => Remarks);
                }
            }
        }
        private int? _AvailableAmount;
        public int? AvailableAmount
        {
            get
            {
                return _AvailableAmount;
            }
            set
            {
                if (value != _AvailableAmount)
                {
                    _AvailableAmount = value;
                    OnPropertyChanged(() => AvailableAmount);
                }
            }
        }
        public IQueryable<KeyAndValue> PublicationsComboBoxItems
        {
            get
            {
                return
                (
                    from publication in DataBase.Publication
                    where publication.IsActive == true
                    select new KeyAndValue
                    {
                        Key = publication.IDPublication,
                        Value = publication.Title
                    }
                ).ToList().AsQueryable();    
            }
        }
        public IQueryable<KeyAndValue> UsersComboBoxItems
        {
            get
            {
                return
                (
                    from user in DataBase.User
                    where user.IsActive == true
                    select new KeyAndValue
                    {
                        Key = user.IDUser,
                        Value = user.Name + " " + user.Surname
                    }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> EmployeesComboBoxItems
        {
            get
            {
                return
                (
                  from employee in DataBase.Employee
                  where employee.IsActive == true
                  select new KeyAndValue
                  {
                    Key = employee.IDEmployee,
                    Value = employee.Name + " " + employee.Surname
                  }
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            var query = DataBase.StockAmount.FirstOrDefault(p => p.IDPublication == Item.IDPublication);
            query.BorrowedAmount += 1;
            if (Item.ReturningDate == null)
            {
                Item.IDBorrowingStatus = 2;
            }
            Item.IsActive = true;
            DataBase.Borrowing.AddObject(Item);
            DataBase.SaveChanges();
            Messenger.Default.Send(DisplayName + "Confirm");
            base.OnRequestClose();                
        }
        private void getChosenPublication(PublicationForAllView publicationForAllView)
        {
            IDPublication = publicationForAllView.IDPublication;                                 
        }
        private void getChosenUser(UserForAllView userForAllView)
        {
            IDUser = userForAllView.IDUser;
        }
        private void getChosenEmployee(EmployeeForAllView employeeForAllView)
        {
            IDEmployee = employeeForAllView.IDEmployee;
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
                if (name == "IDPublication")
                {
                    if(IDPublication != null)
                    {
                        var query = DataBase.StockAmount.FirstOrDefault(p => p.IDPublication == Item.IDPublication);
                        if (query.Amount <= query.BorrowedAmount || query.Amount == 0)
                            komunikat = "Nie ma wystarczającej ilości na stanie by wypożyczyć wybraną publikację!";
                        else 
                            komunikat = null;
                    }                  
                }
                if (name == "ReturningDeadline")
                {
                    komunikat = BusinessValidator.CompareBorrowingAndDeadlineDate(BorrowingDate, ReturningDeadline);
                }
                if (name == "BorrowingDate")
                {
                    komunikat = BusinessValidator.CompareBorrowingAndDeadlineDate(BorrowingDate, ReturningDeadline);
                }
                return komunikat;               
            }
        }
        public override bool IsValid()
        {
            if (IDPublication != null && IDUser != null && IDEmployee != null && BorrowingDate != null && ReturningDeadline != null)
            {
                if (this["ReturningDeadline"] == null && this["BorrowingDate"] == null && this["IDPublication"] == null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Helpers
        private void showAmount()
        {
            AvailableAmount = new ShowAvailableAmount(DataBase).AvailableAmountPublication(IDPublication);
        }
        #endregion
    }
}
