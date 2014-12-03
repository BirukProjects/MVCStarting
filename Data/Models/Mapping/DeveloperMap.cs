using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class DeveloperMap : EntityTypeConfiguration<Developer>
    {
        public DeveloperMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.PhoneNo)
                .HasMaxLength(13);

            // Table & Column Mappings
            this.ToTable("developers");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
        }
    }
}
