using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRSTWeb.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Preparation Time (minutes)")]
        public int PrepTime { get; set; }

        [Display(Name = "Cooking Time (minutes)")]
        public int CookTime { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public string Instructions { get; set; }

        public string Ingredients { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
} 