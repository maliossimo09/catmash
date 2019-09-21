using catmash.IServices;
using catmash.Repository;
using catmash.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace catmash.Test
{
    [TestClass]
    public class LoadJsonTest
    {
   
        IPopulateBDD _populateBDD;

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
            string json = _populateBDD.ReadFile(@"./Ressourses/cats.json");
            Assert.IsNotNull(json);
        }
    }
}
