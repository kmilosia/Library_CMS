using GalaSoft.MvvmLight.Messaging;
using Library_Management_System.Helper;
using Library_Management_System.Models;
using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Management_System.ViewModels.Abstract
{
    public abstract class CollectionViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        private readonly LibraryIMSEntities libraryIMSEntities;
        public LibraryIMSEntities LibraryIMSEntities 
        { 
            get
            {
                return libraryIMSEntities;
            }
        }
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new BaseCommand(() => Delete());
                }
                return _DeleteCommand;
            }
        }
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor
        public CollectionViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.libraryIMSEntities = new LibraryIMSEntities();
        }
        #endregion
        #region Sort
        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        public abstract void Sort();
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public abstract List<string> GetComboboxSortList();
        #endregion
        #region Find
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        public abstract void Find();
        public string FindField { get; set; }
        public string FindTextbox { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public abstract List<string> GetComboboxFindList();
        #endregion
        #region Helpers
        public abstract void Load();
        public abstract void Delete();
        private void Add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }              
        #endregion
    }
}
