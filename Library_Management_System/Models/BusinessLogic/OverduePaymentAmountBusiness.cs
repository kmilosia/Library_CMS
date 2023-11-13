using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class OverduePaymentAmountBusiness : DatabaseClass
    {
        #region Constructor
        public OverduePaymentAmountBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
        {
        }
        #endregion
        #region Business Functions        
            public decimal? OverduePayment(int? idBorrowing)
            {
            DailyRate rateQ = (
            from x in LibraryIMSEntities.DailyRate
            where x.IDDailyRate == 1
            select x
            ).SingleOrDefault();
            decimal? rate = rateQ.Rate;

            Borrowing borrowingQ = (
                from p in LibraryIMSEntities.Borrowing
                where p.IDBorrowing == idBorrowing &&
                p.IsActive == true
                select p
                ).SingleOrDefault();
            if(borrowingQ.ReturningDate > borrowingQ.ReturningDeadline)
            {
                double days = (borrowingQ.ReturningDate.Value.Date - borrowingQ.ReturningDeadline.Value.Date).TotalDays;
                return rate * (decimal)days;
            }
            return 0;
        }
        #endregion
    }
}
