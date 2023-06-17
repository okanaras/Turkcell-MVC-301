namespace MyAspNetCore.Web.Models
{
	public class ProductRepository
	{
		private static List<Product> _products = new List<Product>()
		{

		}; // nesne ornegi olustur

		public List<Product> GetAll() => _products; //urun listeleme

		public void Add(Product newProduct) => _products.Add(newProduct); // urun ekleme product tan nesne daha sonra products a ekleme metodu

		public void Remove(int id) // parametre olarak silinecek olan urunun id sini ver
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == id); // sorgulama islemi 

			if (hasProduct == null)
			{
				throw new Exception($"Bu id({id})'ye sahip urun bulunmamaktadir.");
			}
			_products.Remove(hasProduct);
		}

		public void Update(Product updateProduct) // parametre olarak class ismi ve nesne adi ver ornek update edilcek isim
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id); // update edilecek datanin olup olmamasini sorguladik.

			if (hasProduct == null) // eger yoksa hata mesaji firlattik
			{
				throw new Exception($"Bu id({updateProduct.Id})'ye sahip urun bulunmamaktadir."); // $ sirf + ile birlestirmemek icin kullandik
			}

			hasProduct.Name = updateProduct.Name;
			hasProduct.Price = updateProduct.Price;
			hasProduct.Stock = updateProduct.Stock;

			// daha sonra dizindeki index i bul
			var index = _products.FindIndex(x => x.Id
			== updateProduct.Id);


			_products[index] = hasProduct;
		}

	}
}
