using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class BrukerMap
    {
        public BrukerMap(EntityTypeBuilder<Bruker> builder)
        {
            builder.HasKey(x => x.BrukerId);
            builder.Property(r => r.Navn).IsRequired();
            builder.Property(r => r.Kode).IsRequired();
        }
    }
}
