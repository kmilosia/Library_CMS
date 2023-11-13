using GalaSoft.MvvmLight.Messaging;
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
    public class AllEmployeesViewModel : CollectionViewModel<EmployeeForAllView>
    {
        #region Properties
        private EmployeeForAllView _ChosenEmployee;
        public EmployeeForAllView ChosenEmployee
        {
            get
            {
                return _ChosenEmployee;
            }
            set
            {
                if (_ChosenEmployee != value)
                {
                    _ChosenEmployee = value;
                    if (forward)
                    {
                        forward = false;
                        Messenger.Default.Send(_ChosenEmployee);
                        OnRequestClose();
                    }
                    base.OnPropertyChanged(() => _ChosenEmployee);
                }
            }
        }
        #endregion
        #region Constructor
        public AllEmployeesViewModel()
            : base("Pracownicy")
        {
            Messenger.Default.Register<string>(this, listen);
        }
        bool forward = false;
        public void listen(string name)
        {
            if (name == "Forward")
            {
                forward = true;
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EmployeeForAllView>
                (
                    from employee in LibraryIMSEntities.Employee
                    where employee.IsActive == true
                    select new EmployeeForAllView
                    {
                        IDEmployee = employee.IDEmployee,
                        Name = employee.Name + " " + employee.Surname,
                        Birthday = employee.Birthday,
                        GenderName = employee.Gender.Name,
                        PositionName = employee.Position.Name,
                        Email = employee.Contact.Email,
                        PhoneNumber = employee.Contact.PhoneNumber,
                        Address = employee.Address.Street + "/" + employee.Address.HouseNumber +
                        employee.Address.Postcode + employee.Address.City + " " + employee.Address.Country
                    }
                );
        }
        public override void Delete()
        {
            var person = LibraryIMSEntities.Employee.First(x => x.IDEmployee == ChosenEmployee.IDEmployee);
            var address = LibraryIMSEntities.Address.First(x => x.IDAddress == person.IDAddress);
            var contact = LibraryIMSEntities.Contact.First(x => x.IDContact == person.IDContact);
            person.IsActive = false;
            address.IsActive = false;
            contact.IsActive = false;
            LibraryIMSEntities.SaveChanges();
            Messenger.Default.Send("Delete");
            Load();
        }
        #endregion
        #region Find and Sort
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "ID", "Imię i nazwisko", "Data urodzenia", "Stanowisko" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.OrderBy(item => item.IDEmployee));
            }
            if (SortField == "Imię i nazwisko")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.OrderBy(item => item.Name));
            }
            if (SortField == "Data urodzenia")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.OrderBy(item => item.Birthday));
            }
            if (SortField == "Stanowisko")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.OrderBy(item => item.PositionName));
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "ID", "Imię i nazwisko", "Data urodzenia", "Stanowisko" };
        }
        public override void Find()
        {
            if (FindField == "ID")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.Where(item => item.IDEmployee.Equals(FindTextbox)));
            }
            if (FindField == "Imię i nazwisko")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.Where(item => item.Name != null && item.Name.Contains(FindTextbox)));
            }
            if (FindField == "Data urodzenia")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.Where(item => item.Birthday != null && item.Birthday.Equals(DateTime.Parse(FindTextbox))));
            }
            if (FindField == "Stanowisko")
            {
                List = new ObservableCollection<EmployeeForAllView>(List.Where(item => item.PositionName != null && item.PositionName.Contains(FindTextbox)));
            }
        }
        #endregion
    }
}
