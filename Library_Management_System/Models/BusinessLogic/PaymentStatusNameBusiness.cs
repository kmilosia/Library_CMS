using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class PaymentStatusNameBusiness : DatabaseClass
    { 
     #region Constructor
    public PaymentStatusNameBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
    {
    }
    #endregion
    #region Business Functions        
    public string PaymentStatusName(int? ID)
    {
      var result = LibraryIMSEntities.PaymentStatus.FirstOrDefault(p => p.IDPaymentStatus == ID && p.IsActive == true);
            return result.Name;
    }
    #endregion
    }
}
