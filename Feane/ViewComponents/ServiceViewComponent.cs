using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Feane.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IService iservice;
        public ServiceViewComponent(IService iservice)
        {
            this.iservice = iservice;
        }

        public IViewComponentResult Invoke()
        {
            var services = iservice.GetServices().Where(x => !x.IsDeactive).Take(2).ToList();
            return View(services);
        }
    }
}
