using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class ShowAvailableAmount : DatabaseClass
    {
        #region Constructor
        public ShowAvailableAmount(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
        {
        }
        #endregion
        #region Business Functions
        public int? AvailableAmountPublication(int? idPublication)
        {
            if (idPublication != null && idPublication != 0)
            {
                StockAmount query =
                (
                    from x in LibraryIMSEntities.StockAmount
                    where x.IDPublication == idPublication &&
                    x.IsActive == true
                    select x
                ).SingleOrDefault();

                int? available = query.Amount - query.BorrowedAmount;
                if (available != null || available > 0)
                    return available;
                else
                    return 0;
            }
            return null;

        }
        #endregion
    }
}
