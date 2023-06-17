using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCore.Web.Controllers
{
	public class ExampleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult NoLayout() // layout kullanmamak icin nolayout u sec
		{
			return View();
		}
	}
}
