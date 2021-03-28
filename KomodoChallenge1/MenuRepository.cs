using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoChallenge1
{
    public class MenuRepository
    {
        private List<MenuContent> _menuContents = new List<MenuContent>();
        //Create
        public void AddContentToMenu(MenuContent content)
        {
            _menuContents.Add(content);
        }
        //read
        public List<MenuContent> GetMenuContent()
        {
            return _menuContents;
        }
        //Update -no update needed for challenge

        //Delete
        public bool RemoveContentFromMenu(int mealNumber)
        {
            MenuContent content = GetContentByMenuNumber(mealNumber);

            if (content == null)
            {
                return false;
            }

            int initialCount = _menuContents.Count;
            _menuContents.Remove(content);

            if (initialCount > _menuContents.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method

        public MenuContent GetContentByMenuNumber(int mealNumber)
        {
            foreach (MenuContent content in _menuContents)
            {
                if (mealNumber == content.MealNumber)
                {
                    return content;
                }

            }
            return null;
        }

    }
}
