using catmash.IServices;
using catmash.Models;
using catmash.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace catmash.Services
{
    public class PopulateBDDService : BaseService, IPopulateBDDService
    {
        public PopulateBDDService(AppDbContext dbContext,String pFilePath) : base (dbContext)
        {
            this.CreateCatsFromFile(pFilePath);
        }

        /// <summary>
        /// Ajoute les chats en base de données depuis le fichier json source
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns>Liste des chats ajoutés</returns>
        private IEnumerable<Cat> CreateCatsFromFile(string pPath)
        {
            if (_dbContext.Cat.Any())
                return _dbContext.Cat.ToList();
            List<Cat> catsList = this.GetCatsFromFile(pPath).ToList();
            _dbContext.Cat.AddRange(catsList);
            _dbContext.SaveChanges();
            return _dbContext.Cat.ToList();
        }

        /// <summary>
        /// lit le json et le transforme en liste de chats
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Liste de Cat</returns>
        private IEnumerable<Cat> GetCatsFromFile(string pPath)
        {
            return JObject.Parse(this.ReadFile(pPath))["images"].ToObject<List<Cat>>();
        }

        /// <summary>
        /// Récupère le fichier JSON
        /// </summary>
        /// <param name="pPath">Chemin du fichier à lire</param>
        /// <returns>Le contenu du fichier au format string</returns>
        private string ReadFile(string pPath)
        {
            return System.IO.File.ReadAllText(pPath);
        }
    }
}
