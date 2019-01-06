﻿using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
	public class AddMenuViewModel
	{
		[Required(ErrorMessage = "You must give your menu a name")]
		[Display(Name = "Menu Name")]
		public string Name { get; set; }

		public AddMenuViewModel()
		{
		}
		public AddMenuViewModel(List<Menu> menus) { }
	}
}
