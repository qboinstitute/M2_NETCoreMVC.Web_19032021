using M2_NETCoreMVC.Web.Areas.Marketing.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsWithViewModel()
        {
            //var productVM = new ProductViewModel();
            //productVM.ListadoProducto = GetProductsJsonLocal();
                
            //var lista = new List<string>();
            //lista.Add("Juan");
            //lista.Add("Pedro");
            //lista.Add("Luis");
            //productVM.ListadoNombres = lista;
            var products = GetProductsJsonLocal();
            return View(products);
        }

        public IActionResult ProductsWithViewData()
        {
            var products = GetProductsJsonLocal();
            ViewData["ProductList"] = products;
            return View();
        }

        public async Task<IActionResult> ProductsWithViewBag()
        {
            var products = await GetProductsJsonRemote();
            ViewBag.ProductList = products;
            ViewBag.Title = "Products With View Bag";
            return View();
        }

        public IEnumerable<Product> GetProductsJsonLocal()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\Products.json");
            var json = System.IO.File.ReadAllText(folderDetails);

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsJsonRemote()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://raw.githubusercontent.com/dotnet-presentations/ContosoCrafts/master/src/wwwroot/data/products.json");
            string apiReponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiReponse);
            return products;
        }


    }
}
