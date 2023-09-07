using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            this.menuDal = menuDal;
        }

        public void Activity(int id)
        {
            menuDal.Activity(id);
        }

        public void Add(Menu menu)
        {
            menuDal.Add(menu);
        }

        public Menu GetMenu(int id)
        {
            return menuDal.GetMenu(id);
        }

        public List<Menu> GetMenus()
        {
            return menuDal.GetMenus();
        }

        public void Update(Menu menu)
        {
            menuDal.Update(menu);
        }
    }
}
