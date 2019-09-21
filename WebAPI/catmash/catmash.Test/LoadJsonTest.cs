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
        /// s'assure de la l�cture de fichier cats.json
        /// </summary>
        [TestMethod]
        public void ShouldReadJsonFile()
        {
            string json = _populateBDD.ReadFile(@"./Ressourses/cats.json");
            Assert.IsNotNull(json);
        }

        /// <summary>
        /// s'assure de la transformation du fichier json en liste de chats
        /// </summary>
        [TestMethod]
        public void ShouldReturnCatsList()
        {
            List<Cat> catsList = _populateBDD.GetCatsFromFile(@"./Ressourses/cats.json");
            Assert.IsTrue(catsList.Count > 0);
        }
    }
}
