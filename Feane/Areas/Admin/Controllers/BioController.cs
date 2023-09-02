using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BioController : Controller
    {
        private readonly IBioService bioService;
        public BioController(IBioService bioService)
        {
            this.bioService = bioService;
        }

        #region Index
        public IActionResult Index()
        {
            Bio bio = bioService.GetBio();
            return View(bio);
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            Bio dbbio = bioService.GetBioId(id);
            if (dbbio == null) return BadRequest();

            BioModel dbmodel = new BioModel
            {
                Id = dbbio.Id,
                HeaderLogoName = dbbio.HeaderLogoName,
                FooterLocation = dbbio.FooterLocation,
                FooterEmail = dbbio.FooterEmail,
                FooterPhone = dbbio.FooterPhone,
                FooterDescription = dbbio.FooterDescription,
                Ended = dbbio.Ended,
                Started = dbbio.Started
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,BioModel model)
        {
            #region Get
            Bio dbbio = bioService.GetBioId(id);
            if (dbbio == null) return BadRequest();

            BioModel dbmodel = new BioModel
            {
                Id = dbbio.Id,
                HeaderLogoName = dbbio.HeaderLogoName,
                FooterLocation = dbbio.FooterLocation,
                FooterEmail = dbbio.FooterEmail,
                FooterPhone = dbbio.FooterPhone,
                FooterDescription = dbbio.FooterDescription,
                Ended = dbbio.Ended,
                Started = dbbio.Started
            };
            #endregion

            dbmodel.Id = model.Id;
            dbmodel.HeaderLogoName = model.HeaderLogoName;
            dbmodel.FooterLocation = model.FooterLocation;
            dbmodel.FooterEmail = model.FooterEmail;
            dbmodel.FooterPhone = model.FooterPhone;
            dbmodel.FooterDescription = model.FooterDescription;
            dbmodel.Started = model.Started;
            dbmodel.Ended = model.Ended;

            Bio bio = new Bio
            {
                Id = model.Id,
                HeaderLogoName = model.HeaderLogoName,
                FooterLocation = model.FooterLocation,
                FooterEmail = model.FooterEmail,
                FooterPhone = model.FooterPhone,
                FooterDescription = model.FooterDescription,
                Ended = model.Ended,
                Started = model.Started
            };

            bioService.Update(bio);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
