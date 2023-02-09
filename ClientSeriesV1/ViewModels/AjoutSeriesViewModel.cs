using ClientSeriesV1.Models;
using ClientSeriesV1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeriesV1.ViewModels
{
    public class AjoutSeriesViewModel : ObservableObject, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private Series serieAdd;

        public Series SerieAdd
        {
            get { return serieAdd; }
            set { serieAdd = value;
                OnPropertyChanged();
            } 
        }

        public IRelayCommand BtnSetAddSerie { get; }
        public AjoutSeriesViewModel() 
        {

            BtnSetAddSerie = new RelayCommand(ActionSetAddSerie);
            SerieAdd = new Series();

        }
        private async void MessageAsync(string content, string title)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };
            noWifiDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }

        private async void ActionSetAddSerie()
        {
            WSService service = new WSService("https://apiseriesvcout2.azurewebsites.net/");

            if (SerieAdd.Titre == null || SerieAdd.NbSaisons < 0 || SerieAdd.NbEpisodes < 0 || SerieAdd.AnneeCreation > DateTime.Now.Year || SerieAdd.Network == null)
            {
                MessageAsync("Erreur, il manque un champ ou une erreur dans l'insertion", "Erreur");
            }
            else
            {

                var resut = await service.PostSeriesAsync("api/series", SerieAdd);
                if (resut)
                {
                    MessageAsync("Votre serie a été bien insérée ! ", "Valide");
                }
                else
                {
                    MessageAsync("Erreur, il manque un champ ou une erreur dans l'insertion", "Erreur");
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
