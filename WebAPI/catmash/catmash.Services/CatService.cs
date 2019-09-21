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
    public class CatService : BaseService, ICatService
    {
        public CatService(AppDbContext dbContext) : base (dbContext)
        {
         
        }

        /// <summary>
        /// Retourne N chats aléatoires
        /// </summary>
        /// <param name="pNbCats">N</param>
        /// <returns>Une liste de chats </returns>
        public List<Cat> GetCatsForVote(int pNbCats)
        {
            return CatService.PickRandom(this.GetCatsList().ToArray(), pNbCats);
        }

        /// <summary>
        /// Retourne la liste de tous les chats
        /// </summary>
        public List<Cat> GetCatsList()
        {
            return _dbContext.Cat.ToList();
        }


        /// <summary>
        /// Retour le chat avec l'id correspondant
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Cat GetCatById(string pId)
        {
            return _dbContext.Cat.FirstOrDefault(a => a.Id == pId);
        }

        private static List<Cat> PickRandom(Cat[] pCats, int pNbCats)
        {
            var rand = new Random();

            if (pNbCats >= pCats.Length)
                pNbCats = pCats.Length - 1;

            int[] indexes = Enumerable.Range(0, pCats.Length).ToArray();

            List<Cat> results = new List<Cat>();

            for (int i = 0; i < pNbCats; i++)
            {
                int j = rand.Next(i, pCats.Length);

                int temp = indexes[i];
                indexes[i] = indexes[j];
                indexes[j] = temp;

                results.Add(pCats[indexes[i]]);
            }

            return results;
        }

        /// <summary>
        /// Voter pour un chat
        /// </summary>
        /// <param name="pId">Id du chat</param>
        /// <returns>Retourn le chat avec son nouveau score</returns>
        public Cat VoteForCatById(string pId)
        {
            Cat cat = this.GetCatById(pId);
            if (cat == null)
                throw new KeyNotFoundException();

            cat.Score = cat.Score + 1;

            _dbContext.Cat.Update(cat);

            _dbContext.SaveChanges();

            return this.GetCatById(pId);
        }
    }
}
