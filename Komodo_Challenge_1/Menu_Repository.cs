using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Challenge_1
{
    public class Menu_Repository
    {
        private List<Menu_Content> _menuContents = new List<Menu_Content>();
        //Create
        public void AddContentToMenu(Menu_Content content)
        {
            _menuContents.Add(content);
        }
        //read
        public List<Menu_Content> GetMenuContent()
        {
            return _menuContents;
        }
        //Update -no update needed for challenge

        //Delete
        public bool RemoveContentFromMenu(string MealName)
        {
            Menu_Content content = GetContentByMenuName(MealName);
            
            if (content==null)
            {
                return false;
            }

            int initialCount = _menuContents.Count;
            _menuContents.Remove(content);
            
            if(initialCount>_menuContents.Count)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        //Helper Method

        public Menu_Content GetContentByMenuName(string mealName)
        {
            foreach (Menu_Content content in _menuContents)
            {
                if (mealName == content.MealName)
                {
                    return content;
                }

            }
                return null;
        }

    }
}
