using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
	public class About : IEntity
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
