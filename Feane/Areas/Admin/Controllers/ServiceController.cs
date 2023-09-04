using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IService iservice;
        private readonly IWebHostEnvironment env;
        public ServiceController(IService iservice,IWebHostEnvironment env)
        {
            this.iservice = iservice;
            this.env=env;
        }

        #region Index
        public IActionResult Index()
        {
            List<Service> services = iservice.GetServices().OrderByDescending(x=>x.Id).ToList();
            return View(services);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ServiceModel model)
        {
            #region Existed
            bool result = iservice.GetServices().Any(x => x.Name == model.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "This Name is already is Existed");
                return View();
            }
            #endregion

            #region Image
            if (model.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }
            if (!model.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Just Image Type");
                return View();
            }
            if (model.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256Kb");
                return View();
            }
            string folder = Path.Combine(env.WebRootPath, "images", "service");
            model.Image = await model.Photo.SaveFileAsync(folder);
            #endregion

            Service service = new Service
            {
                Id = model.Id,
                Name = model.Name,
                Discount = model.Discount,
                Image = model.Image,
                IsDeactive = false
            };

            iservice.Add(service);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbservice = iservice.GetService(id);
            if (dbservice == null) return BadRequest();

            ServiceModel dbmodel = new ServiceModel
            {
                Id = dbservice.Id,
                Name = dbservice.Name,
                Discount = dbservice.Discount,
                Image = dbservice.Image,
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id, ServiceModel model)
        {
            #region Get
            var dbservice = iservice.GetService(id);
            if (dbservice == null) return BadRequest();

            ServiceModel dbmodel = new ServiceModel
            {
                Id = dbservice.Id,
                Name = dbservice.Name,
                Discount = dbservice.Discount,
                Image = dbservice.Image,
            };
            #endregion

            #region Existed
            bool result = iservice.GetServices().Any(x => x.Name == model.Name && x.Id != id);
            if (result)
            {
                ModelState.AddModelError("Name", "This Name is already is Existed");
                return View();
            }
            #endregion

            #region Photo
            if (model.Photo != null)
            {
                if (!model.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Just Image Type");
                    return View();
                }
                if (model.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "images", "service");
                model.Image = await model.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbservice.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbmodel.Image = model.Image;
            }
            else
                model.Image = dbmodel.Image;
            #endregion

            dbmodel.Id = model.Id;
            dbmodel.Name = model.Name;
            dbmodel.Discount = model.Discount;

            Service service = new Service
            {
                Id = model.Id,
                Image = model.Image,
                Name = model.Name,
                Discount = model.Discount,
                IsDeactive = false
            };

            iservice.Update(service);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            iservice.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
