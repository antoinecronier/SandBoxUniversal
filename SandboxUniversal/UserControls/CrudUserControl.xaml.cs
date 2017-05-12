using SandboxUniversal.Database;
using SandboxUniversal.Models.Base;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SandboxUniversal.UserControls
{
    public abstract partial class CrudUserControl : UserControl
    {
        protected Grid GridDisplay;
        public Button Add;
        public Button Update;
        public Button Delete;

        public CrudUserControl()
        {
            this.InitializeComponent();
            this.GridDisplay = this.gridDisplay;
            this.Add = this.add;
            this.Update = this.update;
            this.Delete = this.delete;
        }
    }

    public class CrudUserControl<T> : CrudUserControl where T : EntityBase
    {
        UserControlBase crudUCDisplay;

        public CrudUserControl(UserControlBase crudUCDisplay)
        {
            this.crudUCDisplay = crudUCDisplay;

            SetupDisplay(crudUCDisplay);
        }

        private void SetupDisplay(UserControlBase crudUCDisplay)
        {
            this.GridDisplay.Children.Add(crudUCDisplay);
        }
    }
}
