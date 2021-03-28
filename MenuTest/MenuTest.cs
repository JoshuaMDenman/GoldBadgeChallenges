using KomodoChallenge1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuTest
{
    [TestClass]
    public class MenuTest
    {
        private MenuRepository _testMenu = new MenuRepository();
        [TestMethod]
        public void GetMenuItemByMealNumber()
        {
            //Arrange
            SeedMenuList();
            int trueMenuItem = 1;
            int falseMenuItem = 4;

            MenuContent trueResultContent, falseResultContent;

            //Act
            trueResultContent = _testMenu.GetContentByMenuNumber(trueMenuItem);
            falseResultContent = _testMenu.GetContentByMenuNumber(falseMenuItem);

            //Assert
            Assert.IsNotNull(trueResultContent);
            Assert.IsNull(falseResultContent);
        }

        //Seed Method
        private void SeedMenuList()
        {
            MenuContent chickenStrips = new MenuContent(1, "Chicken Strips", "3 chicken strips with fries and a drink", "Three chicken strips, Side of fries, Choice of beverage", 5.99m);
            MenuContent cheeseBurger = new MenuContent(2, "CheeseBurger", "Quarterpound cheeseburger with fries and a drink", "Quarterpound all beef patty, Slice of American Cheese, Toasted Kaiser bun, Choice of toppings, Side of fries, Choice of beverage", 6.99m);
            MenuContent burritoSupreme = new MenuContent(3, "Burrito Supreme", "Supreme burrito with side of rice and a drink", "Rice, Beans, Choice of chicken or beef, Shredded lettuce, Diced tomatoes, Sourcream, Flour tortilla shell, Side of rice, Choice of beverage", 5.99m);

            _testMenu.AddContentToMenu(chickenStrips);
            _testMenu.AddContentToMenu(cheeseBurger);
            _testMenu.AddContentToMenu(burritoSupreme);
        }

        [TestMethod]
        public void AddContentToMenuTest()
        {
            //Arrange
            SeedMenuList();
            int addMenuItem = 4;

            MenuContent resultContent;

            //Act
            resultContent = _testMenu.GetContentByMenuNumber(addMenuItem);
            if(resultContent !=null)
            {
                Assert.Fail("Item already exists in menu");
            }
            else
            {
                MenuContent tacoSalad = new MenuContent(4, "Taco Salad", "Beef taco salad and a drink", "Taco shell, Ground beef, Shredded lettuce, Diced tomatoes, Diced onions, Sourcream, Shredded Cheese, Salsa, Choice of beverage", 7.99m);

                _testMenu.AddContentToMenu(tacoSalad);
            }
            resultContent = _testMenu.GetContentByMenuNumber(addMenuItem);

            //Assert
            Assert.IsNotNull(resultContent);
        }
        //Delete
        [TestMethod]
        public void DeleteMenuItemTest()
        {
            //Arrange
            SeedMenuList();

            //Act
            bool wasRemoved = _testMenu.RemoveContentFromMenu(1);

            //Assert
            Assert.IsTrue(wasRemoved);

        }
    }
}
