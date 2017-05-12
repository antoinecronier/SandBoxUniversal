using SandboxUniversal.Database;
using SandboxUniversal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class GarageListUserControl : UserControl
    {
        public ObservableCollection<Garage> Garages { get; set; }

        public GarageListUserControl()
        {
            this.InitializeComponent();
            Garages = new ObservableCollection<Garage>();
            this.currentListView.ItemsSource = Garages;
            SetupList();
        }

        private void SetupList()
        {
            SqliteDBManager<Garage> garageManager = new SqliteDBManager<Garage>();
            foreach (var item in garageManager.Get())
            {
                Garages.Add(item);
            }
        }
    }
}
