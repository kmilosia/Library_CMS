using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;

namespace Library_Management_System.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public string displayImage { get; set; } //DELETE?
        public string DisplayName { get; set; }
        public ICommand Command { get; set; }        
        #endregion
        #region Constructor
        public CommandViewModel(string displayImage,string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            this.displayImage = displayImage;//DELETE?
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion
    }
}
