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
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult Index()
        {
            IEnumerable<TrackViewModel> tracks = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Track");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<TrackViewModel>>();
                    readTask.Wait();
                    tracks = readTask.Result;
                }
                else
                {
                    tracks = Enumerable.Empty<TrackViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(tracks);
        }

        // GET: Track/Details/5
        public ActionResult Details(int id)
        {
            TrackViewModel track = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Track?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TrackViewModel>();
                    readTask.Wait();
                    track = readTask.Result;
                }
                else
                {
                    track = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PostAsJsonAsync<TrackDTO>("Track", Mapper.Map<TrackViewModel, TrackDTO>(track));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            TrackViewModel track = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Track?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TrackViewModel>();
                    readTask.Wait();
                    track = readTask.Result;
                }
                else
                {
                    track = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(track);
        }

        // POST: Track/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PutAsJsonAsync<TrackDTO>("Track", Mapper.Map<TrackViewModel, TrackDTO>(track));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(track);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            TrackViewModel track = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Track?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TrackViewModel>();
                    readTask.Wait();
                    track = readTask.Result;
                }
                else
                {
                    track = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.DeleteAsync("Track?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(id);
        }
    }
}
