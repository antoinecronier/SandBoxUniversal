using SandboxUniversal.Database;
using SandboxUniversal.Models;
using SandboxUniversal.UserControls;
using SandboxUniversal.UserControls.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SandboxUniversal
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SqliteDBManager<Garage> sqlManagerGarage = new SqliteDBManager<Garage>();
        GarageUserControl garageUC = new GarageUserControl();
        CrudUserControl<Garage> garageCrud;
        public MainPage()
        {
            this.InitializeComponent();
            garageUC.CurrentGarage = new Garage("test", 1, 1);
            garageCrud = new CrudUserControl<Garage>(garageUC);
            this.GarageUC.Children.Add(garageCrud);
            SetupEvents();
        }

        private void SetupEvents()
        {
            garageCrud.Add.Tapped += Add_Tapped;
            garageCrud.Delete.Tapped += Delete_Tapped;
            garageCrud.Update.Tapped += Update_Tapped;
        }

        private void Update_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Update(garageUC.CurrentGarage);
        }

        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Delete(garageUC.CurrentGarage);
        }

        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Insert(garageUC.CurrentGarage);
        }

        private void button_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }
    }
} 