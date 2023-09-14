#pragma warning disable CS8618  //#1

using System.ComponentModel.DataAnnotations;  //connected to line 11 this will bring itself in when iadd the KEY

namespace ChefsN.Models;

public class Dish
{
        [Key]
        public int DishID { get; set; }

        [Required(ErrorMessage = "Name of Dish is required")]
        [Display(Name = "Name of Dish")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Calories are required")]
        [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Tastiness is required")]
        [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int ChefID { get; set; } // Foreign key
        public Chef? Chef { get; set; } // Navigation property for the Chef associated with the Dish
}