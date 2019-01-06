using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Controllers;

namespace CheeseMVC.ViewModels
{

	public class AddCheeseViewModel
	{
		[Required]
		[Display(Name = "Cheese Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "You must give your cheese a description")]
		public string Description { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int CategoryID { get; set; }

		public List<SelectListItem> CheeseCategories { get; set; }

		public AddCheeseViewModel(){}

		public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
		{
			CheeseCategories = new List<SelectListItem>();

			foreach(var category in categories)
			{
				CheeseCategories.Add(new SelectListItem
				{
					Value = category.ID.ToString(),
					Text = category.Name.ToString()
				});
			}
		}


	}

}

