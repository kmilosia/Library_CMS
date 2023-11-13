using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class EmployeeForAllView
    {
        #region Properties
        public int IDEmployee { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string PositionName { get; set; }
        public string GenderName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        #endregion
    }
}
