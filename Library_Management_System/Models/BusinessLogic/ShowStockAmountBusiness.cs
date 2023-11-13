using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class ShowStockAmountBusiness : DatabaseClass
    {
        #region Constructor
        public ShowStockAmountBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
        {
        }
        #endregion
        #region Business Functions
        public int? StockAmountPublication(int? idPublication)
        {
            return
            (
                from amount in LibraryIMSEntities.StockAmount
                where
                amount.IDPublication == idPublication &&
                amount.IsActive == true
                select
                amount.Amount
            ).Sum();
        }
        #endregion
    }
}
