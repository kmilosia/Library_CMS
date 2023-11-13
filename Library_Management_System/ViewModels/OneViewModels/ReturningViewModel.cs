using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Helper;
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
    public class ReturningViewModel : ItemViewModel<Borrowing>, IDataErrorInfo
    {
        #region Command
        private BaseCommand _ShowBorrowingsCommand;
        public ICommand ShowBorrowingsCommand
        {
            get
            {
                if (_ShowBorrowingsCommand == null)
                {
                    _ShowBorrowingsCommand = new BaseCommand(() => showBorrowings());
                }
                return _ShowBorrowingsCommand;
            }
        }
        private void showBorrowings()
        {
            Messenger.Default.Send("BorrowingsAll");
        }
        #endregion
        #region Constructor
        public ReturningViewModel()
            : base("Zwrot")
        {
            Item = new Borrowing();
            ReturningDate = DateTime.Now;
            Messenger.Default.Register<BorrowingForAllView>(this, getChosenBorrowing);
        }
        #endregion
        #region Properties  
        public int IDBorrowing
        {
            get
            {
                return Item.IDBorrowing;
            }
            set
            {
                if (value != Item.IDBorrowing)
                {
                    Item.IDBorrowing = value;
                    base.OnPropertyChanged(() => IDBorrowing);
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
        private string _BorrowingTitle;
        public string BorrowingTitle
        {
            get
            {
                return _BorrowingTitle;
            }
            set
            {
                if (value != _BorrowingTitle)
                {
                    _BorrowingTitle = value;
                    base.OnPropertyChanged(() => _BorrowingTitle);
                }
            }
        }
        private string _BorrowingUser;
        public string BorrowingUser
        {
            get
            {
                return _BorrowingUser;
            }
            set
            {
                if (value != _BorrowingUser)
                {
                    _BorrowingUser = value;
                    base.OnPropertyChanged(() => _BorrowingUser);
                }
            }
        }
        private DateTime? _BorrowingDate;
        public DateTime? BorrowingDate
        {
            get
            {
                return _BorrowingDate;
            }
            set
            {
                if (value != _BorrowingDate)
                {
                    _BorrowingDate = value;
                    base.OnPropertyChanged(() => _BorrowingDate);
                }
            }
        }
        private DateTime? _ReturningDeadline;
        public DateTime? ReturningDeadline
        {
            get
            {
                return _ReturningDeadline;
            }
            set
            {
                if (value != _ReturningDeadline)
                {
                    _ReturningDeadline = value;
                    base.OnPropertyChanged(() => _ReturningDeadline);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            var result = DataBase.Borrowing.First(x => x.IDBorrowing == Item.IDBorrowing);
            var resultTwo = DataBase.StockAmount.First(x => x.IDPublication == result.IDPublication);
            result.ReturningDate = ReturningDate;
            result.IDBorrowingStatus = 1;
            resultTwo.BorrowedAmount -= 1;
            if (Remarks != null)
            {
                result.Remarks = Remarks;
            }
            if (ReturningDate > ReturningDeadline)
            {
                MessageBoxResult mresult = MessageBox.Show("Zwrotu dokonano po ustalonym terminie. Zostaniesz przekierowany do opłacenia kary za przetrzymanie!");
                if (mresult == MessageBoxResult.OK)
                {
                    Messenger.Default.Send("Overdue");
                    DataBase.SaveChanges();
                    Messenger.Default.Send(DisplayName + "Confirm");
                    base.OnRequestClose();
                    Messenger.Default.Send(Item);
                }
            }
            else
            {
                DataBase.SaveChanges();
                Messenger.Default.Send(DisplayName + "Confirm");
                base.OnRequestClose();
            }
        }
        private void getChosenBorrowing(BorrowingForAllView borrowingForAllView)
        {
            IDBorrowing = borrowingForAllView.IDBorrowing;
            BorrowingTitle = borrowingForAllView.Title;
            BorrowingUser = borrowingForAllView.UserName;
            BorrowingDate = borrowingForAllView.BorrowingDate;
            ReturningDeadline = borrowingForAllView.ReturningDeadline;
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
                if (name == "IDBorrowing")
                {
                    if (IDBorrowing != 0)
                    {
                        var result = DataBase.Borrowing.First(x => x.IDBorrowing == Item.IDBorrowing);
                        if (result.IDBorrowingStatus == 1)
                            komunikat = "Wypożyczenie o wybranym ID zostało już oddane!";
                        else
                            komunikat = null;
                    }
                }
                if (name == "ReturningDate")
                {
                    komunikat = BusinessValidator.CompareBorrowingAndReturningDate(BorrowingDate, ReturningDate);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (IDBorrowing != 0 && ReturningDate != null)
            {
                if (this["ReturningDate"] == null && this["IDBorrowing"] == null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}

