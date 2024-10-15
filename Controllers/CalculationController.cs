using Microsoft.AspNetCore.Mvc;
using St10375622Part2.Data.Migrations;
using System.Net.NetworkInformation;
using St10375622Part2.Models;

namespace St10375622Part2.Controllers
{
	public class CalculationController : Controller
	{
		//GET
		public IActionResult Index()
		{
			return View();
		}

		//Post method to handle the calculation submittion
		[HttpPost]
		public IActionResult Calculate(Calculation model)
		{
			//check if the model is valid based on the attributes
			if (ModelState.IsValid)
			{
				try
				{
					//preform the calculation using the CalculateTotalPayment method
					model.CalculateTotalPayment();
				}
				catch (Exception ex) 
				{
					//Handle any errors during the calculation
					//& add to the model state
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			//Return the Index view with the updated model
			return View("Index", model);
		}
	}
}
