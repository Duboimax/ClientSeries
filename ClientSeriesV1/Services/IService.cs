using ClientSeriesV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeriesV1.Services
{
    public interface IService
    {
        Task<Series> GetSeriesAsync(string nomControleur, int id);
        Task<bool> PutSeriesAsync(string nomControleur);
        Task<bool> PostSeriesAsync(string nomControleur);
        Task<bool> DeleteSeriesAsync(string nomControleur);

    }
}
