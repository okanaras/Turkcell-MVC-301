using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;

namespace MyAspNetCore.Web.Controllers
{
	public class ProductsController : Controller
	{
		private IHelper _helper; //singleton ornek icin / scoped icinde gerekkli
		private AppDbContext _context; // appdbcontext ten nesne olusturduk daha sonra constr metoda parametre olarak appdbcontext context nesnesini verip suslu de eslestiriyoruz
		private readonly ProductRepository _productRepository;
		public ProductsController(AppDbContext context, IHelper helper) // kurucu metot controller cagirildiginda burasi calisacak ve parametre olarak appdbcontext ve context atayip asagida eslestirdik / singleton ve scoped icinde gerekkli
		{
			_helper = helper; //singleton ornek icin / scoped icinde gerekkli
			_productRepository = new ProductRepository();
			_context = context; //nesne ile parametre degiskenini esletirdik ve index metoduna gidip urunleri listeledik

			// burada verileri artik kullanicidan aldigimiz icin gerek yok
			/* if (!_context.Products.Any()) // eger ki bu kosulu yazmasa idik her sayfa yenilemesinde vt ye veri kaydedecekti.
			{
				_context.Products.Add(new Product { Name = "Kalem 1", Price = 100, Stock = 200, Color = "red" }); // yeni sutunlar icin proplari ekledik
				_context.Products.Add(new Product { Name = "Kalem 2", Price = 100, Stock = 200, Color = "red" }); // index.cshtml e git sutun gozukmesi icin ilgili kodu yaz
				_context.Products.Add(new Product { Name = "Kalem 3", Price = 100, Stock = 200, Color = "red" });

				_context.SaveChanges(); // vt ye kayit islemini yaptik
			}*/
		}

		public IActionResult Index([FromServices] IHelper helper2)
		{
			var text = "Asp.Net"; //singleton ornek icin  / scoped icinde gerekkli
			var upperText = _helper.Upper(text); // upper metodunu cagirdik 
			var status = _helper.Equals(helper2); // transient uretilen nesne esit mi oncekine onu kontrol ettik
			var products = _context.Products.ToList(); // kayitlarin listelenmesini sagladik
			return View(products);
		}

		public IActionResult Remove(int id) // remove action
		{
			var product = _context.Products.Find(id);
			_context.Products.Remove(product);

			_context.SaveChanges(); // vtye isletiyoruz.
									// _productRepository.Remove(id); artik bunu kaldiriyoruz
			return RedirectToAction("Index");
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]  // httppost ve action method tanimla
		public IActionResult Add(Product newProduct) // METHOD 3 BURAYA PRODUCT CLASS I VE DEGISKEN ATAYIP ASAGIDAKI ADD METODUNA YONLENDIRIYORUZ DAHA SONRA ADD VIEW E GIDIYORUZ!

		{
			_context.Products.Add(newProduct);
			_context.SaveChanges();

			TempData["status"] = "Urun basariyle eklendi."; // redirectoaction dan hemen once tanimladik tempdata dedik cunku farkli view veri tasidik or add action dan index e
			return RedirectToAction("Index");


			/*
				 METHOD 2 START 
				// burasi 2. method icindi public IActionResult Add(string Name, decimal Price, int Stock, string Color) // veri almak icin 2. yol burdaki parametreye deger ver ve asagida product sinifindan nesne olusturup birbir ile esle ve db kaydet
				// yukarda parametre olarak formdaki name leri turleri ile atadik ve metod adini artik add yaptik

					******************
				Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock, Color = Color };

				_context.Products.Add(newProduct);
				_context.SaveChanges();

				 METHOD 2 END 


				METHOD 1 START 

				var name = HttpContext.Request.Form["Name"].ToString();   // burada verileri httpcontxt request form ile alip degiskene atiyip daha sonra to stringe ceviriyoruz
				var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString()); // sayilari parse ya da convert et
				var stock = Convert.ToInt32(HttpContext.Request.Form["Stock"].ToString());
				var color = HttpContext.Request.Form["Color"].ToString();


				// daha sonra Product newProduct olusturup birbiri ile esliyoruz 
				Product newProduct = new Product() { Name = name, Stock = stock, Price = price, Color = color };

				// vt ye kayit yaptirip index e yonlendiriyoruz
				_context.Products.Add(newProduct);
				_context.SaveChanges();

				 METHOD 1 END 
			*/


		}
		public IActionResult Update(int id)
		{
			var product = _context.Products.Find(id); // buraya guncellenecek id yi alip onu view a gonderiyoruz ki neyi guncelleyecegini bilsin.
			return View(product);
		}
		[HttpPost] // UNUTMA
		public IActionResult Update(Product updateProduct, string type)  // class adi ve degisken 
		{
			_context.Products.Update(updateProduct); // guncelleme isleme
			_context.SaveChanges();                 // kaydetme islemi

			TempData["status"] = "Urun basariyle guncellendi."; // redirectoaction dan hemen once tanimladik tempdata dedik cunku farkli view veri tasidik or update action dan index e
			return RedirectToAction("Index");
		}
	}
}
