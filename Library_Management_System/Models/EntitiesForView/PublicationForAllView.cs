using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class PublicationForAllView
    {
        #region Properties
        public int IDPublication { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }
        public string AuthorName { get; set; }
        public string Availability { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublishedYear { get; set; }
        public string PagesNumber { get; set; }
        public string Volume { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
