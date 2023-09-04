using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IService
    {
        private readonly IServiceDal serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            this.serviceDal = serviceDal;
        }
        public void Activity(int id)
        {
            serviceDal.Activity(id);
        }

        public void Add(Service service)
        {
            serviceDal.Add(service);
        }

        public Service GetService(int id)
        {
           return serviceDal.Get(x=>x.Id == id);
        }

        public List<Service> GetServices()
        {
            return serviceDal.GetAll();
        }

        public void Update(Service service)
        {
            serviceDal.Update(service);
        }
    }
}
