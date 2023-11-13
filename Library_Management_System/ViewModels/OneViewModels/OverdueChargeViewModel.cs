using GalaSoft.MvvmLight.Messaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Library_Management_System.Helper;
using Library_Management_System.Models.BusinessLogic;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.EntitiesForView;
using Library_Management_System.Models.Validators;
using Library_Management_System.ViewModels.Abstract;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_System.ViewModels
{
    public class OverdueChargeViewModel : ItemViewModel<OverdueCharge>, IDataErrorInfo
    {
        #region Command
        private BaseCommand _ExportCommand;
        public ICommand ExportCommand
        {
            get
            {
                if (_ExportCommand == null)
                {
                    _ExportCommand = new BaseCommand(() => exportToPDFClick());
                }
                return _ExportCommand;
            }
        }
        private BaseCommand _CalculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (_CalculateCommand == null)
                {
                    _CalculateCommand = new BaseCommand(() => calculateFinalAmountClick());
                }
                return _CalculateCommand;
            }
        }
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
        private void showBorrowings()
        {
            Messenger.Default.Send("BorrowingsAll");
        }
        private void showEmployees()
        {
            Messenger.Default.Send("EmployeesAll");
        }
        #endregion
        #region Constructor
        public OverdueChargeViewModel()
            : base("Opłata")
        {
            Item = new OverdueCharge();
            Messenger.Default.Register<BorrowingForAllView>(this, getChosenBorrowing);
            Messenger.Default.Register<EmployeeForAllView>(this, getChosenEmployee);
            Messenger.Default.Register<Borrowing>(this, getSentBorrowing);
        }
        #endregion
        #region Properties
        public int? IDBorrowing
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
        public decimal? PaymentAmount
        {
            get
            {
                return Item.PaymentAmount;
            }
            set
            {
                if (value != Item.PaymentAmount)
                {
                    Item.PaymentAmount = value;
                    base.OnPropertyChanged(() => PaymentAmount);
                }
            }
        }
        public int? IDPaymentMethod
        {
            get
            {
                return Item.IDPaymentMethod;
            }
            set
            {
                if (value != Item.IDPaymentMethod)
                {
                    Item.IDPaymentMethod = value;
                    base.OnPropertyChanged(() => IDPaymentMethod);
                }
            }
        }
        public int? IDPaymentStatus
        {
            get
            {
                return Item.IDPaymentStatus;
            }
            set
            {
                if (value != Item.IDPaymentStatus)
                {
                    Item.IDPaymentStatus = value;
                    base.OnPropertyChanged(() => IDPaymentStatus);
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
                    base.OnPropertyChanged(() => BorrowingTitle);
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
                    base.OnPropertyChanged(() => BorrowingUser);
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
                    base.OnPropertyChanged(() => ReturningDeadline);
                }
            }
        }
        private DateTime? _ReturnDate;
        public DateTime? ReturnDate
        {
            get
            {
                return _ReturnDate;
            }
            set
            {
                if (value != _ReturnDate)
                {
                    _ReturnDate = value;
                    base.OnPropertyChanged(() => ReturnDate);
                }
            }
        }
        public IQueryable<KeyAndValue> PaymentMethodsComboBoxItems
        {
            get
            {
                return
                (
                    from pmethod in DataBase.PaymentMethod
                    where pmethod.IsActive == true
                    select new KeyAndValue
                    {
                        Key = pmethod.IDPaymentMethod,
                        Value = pmethod.Name
                    }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> PaymentStatusesComboBoxItems
        {
            get
            {
                return
                (
                 from pstatus in DataBase.PaymentStatus
                 where pstatus.IsActive == true
                 select new KeyAndValue
                 {
                     Key = pstatus.IDPaymentStatus,
                     Value = pstatus.Name
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
            Item.IsActive = true;
            Item.ReturnDate = ReturnDate;
            Item.ReturnDeadline = ReturningDeadline;           
            var query = DataBase.Borrowing.First(x => x.IDBorrowing == Item.IDBorrowing && x.IsActive == true);
            Item.IDUser = query.IDUser;
            DataBase.OverdueCharge.AddObject(Item);
            DataBase.SaveChanges();
            if (Item.IDPaymentStatus == 1)
            {
                Messenger.Default.Send(DisplayName + "ConfirmPayed");
            }
            else
            {
                Messenger.Default.Send(DisplayName + "ConfirmUnpayed");
            }
            base.OnRequestClose();
        }
        #endregion
        #region Helpers
        private void exportToPDFClick()
        {
            if (IDBorrowing != null && IDPaymentStatus != null && IDPaymentMethod != null && PaymentAmount != null && IDEmployee != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                if (sfd.ShowDialog() == true)
                {
                    Document doc = new Document(PageSize.LETTER);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
                    Chunk linebreak = new Chunk(new LineSeparator(0.5f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1));
                    Font h1 = new Font(bfTimes, 20);
                    Font h2 = new Font(bfTimes, 16, Font.BOLD);
                    Font h3 = new Font(bfTimes, 12);
                    Font h4 = new Font(bfTimes, 12, Font.BOLD);

                    doc.Add(new Paragraph("Bibioteka publiczna im. Hansa Christiana Andersena", h1));
                    doc.Add(new Paragraph("Faktura", h2));
                    doc.Add(new Paragraph("Data wydruku: " + DateTime.Now.ToString("dd/MM/yyyy"), h3));
                    doc.Add(linebreak);
                    doc.Add(new Paragraph("Dane wypożyczenia", h4));
                    doc.Add(new Paragraph("Dane użytkownika: " + BorrowingUser, h3));
                    doc.Add(new Paragraph("ID wypożyczenia: " + IDBorrowing.ToString(), h3));
                    doc.Add(new Paragraph("Tytuł: " + BorrowingTitle, h3));
                    doc.Add(linebreak);
                    DateTime rd = ReturnDate ?? DateTime.Now;
                    DateTime dd = ReturningDeadline ?? DateTime.Now;
                    doc.Add(new Paragraph("Termin oddania: " + dd.ToString("dd/MM/yyyy"), h3));
                    doc.Add(new Paragraph("Data oddania: " + rd.ToString("dd/MM/yyyy"), h3));
                    doc.Add(new Paragraph("Pracownik obsługujący: " + new EmployeeNameBusiness(DataBase).EmployeeName(IDEmployee), h3));
                    doc.Add(linebreak);
                    doc.Add(new Paragraph("Płatność", h4));
                    doc.Add(new Paragraph("Metoda płatności: " + new PaymentMethodNameBusiness(DataBase).PaymentMethodName(IDPaymentMethod), h3));
                    doc.Add(new Paragraph("Status płatności: " + new PaymentStatusNameBusiness(DataBase).PaymentStatusName(IDPaymentStatus), h3));
                    doc.Add(new Paragraph("Kwota do zapłaty: " + PaymentAmount.ToString() + " zł", h3));
                    if (Remarks != null && Remarks != "")
                    {
                        doc.Add(linebreak);
                        doc.Add(new Paragraph("Uwagi", h4));
                        doc.Add(new Paragraph(Remarks, h3));
                    }
                    doc.Close();
                    Messenger.Default.Send("RaportConfirm");
                }
            }
            else
            {
                MessageBox.Show("Nie wprowadzono wszystkich wymaganych pól!");
            }
        }
        private void getSentBorrowing(Borrowing borrowing)
        {
            IDBorrowing = borrowing.IDBorrowing;
            var result = DataBase.Borrowing.First(x => x.IDBorrowing == Item.IDBorrowing);
            BorrowingUser = result.User.Name + " " + result.User.Surname;
            BorrowingTitle = result.Publication.Title;
            ReturnDate = result.ReturningDate;
            ReturningDeadline = result.ReturningDeadline;
        }
        private void getChosenBorrowing(BorrowingForAllView borrowingForAllView)
        {
            if (borrowingForAllView.ReturningDate != null)
            {
                var result = DataBase.OverdueCharge.FirstOrDefault(p => p.IDBorrowing == borrowingForAllView.IDBorrowing);
                if (result != null)
                {
                    MessageBox.Show("Istnieje już kara dla podanego wypożyczenia!");
                }
                else
                {
                    ReturnDate = borrowingForAllView.ReturningDate;
                    IDBorrowing = borrowingForAllView.IDBorrowing;
                    BorrowingTitle = borrowingForAllView.Title;
                    BorrowingUser = borrowingForAllView.UserName;
                    ReturningDeadline = borrowingForAllView.ReturningDeadline;
                }
            }
            else
            {
                ReturnDate = null;
                MessageBox.Show("Wypożyczenie o podanym ID nie zostało jeszcze zwrócone!", "Nieprawidłowe ID", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void getChosenEmployee(EmployeeForAllView employeeForAllView)
        {
            IDEmployee = employeeForAllView.IDEmployee;
        }
        private void calculateFinalAmountClick()
        {
            if (IDBorrowing != null)
            {
                PaymentAmount = new OverduePaymentAmountBusiness(DataBase).OverduePayment(IDBorrowing);
            }
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
                return null;
            }
        }
        public override bool IsValid()
        {
            if (IDBorrowing != null && IDEmployee != null && PaymentAmount != null && IDPaymentMethod != null && IDPaymentStatus != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

