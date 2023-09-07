using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFMenuDal : EfRepositoryBase<Menu, Context>, IMenuDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                Menu menu = context.Menus.FirstOrDefault(x=>x.Id==id);
                if (menu.IsDeactive)
                    menu.IsDeactive = false;
                else
                    menu.IsDeactive = true;

                context.SaveChanges();
            }
        }

        public Menu GetMenu(int id)
        {
           using(var context = new Context())
            {
                Menu menu = context.Menus.Include(x=>x.Category).FirstOrDefault(x => x.Id == id);
                return menu;
            }
        }

        public List<Menu> GetMenus()
        {
            using (var context = new Context())
            {
                List<Menu> menus =  context.Menus.Include(x => x.Category).ToList();
                return menus;
            }
        }
    }
}
