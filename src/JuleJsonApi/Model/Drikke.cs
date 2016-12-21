using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class Drikke : BaseEntity
    {

        public int DrikkeId { get; set; }
        public string Navn { get; set; }
        public string Bryggeri { get; set; }
        public float? Abv { get; set; }
        public string Bilde { get; set; }
        public string Stil { get; set; }
        public float? Pris { get; set; }
        public string Land { get; set; }
        public string Beskrivelse { get; set; }

        public List<Rating> Rating { get; set; }
    }
}
