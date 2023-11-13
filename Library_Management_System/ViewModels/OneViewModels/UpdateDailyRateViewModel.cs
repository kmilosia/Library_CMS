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
    public class UpdateDailyRateViewModel : ItemViewModel<DailyRate>, IDataErrorInfo
    {
        #region Constructor
        public UpdateDailyRateViewModel()
            : base("Rata")
        {
            Item = new DailyRate();
        }
        #endregion
        #region Properties
        private decimal? _Rate;
        public decimal? Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                if (value != _Rate)
                {
                    _Rate = value;
                    OnPropertyChanged(() => Rate);
                }
            }
        }
        private decimal? _CurrentRate;
        public decimal? CurrentRate
        {
            get
            {
                return _CurrentRate;
            }
            set
            {
                if (value != _CurrentRate)
                {
                    _CurrentRate = value;
                    OnPropertyChanged(() => CurrentRate);
                }
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ShowRateCommand;
        public ICommand ShowRateCommand
        {
            get
            {
                if (_ShowRateCommand == null)
                {
                    _ShowRateCommand = new BaseCommand(() => showRate());
                }
                return _ShowRateCommand;
            }
        }
        #endregion
        #region Helpers
        private void showRate()
        {
            CurrentRate = new ShowDailyRateBusiness(DataBase).ShowRate();
        }
        #endregion
        #region Save
        public override void Save()
        {
            var result = DataBase.DailyRate.FirstOrDefault(p => p.IDDailyRate == 1);
            result.Rate = Rate;
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
                if (name == "Rate")
                {
                    komunikat = BusinessValidator.IsCorrectRate(Rate);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {           
                if (this["Rate"] == null && Rate != null)
                {
                    return true;
                }            
            return false;
        }
        #endregion
    }
}
