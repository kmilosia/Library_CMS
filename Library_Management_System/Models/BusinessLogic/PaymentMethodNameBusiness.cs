using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.BusinessLogic
{
    public class PaymentMethodNameBusiness : DatabaseClass
    { 
     #region Constructor
    public PaymentMethodNameBusiness(LibraryIMSEntities libraryIMSEntities)
        : base(libraryIMSEntities)
    {
    }
        #endregion
        #region Business Functions        
        public string PaymentMethodName(int? ID)
        {
            var result = LibraryIMSEntities.PaymentMethod.FirstOrDefault(p => p.IDPaymentMethod == ID && p.IsActive == true);
            return result.Name;
        }
        #endregion
    }
}
