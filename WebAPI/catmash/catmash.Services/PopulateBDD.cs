using catmash.IServices;
using catmash.Repository;
using System;

namespace catmash.Services
{
    public class PopulateBDD : ServiceBase, IPopulateBDD
    {
        public PopulateBDD(AppDbContext dbContext) : base (dbContext)
        {
         
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
