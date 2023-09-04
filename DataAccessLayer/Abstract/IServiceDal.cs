using Core.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
    public interface IServiceDal : IRepositoryBase<Service>
    {
        void Activity(int id);
    }
}
