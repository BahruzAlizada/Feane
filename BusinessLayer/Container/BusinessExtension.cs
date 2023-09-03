using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusinessLayer.Container
{
	public static class BusinessExtension
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<ISliderService, SliderManager>();
			services.AddScoped<ISliderDal, EFSliderDal>();

			services.AddScoped<IAboutService, AboutManager>();
			services.AddScoped<IAboutDal, EFAboutDal>();

			services.AddScoped<ITestimonialService,TestimonialManager>();
			services.AddScoped<ITestimonialDal, EFTestimonialDal>();

			services.AddScoped<IBioService, BioManager>();
			services.AddScoped<IBioDal, EFBioDal>();

			services.AddScoped<ISocialMediaService,SocialMediaManager>();
			services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

			services.AddScoped<IBookingService, BookingManager>();
			services.AddScoped<IBookingDal, EFBookingDal>();
		}
	}
}
