using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeriesV1.Models
{
    public class Series
    {
        private int serieId;
        private string titre;
        private string resume;
        private int nbSaisons;
        private int nbEpisodes;
        private int anneeCreation;
        private string network;

        public Series(int serieId, string titre, string resume, int nbSaisons, int nbEpisodes, int anneeCreation, string network)
        {
            SerieId = serieId;
            Titre = titre;
            Resume = resume;
            NbSaisons = nbSaisons;
            NbEpisodes = nbEpisodes;
            AnneeCreation = anneeCreation;
            Network = network;
        }

        public Series() { }

        public int SerieId { get => serieId; set => serieId = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Resume { get => resume; set => resume = value; }
        public int NbSaisons { get => nbSaisons; set => nbSaisons = value; }
        public int NbEpisodes { get => nbEpisodes; set => nbEpisodes = value; }
        public int AnneeCreation { get => anneeCreation; set => anneeCreation = value; }
        public string Network { get => network; set => network = value; }

        public override bool Equals(object obj)
        {
            return obj is Series series &&
                   SerieId == series.SerieId &&
                   Titre == series.titre &&
                   Resume == series.Resume &&
                   NbSaisons == series.NbSaisons &&
                   NbEpisodes == series.NbEpisodes &&
                   AnneeCreation == series.AnneeCreation &&
                   Network == series.Network;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SerieId, Titre, Resume, NbSaisons, NbEpisodes, AnneeCreation, Network);
        }
    }
}
