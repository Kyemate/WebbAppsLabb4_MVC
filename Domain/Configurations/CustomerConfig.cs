using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(new Customer {Id = 1, Name = "Test Guy", Address = "test address 123"});
        builder.HasData(new Customer { Id = 2, Name = "Test Guy 2", Address = "test address 12365" });
        builder.HasData(new Customer { Id = 3, Name = "Test Guy 3", Address = "test address 123123" });
    }
}