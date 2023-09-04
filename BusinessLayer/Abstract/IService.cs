using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IService
    {
        List<Service> GetServices();
        Service GetService(int id);
        void Add(Service service);
        void Update(Service service);
        void Activity(int id);
    }
}
