using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCore.Web.Controllers
{
	public class Product2
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class OrnekController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}


		// veri tasimalari 
		public IActionResult VeriTasimaModelleri()
		{
			//ViewModel
			var productList = new List<Product2>()
			{
				new() {Id=1, Name="Kalem"},
				new(){ Id=2, Name="Defter"},
				new(){ Id=3, Name="Silgi"}
			};



			/*

						// ViewBag syntax ; viewbag.nesne1="ahmet";

						ViewBag.liste = new List<string>() { "ahmet", "mehmet", "serkan" };
						ViewBag.name = "Asp.Net Core";

						ViewBag.person = new { Id = 1, name = "ahmet", age = 23 };

						//ViewData syntax ; viewdata["nesne1"]=degerAta;

						ViewData["age"] = 30;

						ViewData["names"] = new List<string>() { "ahmet", "serkan", "ceyhan" };

						//TempData syntax ;  TempData["degerVer"] = "DegerVer";
						TempData["surname"] = "yildiz";
			*/

			return View(productList);
		}



		public IActionResult Index3()
		{
			return View();
		}




		//redirectoactioan

		public IActionResult Index2()
		{
			return RedirectToAction("index", "Home"); // ayni controllerda degil ise 2. par controller ismi
		}

		// action metodlarda parametre tanimlama
		public IActionResult ParametreView(int id)
		{
			return RedirectToAction("JsonParametre", "Ornek", new { id = id }); // 3. parametre verilen id
		}

		public IActionResult JsonParametre(int id)
		{
			return Json(new { Id = id });
		}



		//donus tipleri ornek

		public IActionResult ContentResult() // pek kullanilmaz gerektiginde
		{
			return Content("Content Result");
		}

		public IActionResult JsonResult() // ilerde kullanicaz
		{
			return Json(new { Id = 1, name = "kalem1", price = 100 }); // isimsiz sinif 
		}

		public IActionResult EmptyResult()
		{
			return new EmptyResult(); //syntax i
		}
	}
}
