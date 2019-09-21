using System;
using System.Collections.Generic;
using catmash.Models;

namespace catmash.IServices
{
    public interface IPopulateBDDService
    {
        /// <summary>
        /// Récupère le fichier JSON
        /// </summary>
        /// <param name="pPath">Chemin du fichier à lire</param>
        /// <returns>Le contenu du fichier au format string</returns>
        string ReadFile(string pPath);

        /// <summary>
        /// lit le json et le transforme en liste de chats
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Liste de Cat</returns>
        List<Cat> GetCatsFromFile(string pPath);

        /// <summary>
        /// Ajoute les chats en base de données depuis le fichier json source
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns>Liste des chats ajoutés</returns>
        List<Cat> CreateCatsFromFile(string pPath);
    }
}
