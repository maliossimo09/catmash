using System;
using System.Collections.Generic;
using catmash.Models;

namespace catmash.IServices
{
    public interface ICatService
    {
        /// <summary>
        /// Retourne la liste de tous les chats
        /// </summary>
        List<Cat> GetCatsList();

        /// <summary>
        /// Retourne N chats aléatoires
        /// </summary>
        /// <param name="pNbCats">N</param>
        /// <returns>Une liste de chats </returns>
        List<Cat> GetCatsForVote(int pNbCats);
    }
}
