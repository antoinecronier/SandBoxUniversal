using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandboxUniversal.Views;
using SandboxUniversal.Database;
using SandboxUniversal.UserControls;
using SandboxUniversal.Models;
using Windows.UI.Xaml.Input;

namespace SandboxUniversal.ViewModels
{
    public class GarageCrudViewModel
    {
        private GarageCrudView garageCrudView;

        public GarageCrudViewModel(GarageCrudView garageCrudView)
        {
            this.garageCrudView = garageCrudView;

            garageUC.CurrentGarage = new Garage("test", 1, 1);
            garageCrud = new CrudUserControl<Garage>(garageUC);
            this.garageCrudView.GarageUC.Children.Add(garageCrud);
            SetupEvents();
        }

        SqliteDBManager<Garage> sqlManagerGarage = new SqliteDBManager<Garage>();
        GarageUserControl garageUC = new GarageUserControl();
        CrudUserControl<Garage> garageCrud;

        private void SetupEvents()
        {
            garageCrud.Add.Tapped += Add_Tapped;
            garageCrud.Delete.Tapped += Delete_Tapped;
            garageCrud.Update.Tapped += Update_Tapped;
            garageCrud.CurrentListView.ItemClick += CurrentListView_ItemClick;
        }

        private void CurrentListView_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            garageUC.CurrentGarage = e.ClickedItem as Garage;
        }

        private void Update_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Update(garageUC.CurrentGarage);
            Garage garage = garageCrud.ListItems.Where(x => x.Id == garageUC.CurrentGarage.Id).FirstOrDefault();
            garageCrud.ListItems.Remove(garage);
            garageCrud.ListItems.Add(garageUC.CurrentGarage);
        }

        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Delete(garageUC.CurrentGarage);
            garageCrud.ListItems.Remove(garageUC.CurrentGarage);
        }

        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sqlManagerGarage.Insert(garageUC.CurrentGarage);
            garageCrud.ListItems.Add(garageUC.CurrentGarage);
        }
    }
}
