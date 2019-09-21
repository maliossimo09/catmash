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
    }
}
