using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProektDomain.api_domain;
using ProektDomain.Domain;
using System.Reflection;
using System.Text;

namespace Integriraniproekt.Controllers
{
    public class BookController : Controller
    {
        public BookController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5095/api/Test/GetAllBooks";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            var data = response.Content.ReadAsAsync<List<Book>>().Result;
            return View(data);
        }
        public IActionResult Details(string id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5095/api/Test/GetDetailsForBook";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Book>().Result;


            return View(result);

        }
    }
}
