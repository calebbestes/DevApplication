using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevApplication.Data;

namespace DevApplication.Models;

public class Contact
{
    [Key]
    public int ContactID { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string? Address { get; set; }
    

    [Required(ErrorMessage = "You must provide a phone number")]
    [Display(Name = "Home Phone")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    // [ForeignKey("Category")]
    public int CategoryID { get; set; }
    public Category Category { get; set; }
}