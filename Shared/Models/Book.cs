using System.ComponentModel;

namespace Shared.Models;

public class Book
{
    public int Id { get; set; }

    [DisplayName("Title")]
    public string Title { get; set; }

    [DisplayName("Author")]
    public string Author { get; set; }

    [DisplayName("ISBN")]
    public string Isbn { get; set; }

    public ICollection<Loan>? Loans { get; set; }
}