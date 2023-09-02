using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
	public class EFSliderDal : EfRepositoryBase<Slider, Context>, ISliderDal
	{
		public void Activity(int id)
		{
			using(var context = new Context())
			{
				var slider = context.Sliders.FirstOrDefault(x=>x.Id == id);
				if(slider.IsDeactive)
					slider.IsDeactive = false;
				else
					slider.IsDeactive = true;

				context.SaveChanges();
			}
		}
	}
}
