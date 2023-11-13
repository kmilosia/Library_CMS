using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class OverdueChargeForAllView
    {
        #region Properties
        public int IDOverdueCharge { get; set; }
        public int IDBorrowing { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public Decimal? PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? ReturningDate { get; set; }
        public DateTime? ReturningDeadline { get; set; }
        public string Remarks { get; set; }
        #endregion
    }
}
