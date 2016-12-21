using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class Bruker : BaseEntity
    {
        public int BrukerId { get; set; }
        public string Navn { get; set; }
        public string Kode { get; set; }

        public List<Rating> Rating { get; set; }
    }
}
