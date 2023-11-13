using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class AuthorForAllView
    {
        #region Properties
        public int IDAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
