using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeriesV1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeriesV1.Models;

namespace ClientSeriesV1.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        private WSService service;
        [TestInitialize]
        public void ini()
        {
            service= new WSService("https://apiseriesvcout2.azurewebsites.net/");
        }

        [TestMethod()]
        public void GetSeriesAsyncTest_find_2_returns_title()
        {
            var result = service.GetSeriesAsync(2);

            Assert.AreEqual(result.Result.Titre, "James May's 20th Century", "Test non ok sur le get id"); ;
        }

        /*[TestMethod()]
        public void PostSeriesAsyncTest_addSeries_return_true()
        {
            Series newSeries = new Series(210, "How sell drugs online", "jeunes qui lancent un business de ventes de drogues, mais qui prend une grande ampleur", 3, 24, 2020, "Netflix");
            var result = service.PostSeriesAsync("api/series", newSeries);

            Assert.AreEqual(result.Result, true, "Non ok pas de post");
        }*/

        [TestMethod()]
        public void PostSeriesAsyncTest_addSeries_return_false()
        {
            Series newSeries = new Series(2, "blublut", "super man qui mange ds humains car il est piqué par un poux", 1, 8, 2021, "BBC");
            var result = service.PostSeriesAsync("api/series", newSeries);

            Assert.IsFalse(result.Result, "test pas ok pour le post");
        }


        /*[TestMethod()]
        public void DeleteSeriesAsync_delete_id200_return_true()
        {
            var result = service.DeleteSeriesAsync(201);

            Assert.IsTrue(result.Result, "test pas ok, pas de delete");
        }*/

        [TestMethod()]
        public void DeleteSeriesAsync_delete_id2000_return_false()
        {
            var result = service.DeleteSeriesAsync(2000);

            Assert.IsFalse(result.Result, "test pas ok, delete passé");
        }

        [TestMethod()]
        public void PutSeriesAsync_id203_return_true()
        {
            Series newSeries = new Series(210, "How to sell drugs online", "jeunes qui lancent un business de ventes de drogues, mais qui prend une grande ampleur", 3, 24, 2021, "Amazone Prime");
            var result = service.PutSeriesAsync(210, newSeries);

            Assert.IsTrue(result.Result, "Test pas ok, le put marche pas");
        }
    }
}