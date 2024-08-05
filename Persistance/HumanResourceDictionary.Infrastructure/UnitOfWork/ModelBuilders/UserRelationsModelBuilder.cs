using HumanResourceDictionary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork.ModelBuilders;

public class UserRelationsModelBuilder: IEntityTypeConfiguration<UserRelations>
{
    public void Configure(EntityTypeBuilder<UserRelations> entity)
    {
        entity.ToTable("UserRelations", "ums");
        entity.HasKey(x => x.Id);  
        
        entity.HasOne(x => x.User)
            .WithMany(x => x.UserRelations)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        entity.HasOne(x => x.RelatedUser)
            .WithMany(x => x.RelatedUserRelations)
            .HasForeignKey(x => x.RelatedUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}