using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
	public class ViewMenuViewModel
	{
		public ViewMenuViewModel(Menu menu, List<CheeseMenu> items)
		{
			Menu = menu;
			Items = items;
		}

		public Menu Menu { get; set; }

		public IList<CheeseMenu> Items { get; set; }
	}
}
