using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.EntitiesForView
{
    public class PublisherForAllView
    {
        #region Properties
        public int IDPublisher { get; set; }
        public string Name { get; set; }
        public string FoundingYear { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
