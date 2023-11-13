using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class StockForAllView
    {
        #region Properties
        public int IDStockAmount { get; set; }
        public int? IDPublication { get; set; }
        public string PublicationTitle { get; set; }
        public string PublicationAuthor { get; set; }
        public int? Amount { get; set; }
        public int? BorrowedAmount { get; set; }
        public DateTime? LastModified { get; set; }
        public int IDEmployee { get; set; }
        public string EmployeeName { get; set; }
        #endregion
    }
}
