using KomodoChallenge1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsole
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        //Method that runs/starts the Application
        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe Menu Application\n\n" +
                    "1) Create new menu item\n" +
                    "2) View all menu items\n" +
                    "3) View item by number\n" +
                    "4) Delete item by number\n" +
                    "5) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DisplayMenuItems();
                        break;
                    case "3":
                        DisplayMenuItemByNumber();
                        break;
                    case "4":
                        DeleteMenuItemByNumber();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using Komodo Cafe Meu Application\n" +
                            "Written by Joshua Denman, all rights reserved 2021.\n");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuContent newMenuItem = new MenuContent();

            Console.WriteLine("Enter the menu number:");
            newMenuItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter meal name:");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter meal description:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter all meal ingredients (separated by commas):");
            newMenuItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter price (do not enter $, just numbers):");
            newMenuItem.Price = Convert.ToDecimal(Console.ReadLine());

            _menuRepo.AddContentToMenu(newMenuItem);
        }

        private void DisplayMenuItems()
        {
            Console.Clear();
            List<MenuContent> menuList = _menuRepo.GetMenuContent();
            
            foreach(MenuContent content in menuList)
            {
                Console.WriteLine($"Menu number: {content.MealNumber}\n" +
                    $"Meal name: {content.MealName}");
            }
        }
        private void DisplayMenuItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter menu number:");
            int menuNumber = Convert.ToInt32(Console.ReadLine());

            MenuContent content = _menuRepo.GetContentByMenuNumber(menuNumber);
            if (content !=null)
            {
                Console.WriteLine($"Menu number: {content.MealNumber}\n" +
                    $"Meal name: {content.MealName}\n" +
                    $"Meal description: {content.Description}\n" +
                    $"Meal ingredients: {content.Ingredients}\n" +
                    $"Meal price: {content.Price}");
            }
            else
            {
                Console.WriteLine("No item by that number");
            }
        }
        private void DeleteMenuItemByNumber()
        {
            DisplayMenuItems();
            Console.WriteLine("\nEnter the menu item number to delete:");
            int itemToDelete = Convert.ToInt32(Console.ReadLine());

            bool wasDeleted = _menuRepo.RemoveContentFromMenu(itemToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("Item was deleted");
            }
            else
            {
                Console.WriteLine("Item could not be deleted");
            }
        }
        private void SeedMenuList()
        {
            MenuContent chickenStrips = new MenuContent(1, "Chicken Strips", "3 chicken strips with fries and a drink", "Three chicken strips, Side of fries, Choice of beverage", 5.99m);
            MenuContent cheeseBurger = new MenuContent(2, "CheeseBurger", "Quarterpound cheeseburger with fries and a drink", "Quarterpound all beef patty, Slice of American Cheese, Toasted Kaiser bun, Choice of toppings, Side of fries, Choice of beverage", 6.99m);
            MenuContent burritoSupreme = new MenuContent(3, "Burrito Supreme", "Supreme burrito with side of rice and a drink", "Rice, Beans, Choice of chicken or beef, Shredded lettuce, Diced tomatoes, Sourcream, Flour tortilla shell, Side of rice, Choice of beverage", 5.99m);

            _menuRepo.AddContentToMenu(chickenStrips);
            _menuRepo.AddContentToMenu(cheeseBurger);
            _menuRepo.AddContentToMenu(burritoSupreme);
        }
    }
}
