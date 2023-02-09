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
    public class SearchModiDeleteSerieViewModel : ObservableObject
    {
       
        private int idSerie;
        public int IdSerie
        {
            get { return idSerie; }
            set { idSerie = value; }
        }

        private Series seriesSearched;
        public Series SeriesSearched
        {
            get { return seriesSearched; }
            set { seriesSearched = value;
                OnPropertyChanged();
            }
        }


        public IRelayCommand BtnUpdateId { get; }

        public IRelayCommand BtnSearchId { get; }
        public IRelayCommand BtnDeleteId { get; }

        public SearchModiDeleteSerieViewModel()
        {
            SeriesSearched = new Series();
            BtnDeleteId = new RelayCommand(ActionDeleteId);
            BtnSearchId = new RelayCommand(ActionSearchId);
            BtnUpdateId = new RelayCommand(ActionUpdateId);
        }


        private async void ActionDeleteId()
        {
            WSService service = new WSService("https://apiseriesvcout2.azurewebsites.net/");
            if (IdSerie <= 0 || IdSerie == null)
                MessageAsync("Veuillez entrez un numéro de serie", "Erreur");
            else
            {
                var result = await service.DeleteSeriesAsync(IdSerie);
                if (result)
                    MessageAsync("Vous avez bien supprimé la serie", "Valide");
                else
                    MessageAsync("La serie n'a pas pu être supprimer", "Erreur");
            }
        }

        private async void ActionSearchId()
        {
            WSService service = new WSService("https://apiseriesvcout2.azurewebsites.net/");

            if (IdSerie <= 0 || IdSerie == null)
                MessageAsync("Veuillez entrez un numéro de serie", "Erreur");
            var series = await service.GetSeriesAsync(IdSerie);
            SeriesSearched = series;
        }

        private async void ActionUpdateId()
        {
            WSService service = new WSService("https://apiseriesvcout2.azurewebsites.net/");
            if (IdSerie <= 0 || IdSerie == null)
                MessageAsync("Veuillez entrez un numéro de serie", "Erreur");
            else
            {
                var result = await service.PutSeriesAsync(IdSerie, SeriesSearched);
                if (result)
                    MessageAsync("Vous avez bien modifier la serie", "Valide");
                else
                    MessageAsync("La serie n'a pas pu être modifier", "Erreur");
            }
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
    }
}
