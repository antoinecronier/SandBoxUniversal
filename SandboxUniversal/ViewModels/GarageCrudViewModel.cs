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
using TextToSpeechClassLibrary;
using Windows.ApplicationModel.Core;
using SpeechToTextClassLibrary;

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
            garageCrudView.Button.Tapped += Button_Tapped;
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SpeechToText.Instance.HaveResult -= Instance_HaveResult;
            SpeechToText.Instance.HaveResult += Instance_HaveResult;

            SpeechToText.Instance.StartRecognization();
        }

        private void Instance_HaveResult(object sender, SpeechToText.SpeechToTextEventArgs e)
        {
            String res = e.SpeechResultAll.ToString();
            string res1 = e.SpeechResult.ToString();
        }

        private void CurrentListView_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            garageUC.CurrentGarage = e.ClickedItem as Garage;
            TextToSpeech.Instance.ChangeText(ReadGarageUC());
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

        private void TextToSpeechLauncher()
        {
            TextToSpeech.Instance.PauseEvent += Instance_PauseEvent;
            TextToSpeech.Instance.PlayEvent += Instance_PlayEvent;
            TextToSpeech.Instance.ResumeEvent += Instance_ResumeEvent;
            TextToSpeech.Instance.StopEvent += Instance_StopEvent;

            garageCrudView.Unloaded += GarageCrudView_Unloaded;
            
            Launch();
        }

        private void Launch()
        {
            TextToSpeech.Instance.Play("Vous etes sur la page de GarageCrudView." + ReadGarageUC());
        }

        private String ReadGarageUC()
        {
            String name = "L'attribut " + garageUC.GarageNameBlock.Text + " contient la valeur " + garageUC.GarageNameBox.Text + ".";
            String sold = "L'attribut " + garageUC.GarageSoldBlock.Text + " contient la valeur " + garageUC.GarageSoldBox.Text + ".";
            String nbPlace = "L'attribut " + garageUC.GarageNbPlaceBlock.Text + " contient la valeur " + garageUC.GarageNbPlaceBox.Text + ".";
            return name + sold + nbPlace;
        }

        private void GarageCrudView_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TextToSpeech.Instance.PauseEvent -= Instance_PauseEvent;
            TextToSpeech.Instance.PlayEvent -= Instance_PlayEvent;
            TextToSpeech.Instance.ResumeEvent -= Instance_ResumeEvent;
            TextToSpeech.Instance.StopEvent -= Instance_StopEvent;
        }

        private void Instance_StopEvent(object sender, EventArgs e)
        {
        }

        private void Instance_ResumeEvent(object sender, EventArgs e)
        {
        }

        private void Instance_PlayEvent(object sender, EventArgs e)
        {
        }

        private void Instance_PauseEvent(object sender, EventArgs e)
        {
        }
    }
}
