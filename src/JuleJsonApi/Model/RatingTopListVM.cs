using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class RatingTopListVM
    {
        public int AverageRating { get; set; }
        public List<int> Ratings { get; set; }
        public string Navn { get; set; }
        public string Bryggeri { get; set; }
        public List<bool> SmakerJulArray { get; set; }
        public List<string> Bilder { get; set; }
        public List<string> Nokkelord { get; set; }
        public int RatingId { get; internal set; }
    }

}
