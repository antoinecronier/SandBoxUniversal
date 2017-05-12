using SandboxUniversal.Models;
using SandboxUniversal.UserControls.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SandboxUniversal.Models.Base;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SandboxUniversal.UserControls
{
    public sealed partial class GarageUserControl : UserControlBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private Garage currentGarage;
        #endregion

        #region Properties
        public Garage CurrentGarage
        {
            get { return currentGarage; }
            set
            {
                currentGarage = value;
                base.OnPropertyChanged("CurrentGarage");
            }
        }
        #endregion

        #region Constructors
        public GarageUserControl()
        {
            this.InitializeComponent();
            base.DataContext = this;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}
