using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class RatingMap
    {
        public RatingMap(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.RatingId);
            builder.Property(r => r.BrukerID).IsRequired();
            builder.Property(r => r.DrikkeID).IsRequired();
            builder.Property(r => r.Karakter).IsRequired();
            builder.Property(r => r.Nokkelord).IsRequired();
            builder.Property(r => r.SmakerJul).IsRequired();
            builder.Property(r => r.Bilde);
        }
    }
}
