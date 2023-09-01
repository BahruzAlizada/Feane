using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
	public class Category : IEntity
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public List<Menu> Menus { get; set; }
		public bool IsDeactive { get; set; }
	}
}
