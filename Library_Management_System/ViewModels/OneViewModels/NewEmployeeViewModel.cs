using GalaSoft.MvvmLight.Messaging;
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

namespace Library_Management_System.ViewModels
{
    public class NewEmployeeViewModel : ItemViewModel<Employee>, IDataErrorInfo
    {
        #region Constructor
        public Contact Item2 { get; set; }
        public Address Item3 { get; set; }
        public NewEmployeeViewModel()
            : base("Pracownik")
        {
            Item = new Employee();
            Item2 = new Contact();
            Item3 = new Address();
        }
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return Item.Name;
            }
            set
            {
                if (value != Item.Name)
                {
                    Item.Name = value;
                    base.OnPropertyChanged(() => Name);
                }
            }
        }
        public string Surname
        {
            get
            {
                return Item.Surname;
            }
            set
            {
                if (value != Item.Surname)
                {
                    Item.Surname = value;
                    base.OnPropertyChanged(() => Surname);
                }
            }
        }
        public DateTime? Birthday
        {
            get
            {
                return Item.Birthday;
            }
            set
            {
                if (value != Item.Birthday)
                {
                    Item.Birthday = value;
                    base.OnPropertyChanged(() => Birthday);
                }
            }
        }
        public int? IDGender
        {
            get
            {
                return Item.IDGender;
            }
            set
            {
                if (value != Item.IDGender)
                {
                    Item.IDGender = value;
                    base.OnPropertyChanged(() => IDGender);
                }
            }
        }
        public int? IDPosition
        {
            get
            {
                return Item.IDPosition;
            }
            set
            {
                if (value != Item.IDPosition)
                {
                    Item.IDPosition = value;
                    base.OnPropertyChanged(() => IDPosition);
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return Item2.PhoneNumber;
            }
            set
            {
                if (value != Item2.PhoneNumber)
                {
                    Item2.PhoneNumber = value;
                    base.OnPropertyChanged(() => PhoneNumber);
                }
            }
        }
        public string Email
        {
            get
            {
                return Item2.Email;
            }
            set
            {
                if (value != Item2.Email)
                {
                    Item2.Email = value;
                    base.OnPropertyChanged(() => Email);
                }
            }
        }
        public string Street
        {
            get
            {
                return Item3.Street;
            }
            set
            {
                if (value != Item3.Street)
                {
                    Item3.Street = value;
                    base.OnPropertyChanged(() => Street);
                }
            }
        }
        public string HouseNumber
        {
            get
            {
                return Item3.HouseNumber;
            }
            set
            {
                if (value != Item3.HouseNumber)
                {
                    Item3.HouseNumber = value;
                    base.OnPropertyChanged(() => HouseNumber);
                }
            }
        }
        public string Postcode
        {
            get
            {
                return Item3.Postcode;
            }
            set
            {
                if (value != Item3.Postcode)
                {
                    Item3.Postcode = value;
                    base.OnPropertyChanged(() => Postcode);
                }
            }
        }
        public string City
        {
            get
            {
                return Item3.City;
            }
            set
            {
                if (value != Item3.City)
                {
                    Item3.City = value;
                    base.OnPropertyChanged(() => City);
                }
            }
        }
        public string Country
        {
            get
            {
                return Item3.Country;
            }
            set
            {
                if (value != Item3.Country)
                {
                    Item3.Country = value;
                    base.OnPropertyChanged(() => Country);
                }
            }
        }
        public IQueryable<KeyAndValue> GendersComboBoxItems
        {
            get
            {
                return
                (
                    from gender in DataBase.Gender
                    where gender.IsActive == true
                    select new KeyAndValue
                    {
                        Key = gender.IDGender,
                        Value = gender.Name
                    }
                ).ToList().AsQueryable();
            }
        }
        public IQueryable<KeyAndValue> PositionsComboBoxItems
        {
            get
            {
                return
                (
                    from position in DataBase.Position
                    where position.IsActive == true
                    select new KeyAndValue
                    {
                        Key = position.IDPosition,
                        Value = position.Name
                    }
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            Item2.IsActive = true;
            Item3.IsActive = true;
            Item.IDAddress = Item3.IDAddress;
            Item.IDContact = Item2.IDContact;
            DataBase.Employee.AddObject(Item);
            DataBase.Contact.AddObject(Item2);
            DataBase.Address.AddObject(Item3);
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
                if (name == "Name")
                {
                    komunikat = StringValidator.HasCapitalLetter(Name);
                }
                if (name == "Surname")
                {
                    komunikat = StringValidator.HasCapitalLetter(Surname);
                }
                if (name == "Email")
                {
                    komunikat = StringValidator.IsEmail(Email);
                    var result = DataBase.Contact.FirstOrDefault(p => p.Email == Email && p.IsActive == true);
                    if (result != null)
                    {
                        komunikat = "Istnieje już konto powiązane z podanym adresem email!";
                    }
                }
                if (name == "PhoneNumber")
                {
                    komunikat = StringValidator.IsPhoneNumber(PhoneNumber);
                    var result = DataBase.Contact.FirstOrDefault(p => p.PhoneNumber == PhoneNumber && p.IsActive == true);
                    if (result != null)
                    {
                        komunikat = "Istnieje już konto powiązane z podanym numerem telefonu!";
                    }
                }
                if (name == "City")
                {
                    komunikat = StringValidator.HasCapitalLetter(City);
                }
                if (name == "Country")
                {
                    komunikat = StringValidator.HasCapitalLetter(Country);
                }                
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (Name != null && Surname != null && IDGender != null && Birthday != null && Email != null && PhoneNumber != null && IDPosition != null && Street != null && Postcode != null && City != null && Country != null)
            {
                if (this["Email"] == null && this["PhoneNumber"] == null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
