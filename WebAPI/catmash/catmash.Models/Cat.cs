using System;
using System.Collections.Generic;
using System.Text;

namespace catmash.Models
{
    public class Cat : BaseModel
    {
        /// <summary>
        /// Url de la photo du chat
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Score résultant des votes
        /// Le chat ayant le score le plus élevé est le chat le plus mignon
        /// </summary>
        public int Score { get; set; }
    }
}
