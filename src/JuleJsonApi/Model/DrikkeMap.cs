using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class DrikkeMap
    {
        public DrikkeMap(EntityTypeBuilder<Drikke> builder)
        {
            builder.HasKey(x => x.DrikkeId);
            builder.Property(r => r.Navn).IsRequired();
            builder.Property(r => r.Bilde);
        }
    }
}
