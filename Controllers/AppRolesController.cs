using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace St10375622Part2.Controllers
{
	public class AppRolesController : Controller
	{

		private readonly RoleManager<IdentityRole> _roleManager;

		public AppRolesController(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		//list all the roles created
		public IActionResult Index()
		{

			var roles = _roleManager.Roles;
			return View(roles);
		}

		//return the view to create a new role
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		//create a new role
		//Digital TechJoint(2023) ASP.NET MVC - How To Implement Role-Based Authorization 
		[HttpPost]
		public async Task<IActionResult> Create(IdentityRole model)
		{
			if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
			}
			return RedirectToAction("Index");
		}
	}
}
