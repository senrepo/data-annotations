using System;
using System.ComponentModel.DataAnnotations;

namespace src
{
    public class Recipe
    {
        [Required]
        public string Name { get; set; }
    }
}
