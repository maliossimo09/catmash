using System;

namespace catmash.IServices
{
    public interface IPopulateBDD
    {
        /// <summary>
        /// Récupère le fichier JSON
        /// </summary>
        /// <param name="pPath">Chemin du fichier à lire</param>
        /// <returns>Le contenu du fichier au format string</returns>
        string ReadFile(string pPath);
    }
}
