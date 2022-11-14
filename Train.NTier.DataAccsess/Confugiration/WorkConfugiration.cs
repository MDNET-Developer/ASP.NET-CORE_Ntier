using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.Entity.Concrete;

namespace Train.NTier.DataAccsess.Confugiration
{
    public class WorkConfugiration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(x => x.Description).HasMaxLength(350);
            builder.Property(y => y.Description).IsRequired(true);
            builder.Property(o => o.IsCompleted).IsRequired(true);
        }
    }
}
