using System.ComponentModel.DataAnnotations;

namespace DevApplication.Data;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
}