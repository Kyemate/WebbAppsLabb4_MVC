using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Customer
{
    public int Id { get; set; }

    [Required, MinLength(16), MaxLength(50), DisplayName("Full Name")]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    public ICollection<Loan>? Loans { get; set; }

}