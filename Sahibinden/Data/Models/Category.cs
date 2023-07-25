using System;
using System.ComponentModel.DataAnnotations;

namespace Sahibinden.Data.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		[Required(ErrorMessage ="Category Name Not Empty")]
		public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Description Not Empty")]

        public string CategoryDescription { get; set; }
		public List<Car> Cars { get; set; }
		public bool Status { get; set; }
	}

}

