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
            _populateBDD.CreateCatsFromFile(_filePath);

        }

        /// <summary>
        /// Doit retourner la liste de tous les chats
        /// </summary>
        [TestMethod]
        public void ShouldGetAllCats()
        {
            List<Cat> catsListBDD = _catService.GetCatsList();
            Assert.AreEqual(100, catsListBDD.Count);
        }

        /// <summary>
        /// Doit retourner 2 chats en aléatoire
        /// </summary>
        [TestMethod]
        public void ShouldGetTwoRandomCats()
        {
            List<Cat> catsListBDD = _catService.GetCatsForVote(2);
            Assert.AreEqual(2, catsListBDD.Count);
        }

        /// <summary>
        /// Doit retourner le chat avec l'id tt
        /// </summary>
        [TestMethod]
        public void ShouldGetCatWithttID()
        {
            Cat cat = _catService.GetCatById("tt");
            Assert.AreEqual("tt", cat.Id);
        }

    }
}
