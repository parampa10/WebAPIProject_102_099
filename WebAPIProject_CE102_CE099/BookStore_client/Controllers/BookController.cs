using BookStore_client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookStore_client.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44389/api");
        HttpClient client;

        public BookController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: Books
        public ActionResult Index()
        {
            List<Books> modelList = new List<Books>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/book").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Books>>(data);
            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Books b)
        {
            string data = JsonConvert.SerializeObject(b);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/Json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/book", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/book/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
          
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Books model = new Books();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/book/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Books>(data);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Books model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/Json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/book/" + model.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}