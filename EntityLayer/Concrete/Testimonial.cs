using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
	public class Testimonial : IEntity
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Description { get; set; }
		public bool IsDeactive { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
	}
}
