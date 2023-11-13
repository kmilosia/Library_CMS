using Library_Management_System.Helper;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Drawing;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Threading;

namespace Library_Management_System.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        private string _StatusInformation;
        public string StatusInformation
        {
            get
            {
                return _StatusInformation;
            }
            set
            {
                if (value != _StatusInformation)
                {
                    _StatusInformation = value;
                    base.OnPropertyChanged(() => StatusInformation);
                }
            }
        }
        #endregion
        #region Menu and Toolbar Commands      
        public ICommand StockCommand
        {
            get
            {
                return new BaseCommand(() => createView(new StockViewModel()));
            }
        }
        public ICommand NewUserCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewUserViewModel()));
            }
        }
        public ICommand NewEmployeeCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewEmployeeViewModel()));
            }
        }
        public ICommand ReturningCommand
        {
            get
            {
                return new BaseCommand(() => createView(new ReturningViewModel()));
            }
        }
        public ICommand AllUsersCommand
        {
            get
            {
                return new BaseCommand(showAllUsers);
            }
        }
        public ICommand AllEmployeesCommand
        {
            get
            {
                return new BaseCommand(showAllEmployees);
            }
        }
        public ICommand AllBorrowingsCommand
        {
            get
            {
                return new BaseCommand(showAllBorrowings);
            }
        }
        public ICommand AllPublishersCommand
        {
            get
            {
                return new BaseCommand(showAllPublishers);
            }
        }
        public ICommand AllAuthorsCommand
        {
            get
            {
                return new BaseCommand(showAllAuthors);
            }
        }
        public ICommand NewPublicationCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewPublicationViewModel()));
            }
        }
        public ICommand AllPublicationsCommand
        {
            get
            {
                return new BaseCommand(showAllPublications);
            }
        }
        public ICommand StockUpdateCommand
        {
            get
            {
                return new BaseCommand(() => createView(new StockUpdateViewModel()));
            }
        }
        public ICommand BorrowingCommand
        {
            get
            {
                return new BaseCommand(() => createView(new BorrowingViewModel()));
            }
        }      
        public ICommand NewPublisherCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewPublisherViewModel()));
            }
        }
        public ICommand NewAuthorCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewAuthorViewModel()));
            }
        }
        public ICommand OverdueChargeCommand
        {
            get
            {
                return new BaseCommand(() => createView(new OverdueChargeViewModel()));
            }
        }
        public ICommand AllOverdueChargesCommand
        {
            get
            {
                return new BaseCommand(showAllOverdueCharges);
            }
        }
        public ICommand SettlementReportCommand
        {
            get
            {
                return new BaseCommand(() => createView(new SettlementReportViewModel()));
            }
        }
        public ICommand NewCategoryCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewCategoryViewModel()));
            }
        }
        public ICommand NewSubcategoryCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewSubcategoryViewModel()));
            }
        }
        public ICommand NewLocationCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewLocationViewModel()));
            }
        }
        public ICommand NewPositionCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NewPositionViewModel()));
            }
        }
        public ICommand UpdateDailyRateCommand
        {
            get
            {
                return new BaseCommand(() => createView(new UpdateDailyRateViewModel()));
            }
        }
        #endregion
        #region Left Panel Buttons
        private ReadOnlyCollection<CommandViewModel> _Commands; 
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel("/Views/Icons/renting.png","Wypożyczenia",new BaseCommand(()=>createView(new BorrowingViewModel()))),
                new CommandViewModel("/Views/Icons/returning.png","Zwroty",new BaseCommand(()=>createView(new ReturningViewModel()))),
                new CommandViewModel("/Views/Icons/numberlist.png","Spis wypożyczeń",new BaseCommand(showAllBorrowings)),
                new CommandViewModel("/Views/Icons/book.png","Publikacja",new BaseCommand(()=>createView(new NewPublicationViewModel()))),
                new CommandViewModel("/Views/Icons/list.png","Spis publikacji",new BaseCommand(showAllPublications)),
                new CommandViewModel("/Views/Icons/stock.png","Stan magazynu",new BaseCommand(showStock)),
                new CommandViewModel("/Views/Icons/inventory.png","Inwentaryzacja magazynu",new BaseCommand(()=>createView(new StockUpdateViewModel()))),
                new CommandViewModel("/Views/Icons/person.png","Użytkownik",new BaseCommand(()=>createView(new NewUserViewModel()))),
                new CommandViewModel("/Views/Icons/people.png","Spis użytkowników",new BaseCommand(showAllUsers)),
                new CommandViewModel("/Views/Icons/setting.png","Pracownik",new BaseCommand(()=>createView(new NewEmployeeViewModel()))),
                new CommandViewModel("/Views/Icons/payment.png","Opłata za przetrzymanie",new BaseCommand(()=>createView(new OverdueChargeViewModel()))),
                new CommandViewModel("/Views/Icons/money.png","Wszystkie opłaty",new BaseCommand(showAllOverdueCharges)),

            };
        }
        #endregion
        #region Workspaces
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Helper Functions
        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        private void showStock()
        {
            StockViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is StockViewModel) as StockViewModel;
            if (workspace == null)
            {
                workspace = new StockViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllUsers()
        {
            AllUsersViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllUsersViewModel) as AllUsersViewModel;
            if (workspace == null)
            {
                workspace = new AllUsersViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllPublishers()
        {
            AllPublishersViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllPublishersViewModel) as AllPublishersViewModel;
            if (workspace == null)
            {
                workspace = new AllPublishersViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllAuthors()
        {
            AllAuthorsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllAuthorsViewModel) as AllAuthorsViewModel;
            if (workspace == null)
            {
                workspace = new AllAuthorsViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllOverdueCharges()
        {
            AllOverdueChargesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllOverdueChargesViewModel) as AllOverdueChargesViewModel;
            if (workspace == null)
            {
                workspace = new AllOverdueChargesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllEmployees()
        {
            AllEmployeesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllEmployeesViewModel) as AllEmployeesViewModel;
            if (workspace == null)
            {
                workspace = new AllEmployeesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllBorrowings()
        {
            AllBorrowingsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllBorrowingsViewModel) as AllBorrowingsViewModel;
            if (workspace == null)
            {
                workspace = new AllBorrowingsViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }       
        private void showAllPublications()
        {
            AllPublicationsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllPublicationsViewModel) as AllPublicationsViewModel;
            if (workspace == null)
            {
                workspace = new AllPublicationsViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }      
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }             
        private void open(string name)
        {
            if (name == "WydawnictwaAdd")
            {
                createView(new NewPublisherViewModel());
            }
            if (name == "AutorzyAdd")
            {
                createView(new NewAuthorViewModel());
            }                       
            if (name == "OpłatyAdd")
            {
                createView(new OverdueChargeViewModel());
            }
            if (name == "PublikacjeAdd")
            {
                createView(new NewPublicationViewModel());
            }
            if (name == "PracownicyAdd")
            {
                createView(new NewEmployeeViewModel());
            }
            if (name == "UżytkownicyAdd")
            {
                createView(new NewUserViewModel());
            }
            if (name == "Stan magazynuAdd")
            {
                createView(new NewPublicationViewModel());
            }
            if (name == "KategoriaAdd")
            {
                createView(new NewCategoryViewModel());
                Messenger.Default.Send("Forward");
            }
            if (name == "PodkategoriaAdd")
            {
                createView(new NewSubcategoryViewModel());
                Messenger.Default.Send("Forward");
            }
            if (name == "LokalizacjaAdd")
            {
                createView(new NewLocationViewModel());
                Messenger.Default.Send("Forward");
            }
            if (name == "BorrowingsAll")
            {
                showAllBorrowings();
                Messenger.Default.Send("Forward");
            }
            if (name == "PublicationsAll")
            {
                showAllPublications();
                Messenger.Default.Send("Forward");
            }
            if (name == "EmployeesAll")
            {
                showAllEmployees();
                Messenger.Default.Send("Forward");
            }
            if (name == "UsersAll")
            {
                showAllUsers();
                Messenger.Default.Send("Forward");
            }
            if (name == "AuthorsAll")
            {
                showAllAuthors();
                Messenger.Default.Send("Forward");
            }
            if (name == "PublishersAll")
            {
                showAllPublishers();
                Messenger.Default.Send("Forward");
            }
            if (name == "Overdue")
            {
                createView(new OverdueChargeViewModel());
            }
            if (name == "WypożyczenieConfirm")
            {
                StatusInformation = "Publikacja została pomyślnie wypożyczona!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "ZwrotConfirm")
            {
                StatusInformation = "Publikacja została pomyślnie zwrócona!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "PublikacjaConfirm")
            {
                StatusInformation = "Nowa publikacja została pomyślnie dodana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "MagazynConfirm")
            {
                StatusInformation = "Stan magazynu został zaktualizowany!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "UżytkownikConfirm")
            {
                StatusInformation = "Nowy użytkownik został dodany!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "PracownikConfirm")
            {
                StatusInformation = "Nowy pracownik został dodany!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "OpłataConfirmPayed")
            {
                StatusInformation = "Pomyślnie opłacono karę za przetrzymanie publikacji!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "OpłataConfirmUnpayed")
            {
                StatusInformation = "Kara nie została opłacona! Opłata została zapisana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "PodkategoriaConfirm")
            {
                StatusInformation = "Nowa podkategoria została dodana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "LokalizacjaConfirm")
            {
                StatusInformation = "Nowa lokalizacja została dodana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "StanowiskoConfirm")
            {
                StatusInformation = "Nowe stanowisko zostało dodane!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "KategoriaConfirm")
            {
                StatusInformation = "Nowa kategoria została dodana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "RataConfirm")
            {
                StatusInformation = "Rata dzienna została zaktualizowana!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "RaportConfirm")
            {
                StatusInformation = "Raport został pomyślnie eksportowany do pliku PDF!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
            if (name == "Delete")
            {
                StatusInformation = "Pozycja została usunięta!";
                Task.Delay(TimeSpan.FromMilliseconds(3000)).ContinueWith(task => StatusInformation = "");
            }
        }
        

        #endregion
    }
}
