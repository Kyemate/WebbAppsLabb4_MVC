using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class LoanConfig : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(x => new
        {
            x.BookId, x.CustomerId
        });
        builder.HasData(new Loan {BookId = 1, CustomerId = 1, IsActive = true, LoanDate = DateTime.Now});
    }
}