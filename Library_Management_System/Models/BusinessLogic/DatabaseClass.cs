using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    //main class for business logic classes to inherit from - classes which use database
    public class DatabaseClass
    {
        #region Entities
        public LibraryIMSEntities LibraryIMSEntities { get; set; }
        #endregion
        #region Constructor
        public DatabaseClass(LibraryIMSEntities libraryIMSEntities)
        {
            this.LibraryIMSEntities = libraryIMSEntities;
        }
        #endregion
    }
}
