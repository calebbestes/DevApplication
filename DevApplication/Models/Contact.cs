using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevApplication.Data;

namespace DevApplication.Models;

public class Contact
{
    [Key]
    public int ContactID { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "Must Contain 10 digits")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits")]
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    // [ForeignKey("Category")]
    public int CategoryID { get; set; }
    public Category Category { get; set; }
}