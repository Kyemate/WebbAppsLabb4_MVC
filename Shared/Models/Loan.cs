using System.ComponentModel;

namespace Shared.Models;

public class Loan
{
    [DisplayName("Loan Date")]
    public DateTime LoanDate { get; set; }
    [DisplayName("Active")]
    public bool IsActive { get; set; }


    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = default!;

    public int BookId { get; set; }

    public Book Book { get; set; } = default!;
}