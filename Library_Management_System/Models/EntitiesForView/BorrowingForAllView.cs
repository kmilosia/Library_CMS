using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class BorrowingForAllView
    {
        #region Properties
        public int IDBorrowing { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public int? IDPublication { get; set; }
        public string Title { get; set; }
        public DateTime? BorrowingDate { get; set; }
        public DateTime? ReturningDate { get; set; }
        public DateTime? ReturningDeadline { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        #endregion
    }
}
