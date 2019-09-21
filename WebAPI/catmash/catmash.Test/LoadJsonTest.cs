using catmash.IServices;
using catmash.Models;
using catmash.Repository;
using catmash.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace catmash.Test
{
    [TestClass]
    public class LoadJsonTest
    {
        string _filePath = @"./Ressourses/cats.json";
        IPopulateBDD _populateBDD;
        /// <summary>
        /// initialisation des tests
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CatsDatabase")
                .Options;
            var context = new AppDbContext(options);
            _populateBDD = new PopulateBDD(context);
        }
        /// <summary>
        /// s'assure de la lécture de fichier cats.json
        /// </summary>
        [TestMethod]
        public void ShouldReadJsonFile()
        {
            string json = _populateBDD.ReadFile(_filePath);
            Assert.IsNotNull(json);
        }

        /// <summary>
        /// s'assure de la transformation du fichier json en liste de chats
        /// </summary>
        [TestMethod]
        public void ShouldReturnCatsList()
        {
            List<Cat> catsList = _populateBDD.GetCatsFromFile(_filePath);
            Assert.IsTrue(catsList.Count > 0);
        }
    }
}
