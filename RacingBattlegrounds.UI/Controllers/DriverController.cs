using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.UI.Models.ViewModel;
using RacingBattlegrounds.UI.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace RacingBattlegrounds.UI.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            IEnumerable<DriverViewModel> driver = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("driver");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<DriverViewModel>>();
                    readTask.Wait();
                    driver = readTask.Result;
                }
                else
                {
                    driver = Enumerable.Empty<DriverViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(driver);
        }

        // GET: driver/Details/5
        public ActionResult Details(int id)
        {
            DriverViewModel driver = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("driver?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DriverViewModel>();
                    readTask.Wait();
                    driver = readTask.Result;
                }
                else
                {
                    driver = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(driver);
        }

        // GET: driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: driver/Create
        [HttpPost]
        public ActionResult Create(DriverViewModel driver)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PostAsJsonAsync("driver", Mapper.Map<DriverViewModel, DriverDTO>(driver));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(driver);
        }

        // GET: driver/Edit/5
        public ActionResult Edit(int id)
        {
            DriverViewModel driver = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("driver?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DriverViewModel>();
                    readTask.Wait();
                    driver = readTask.Result;
                }
                else
                {
                    driver = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(driver);
        }

        // POST: driver/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DriverViewModel driver)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PutAsJsonAsync("driver", Mapper.Map<DriverViewModel, DriverDTO>(driver));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(driver);
        }

        // GET: driver/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DriverViewModel driver = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("driver?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DriverViewModel>();
                    readTask.Wait();
                    driver = readTask.Result;
                }
                else
                {
                    driver = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(driver);
        }

        // POST: driver/Delete/5
        [HttpPost]
        public ActionResult DeleteDriver()
        {
            var Id = Request["Id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.DeleteAsync("driver?Id=" + Id);
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