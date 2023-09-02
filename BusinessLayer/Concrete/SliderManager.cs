using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
	public class SliderManager : ISliderService
	{
		private readonly ISliderDal sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            this.sliderDal=sliderDal;
        }

        public void Activity(int id)
		{
			sliderDal.Activity(id);
		}

		public void Add(Slider slider)
		{
			sliderDal.Add(slider);
		}

		public void Delete(int id)
		{
			var slider = sliderDal.Get(x => x.Id == id);
			sliderDal.Delete(slider);
		}

		public Slider GetSlider(int id)
		{
			return sliderDal.Get(x => x.Id == id);
		}

		public List<Slider> GetSliders()
		{
			return sliderDal.GetAll();
		}

		public void Update(Slider slider)
		{
			sliderDal.Update(slider);
		}
	}
}
