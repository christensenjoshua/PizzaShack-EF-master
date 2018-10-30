using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaShack.Entities
{
    public enum PizzaSize
    {
        Personal,
        Medium,
        Large,
        Family
    }

    public class Pizza
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }
    }
}
