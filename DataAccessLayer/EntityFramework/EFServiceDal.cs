using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFServiceDal : EfRepositoryBase<Service, Context>, IServiceDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var service = context.Services.FirstOrDefault(x => x.Id == id);
                if (service.IsDeactive)
                    service.IsDeactive = false;
                else
                    service.IsDeactive=true;

                context.SaveChanges();
            }
        }
    }
}
