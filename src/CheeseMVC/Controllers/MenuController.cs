using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
	public class MenuController : Controller
	{

		private readonly CheeseDbContext context;

		public MenuController(CheeseDbContext dbContext)
		{
			context = dbContext;
		}

		public IActionResult Index()
		{
			var menus = context.Menus.ToList();

			return View(menus);

		}

		public IActionResult Add()
		{
			AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
			ViewBag.Title = "New Menu";
			return View(addMenuViewModel);
		}

		[HttpPost]
		public IActionResult Add(AddMenuViewModel addMenuViewModel)
		{

			if (ModelState.IsValid)
			{
				Menu newMenu = new Menu
				{
					Name = addMenuViewModel.Name
				};
				context.Menus.Add(newMenu);
				context.SaveChanges();
				return Redirect("/Menu/ViewMenu/" + newMenu.ID);
			}
			return View(addMenuViewModel);

		}

		public IActionResult ViewMenu(int id)
		{

			var menu = context.Menus.Single(c => c.ID == id);
			List<CheeseMenu> items = context
				.CheeseMenus
				.Include(item => item.Cheese)
				.Where(cm => cm.MenuID == id)
				.ToList();
			ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel(menu, items);

			return View(viewMenuViewModel);
		}

		public IActionResult AddItem(int id)
		{

			var menu = context.Menus.Single(c => c.ID == id);
			List<Cheese> cheeses = context.Cheeses.ToList();
			AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu, cheeses);

			return View(addMenuItemViewModel);
		}
		
		[HttpPost]
		public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
		{

			if (ModelState.IsValid)
			{
				var cheeseID = addMenuItemViewModel.cheeseID;
				var menuID = addMenuItemViewModel.menuID;
				IList<CheeseMenu> existingItems = context.CheeseMenus
					.Where(cm => cm.CheeseID == cheeseID)
					.Where(cm => cm.MenuID == menuID).ToList();

				if (existingItems.Count.Equals(0))
				{
					CheeseMenu menuItem = new CheeseMenu
					{
						Cheese = context.Cheeses.Single(c => c.ID == cheeseID),
						Menu = context.Menus.Single(m => m.ID == menuID)
					};

					context.CheeseMenus.Add(menuItem);
					context.SaveChanges();
				}
				return Redirect("/Menu/ViewMenu/" + menuID);
			}
			return View(addMenuItemViewModel);
		}
	}
}