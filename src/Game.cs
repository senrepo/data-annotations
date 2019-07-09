using System.ComponentModel.DataAnnotations;

namespace src
{
public class Game
{
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
 
    [Required]
    [Range(10, 100)]
    public decimal Price { get; set; }
}
}