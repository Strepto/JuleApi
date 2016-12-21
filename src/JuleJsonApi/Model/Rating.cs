using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class Rating : BaseEntity
    {
        public int RatingId { get; set; }
        public int DrikkeID { get; set; }
        public Drikke Drikke { get; set; }
        public int BrukerID { get; set; }
        public Bruker Bruker { get; set; }
        public string Bilde { get; set; }
        public int Karakter { get; set; }
        public string Nokkelord { get; set; }
        public bool SmakerJul { get; set; }
    }
}
