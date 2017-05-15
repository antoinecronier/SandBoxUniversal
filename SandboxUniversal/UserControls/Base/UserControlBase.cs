using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandboxUniversal.Models.Base;
using Windows.UI.Xaml.Controls;
using SandboxUniversal.Models;

namespace SandboxUniversal.UserControls.Base
{
    public abstract class UserControlBase : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private Object currentObject;
        public Object CurrentObject
        {
            get { return this.currentObject; }
            set { this.currentObject = value;
                OnPropertyChanged("CurrentObject"); }
        }
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public UserControlBase()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion


    }
}
