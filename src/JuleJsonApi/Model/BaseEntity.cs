using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{

    public class BaseEntity
    {
        public DateTime? DateCreated { get; internal set; }
        public DateTime? DateModified { get; internal set; }
    }
}
