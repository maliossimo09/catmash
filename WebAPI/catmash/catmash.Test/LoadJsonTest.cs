using catmash.IServices;
using catmash.Models;
using catmash.Repository;
using catmash.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace catmash.Test
{
    [TestClass]
    public class LoadJsonTest
    {
        string _filePath = @"./Ressourses/cats.json";
        IPopulateBDDService _populateBDD;
        ICatService _catService;
        /// <summary>
        /// initialisation des tests
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CatsDatabase2")
                .Options;
            var context = new AppDbContext(options);
            _populateBDD = new PopulateBDDService(context, _filePath);
            _catService = new CatService(context);
        }
        

        
        /// <summary>
        /// La base de données doit contenir les 100 chats
        /// </summary>
        [TestMethod]
        public void ShouldAddCatsToDatabase()
        {
            List<Cat> catsListBDD = _catService.GetCatsList().ToList();
            Assert.AreEqual(100, catsListBDD.Count);
        }
    }
}
