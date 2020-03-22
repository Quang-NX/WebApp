using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.EF.Extensions;
using WebApp.Data.Entities;

namespace WebApp.Data.EF.Configurations
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired()
                .HasColumnType("varchar(128)");
        }
    }
}
