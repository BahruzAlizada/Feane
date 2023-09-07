using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetMenus();
        Menu GetMenu(int id);
        void Add(Menu menu);
        void Update(Menu menu);
        void Activity(int id);
    }
}
