using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class UserModelBuilder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("Users", "ums");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Firstname).HasColumnType("NVARCHAR(50)").IsRequired();
        entity.Property(x => x.Lastname).HasColumnType("NVARCHAR(50)").IsRequired();
        entity.Property(x => x.PersonalNumber).HasColumnType("VARCHAR(11)").IsRequired();
        entity.Property(x => x.BirthDate).IsRequired();
        entity.Property(x => x.BirthDate).IsRequired();

        entity.HasOne(x => x.Gender)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.GenderId);
        entity.HasOne(x => x.City)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CityId);
        
        
    }
}