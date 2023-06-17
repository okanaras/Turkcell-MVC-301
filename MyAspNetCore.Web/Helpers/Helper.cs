namespace MyAspNetCore.Web.Helpers
{
	public class Helper : IHelper //singleton ornek icin
	{
		public string Upper(string text)
		{
			return text.ToUpper();
		}
	}
}
