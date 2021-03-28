using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Challenge_1
{
    
    public class Menu_Content
    {
        // Menu properties
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string[] Ingredients { get; set; }
        public decimal Price { get; set; }

        // Menu constructor
        public Menu_Content() { }
        public Menu_Content(int mealNumber,string mealName,string description, string[] ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
