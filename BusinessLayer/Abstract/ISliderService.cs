using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
	public interface ISliderService
	{
		List<Slider> GetSliders();
		Slider GetSlider(int id);
		void Add(Slider slider);
		void Update(Slider slider);
		void Activity(int id);
		void Delete(int id);
	}
}
