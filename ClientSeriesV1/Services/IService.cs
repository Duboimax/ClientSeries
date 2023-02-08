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
        Task<Series> GetSeriesAsync(int id);
        Task<bool> PutSeriesAsync(int id, Series updateSerie);
        Task<bool> PostSeriesAsync(string nomController, Series newSerie);
        Task<bool> DeleteSeriesAsync(int id);

    }
}
