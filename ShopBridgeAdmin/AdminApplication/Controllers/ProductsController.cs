using AdminApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AdminApplication.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {

            IEnumerable<mvcProductsModel> productlist;
            HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            productlist = responce.Content.ReadAsAsync<IEnumerable<mvcProductsModel>>().Result;
            return View(productlist);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcProductsModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProductsModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcProductsModel product)
        {
            if (product.ProductId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.ProductId, product).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}