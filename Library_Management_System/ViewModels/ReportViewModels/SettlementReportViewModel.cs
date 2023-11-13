using GalaSoft.MvvmLight.Messaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Library_Management_System.Helper;
using Library_Management_System.Models.BusinessLogic;
using Library_Management_System.Models.Entities;
using Library_Management_System.Models.EntitiesForView;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_System.ViewModels
{
    public class SettlementReportViewModel : WorkspaceViewModel
    {
        #region Properties
        public LibraryIMSEntities LibraryIMSEntities { get; set; }
        private DateTime _DateFrom;
        public DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }
            set
            {
                if (value != _DateFrom)
                {
                    _DateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }
        private DateTime _DateTo;
        public DateTime DateTo
        {
            get
            {
                return _DateTo;
            }
            set
            {
                if (value != _DateTo)
                {
                    _DateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }
        private decimal? _Amount;
        public decimal? Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (value != _Amount)
                {
                    _Amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }      
        #endregion
        #region Commands
        private BaseCommand _CalculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (_CalculateCommand == null)
                {
                    _CalculateCommand = new BaseCommand(() => calculateSettlementClick());
                }
                return _CalculateCommand;
            }
        }
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
        #endregion
        #region Helpers
        private void calculateSettlementClick()
        {
            Amount = new SettlementBusiness(LibraryIMSEntities).ChargeAmountPeriod(DateFrom, DateTo);
            if(Amount == null)
            {
                Amount = 0;
            }
        }
        private void exportToPDFClick()
        {         
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                if (sfd.ShowDialog() == true)
                {
                    Document doc = new Document();
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
                    Chunk linebreak = new Chunk(new LineSeparator(0.5f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1));
                    Font h1 = new Font(bfTimes, 20);
                    Font h2 = new Font(bfTimes, 16, Font.BOLD);
                    Font h3 = new Font(bfTimes, 12);
                    Font h4 = new Font(bfTimes, 12, Font.BOLD);

                    doc.Add(new Paragraph("Bibioteka publiczna im. Hansa Christiana Andersena", h1));
                    doc.Add(new Paragraph("Raport", h2));
                    doc.Add(new Paragraph("Data wydruku: " + DateTime.Now.ToString("dd/MM/yyyy"), h3));
                    doc.Add(linebreak);
                    doc.Add(new Paragraph("Raport rozliczenia opłat za okres:", h4));
                    doc.Add(new Paragraph(DateFrom.Date.ToString("dd/MM/yyyy") + " - " + DateTo.Date.ToString("dd/MM/yyyy"), h3));
                    doc.Add(new Paragraph("Kwota w sumie: " + Amount.ToString() + " zł", h3));
                    doc.Close();
                    Messenger.Default.Send("RaportConfirm");
            }
        }
        #endregion
        #region Constructor
        public SettlementReportViewModel()
        {
            base.DisplayName = "Raport rozliczeń";
            LibraryIMSEntities = new LibraryIMSEntities();
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            Amount = 0;
        }
        #endregion
    }
}
