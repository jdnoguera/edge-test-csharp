using System.ComponentModel.DataAnnotations;

namespace edge_test_csharp.Models;

public class CreateOrUpdateCustomerModel
{
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(50)]
    [Required]
    public string DocumentNumber { get; set; }
}