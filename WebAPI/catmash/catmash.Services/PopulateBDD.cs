using catmash.IServices;
using catmash.Models;
using catmash.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace catmash.Services
{
    public class PopulateBDD : ServiceBase, IPopulateBDD
    {
        public PopulateBDD(AppDbContext dbContext) : base (dbContext)
        {
         
        }
        /// <summary>
        /// lit le json et le transforme en liste de chats
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Liste de Cat</returns>
        public List<Cat> GetCatsFromFile(string pPath)
        {
            return JObject.Parse(this.ReadFile(pPath))["images"].ToObject<List<Cat>>();
        }

        /// <summary>
        /// Récupère le fichier JSON
        /// </summary>
        /// <param name="pPath">Chemin du fichier à lire</param>
        /// <returns>Le contenu du fichier au format string</returns>
        public string ReadFile(string pPath)
        {
            return System.IO.File.ReadAllText(pPath);
        }
    }
}
