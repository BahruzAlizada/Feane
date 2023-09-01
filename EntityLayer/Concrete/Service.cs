using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
	public class Service : IEntity
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public int Discount { get;set; }
		public bool IsDeactive { get; set; }
	}
}
