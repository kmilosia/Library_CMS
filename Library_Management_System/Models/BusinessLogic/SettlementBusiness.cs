using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class SettlementBusiness : DatabaseClass
    {
        #region Constructor
        public SettlementBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
        {
        }
        #endregion
        #region Business Functions
        public decimal? ChargeAmountPeriod(DateTime dateFrom, DateTime dateTo)
        {
            return
            (
                from amount in LibraryIMSEntities.OverdueCharge
                where
                amount.ReturnDate >= dateFrom &&
                amount.ReturnDate <= dateTo &&
                amount.IDPaymentStatus == 1 &&
                amount.IsActive == true
                select
                amount.PaymentAmount
            ).Sum();
        }
        #endregion
    }
}
