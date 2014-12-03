using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class SoftwareMap : EntityTypeConfiguration<Software>
    {
        public SoftwareMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Softwares");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.dev_id).HasColumnName("dev_id");
            this.Property(t => t.Price).HasColumnName("Price");

            // Relationships
            this.HasRequired(t => t.developer)
                .WithMany(t => t.Softwares)
                .HasForeignKey(d => d.dev_id);

        }
    }
}
