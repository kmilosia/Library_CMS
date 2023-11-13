using Library_Management_System.Helper;
using Library_Management_System.Models;
using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_System.ViewModels.Abstract
{
    public abstract class ItemViewModel<T> :WorkspaceViewModel
    {
        #region Fields
        public LibraryIMSEntities DataBase { get; set; }
        public T Item { get; set; }
        #endregion
        #region Constructor
        public ItemViewModel(string displayName)
        {
            base.DisplayName = displayName;
            DataBase = new LibraryIMSEntities();
        }
        #endregion       
        #region Command
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }
        private BaseCommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new BaseCommand(() => cancel());
                }
                return _CancelCommand;
            }
        }
        #endregion
        #region Save
        public abstract void Save();
        private void cancel()
        {
            base.OnRequestClose();
        }
        private void saveAndClose()
        {
            if(IsValid())
            {
                Save();
            }
            else
            {
                MessageBox.Show("Dane nie zostały prawidłowo wprowadzone lub nie wszystkie wymagane pola zostały uzupełnione!");
            }
        }
        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
    }
}
