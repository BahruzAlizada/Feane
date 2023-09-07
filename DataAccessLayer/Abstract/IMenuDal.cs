using Core.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
    public interface IMenuDal : IRepositoryBase<Menu>
    {
        List<Menu> GetMenus();
        Menu GetMenu(int id);
        void Activity(int id);
    }
}
