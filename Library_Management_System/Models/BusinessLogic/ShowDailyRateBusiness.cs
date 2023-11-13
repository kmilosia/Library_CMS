using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class ShowDailyRateBusiness : DatabaseClass
    {
        #region Constructor
        public ShowDailyRateBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
        {
        }
        #endregion
        #region Business Functions
        public decimal? ShowRate()
        {
            return
            (
                from rate in LibraryIMSEntities.DailyRate
                where
                rate.IsActive == true && rate.IDDailyRate == 1
                select
                rate.Rate
            ).First();
        }
        #endregion
    }
}
