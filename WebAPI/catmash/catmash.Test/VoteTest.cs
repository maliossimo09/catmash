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
    public class VoteTest
    {
        ICatService _catService;

        /// <summary>
        /// initialisation des tests
        /// </summary>
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            string filePath = @"./Ressourses/cats.json";
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CatsDatabase")
                .Options;
            var context = new AppDbContext(options);
            IPopulateBDDService populateBDD = new PopulateBDDService(context, filePath);
        }

        [TestInitialize]
        public  void SetupForEachTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "CatsDatabase")
               .Options;
            var context = new AppDbContext(options);

            _catService = new CatService(context);
        }

        /// <summary>
        /// Doit retourner la liste de tous les chats
        /// </summary>
        [TestMethod]
        public void ShouldGetAllCats()
        {
            List<Cat> catsListBDD = _catService.GetCatsList().ToList();
            Assert.AreEqual(100, catsListBDD.Count);
        }

        /// <summary>
        /// Doit retourner 2 chats en aléatoire
        /// </summary>
        [TestMethod]
        public void ShouldGetTwoRandomCats()
        {
            List<Cat> catsListBDD = _catService.GetCatsForVote(2).ToList();
            Assert.AreEqual(2, catsListBDD.Count);
        }

        /// <summary>
        /// Doit retourner le chat avec l'id tt
        /// </summary>
        [TestMethod]
        public void ShouldGetCatByID()
        {
            Cat cat = _catService.GetCatById("tt");
            Assert.AreEqual("tt", cat.Id);
        }


        /// <summary>
        /// Le score du chat doit augmenter si on vote pour lui
        /// </summary>
        [TestMethod]
        public void ShouldScoreIncreaseAfterVote()
        {
            Cat catBeforeVote = _catService.GetCatById("tt");
            Cat catAfterVote = _catService.VoteForCatById("tt");
            Assert.IsTrue(catBeforeVote.Score + 1 == catAfterVote.Score);
        }
    }
}
