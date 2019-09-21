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
    public class VoteTest
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
                .UseInMemoryDatabase(databaseName: "CatsDatabase")
                .Options;
            var context = new AppDbContext(options);
            _populateBDD = new PopulateBDDService(context);
            _catService = new CatService(context);
        }

        /// <summary>
        /// Doit retourner la liste de tous les chats
        /// </summary>
        [TestMethod]
        public void ShouldGetAllCats()
        {
            _populateBDD.CreateCatsFromFile(_filePath);
            List<Cat> catsListBDD = _catService.GetCatsList();
            Assert.AreEqual(100, catsListBDD.Count);
        }
    }
}
