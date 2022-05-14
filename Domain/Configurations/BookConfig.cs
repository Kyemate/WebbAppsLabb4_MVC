using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(new Book { Id = 1, Title = "Lifters guide to the galaxy", Author = "Idk", Isbn = "XXX"});
        builder.HasData(new Book { Id = 2, Title = "Book2", Author = "Idk2", Isbn = "XXX2" });
    }
}