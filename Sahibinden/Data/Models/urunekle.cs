using System;
namespace Sahibinden.Data.Models
{
	public class urunekle
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImgUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

