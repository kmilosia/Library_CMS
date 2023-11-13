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
    public class StockUpdateViewModel : ItemViewModel<StockAmount>, IDataErrorInfo
    {
        #region Command
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
        private void showEmployees()
        {
            Messenger.Default.Send("EmployeesAll");
        }
        #endregion
        #region Constructor
        public StockUpdateViewModel()
            : base("Magazyn")
        {
            Item = new StockAmount();
            LastModified = DateTime.Now;
            Messenger.Default.Register<PublicationForAllView>(this, getChosenPublication);
            Messenger.Default.Register<EmployeeForAllView>(this, getChosenEmployee);
        }
        #endregion
        #region Properties
        public int? Amount
        {
            get
            {
                return Item.Amount;
            }
            set
            {
                if (value != Item.Amount)
                {
                    Item.Amount = value;
                    base.OnPropertyChanged(() => Amount);
                }
            }
        }
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
        public DateTime? LastModified
        {
            get
            {
                return Item.LastModified;
            }
            set
            {
                if (value != Item.LastModified)
                {
                    Item.LastModified = value;
                    base.OnPropertyChanged(() => LastModified);
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
        private int? _AmountOnStock;
        public int? AmountOnStock
        {
            get
            {
                return _AmountOnStock;
            }
            set
            {
                if (value != _AmountOnStock)
                {
                    _AmountOnStock = value;
                    OnPropertyChanged(() => AmountOnStock);
                }
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ShowAmountCommand;
        public ICommand ShowAmountCommand
        {
            get
            {
                if (_ShowAmountCommand == null)
                {
                    _ShowAmountCommand = new BaseCommand(() => showAmountClick());
                }
                return _ShowAmountCommand;
            }
        }
        #endregion
        #region Helpers
        private void getChosenEmployee(EmployeeForAllView employeeForAllView)
        {
            IDEmployee = employeeForAllView.IDEmployee;
        }
        private void getChosenPublication(PublicationForAllView publicationForAllView)
        {
            IDPublication = publicationForAllView.IDPublication;
        }
        private void showAmountClick()
        {
            AmountOnStock = new ShowStockAmountBusiness(DataBase).StockAmountPublication(IDPublication);
        }
        #endregion
        #region Save
        public override void Save()
        {
            var result = DataBase.StockAmount.FirstOrDefault(p => p.IDPublication == Item.IDPublication);
            result.Amount = Amount;
            result.IDEmployee = IDEmployee;
            result.LastModified = LastModified;
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
                if (name == "Amount")
                {
                    komunikat = NumericValidator.IsCorrectNumber(Amount);
                }              
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (IDPublication != null && Amount != null && IDEmployee != null && LastModified != null)
            {
                if (this["Amount"] == null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
