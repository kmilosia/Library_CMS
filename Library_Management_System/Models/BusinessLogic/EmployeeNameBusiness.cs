using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class EmployeeNameBusiness : DatabaseClass
    {
     #region Constructor
    public EmployeeNameBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
    {
    }
        #endregion
        #region Business Functions        
        public string EmployeeName(int? ID)
        {
            var result = LibraryIMSEntities.Employee.FirstOrDefault(p => p.IDEmployee == ID && p.IsActive == true);
            return result.Name + " " + result.Surname;
        }
        #endregion
    }
}
