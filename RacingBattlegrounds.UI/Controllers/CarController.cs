using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.UI.Models.ViewModel;
using System.Configuration;
using RacingBattlegrounds.UI.Utility;
using RacingBattlegrounds.BusinessLayer.DTO;
using AutoMapper;

namespace RacingBattlegrounds.UI.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            IEnumerable<CarViewModel> cars = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Car");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<CarViewModel>>();
                    readTask.Wait();
                    cars = readTask.Result;
                }
                else
                {
                    cars = Enumerable.Empty<CarViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            CarViewModel car = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Car?Id="+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarViewModel>();
                    readTask.Wait();
                    car = readTask.Result;
                }
                else
                {
                    car  = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(CarViewModel car)
        {
            if(ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PostAsJsonAsync<CarDTO>("Car", Mapper.Map<CarViewModel,CarDTO>(car));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            CarViewModel car = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Car?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarViewModel>();
                    readTask.Wait();
                    car = readTask.Result;
                }
                else
                {
                    car = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PutAsJsonAsync<CarDTO>("Car", Mapper.Map<CarViewModel, CarDTO>(car));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(car);
        }

        // GET: Car/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CarViewModel car = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Car?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarViewModel>();
                    readTask.Wait();
                    car = readTask.Result;
                }
                else
                {
                    car = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult DeleteCar()
        {
            var Id = Request["Id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.DeleteAsync("Car?Id="+ Id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(Id);
        }
    }
}
