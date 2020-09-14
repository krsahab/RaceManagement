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
    public class RaceController : Controller
    {
        // GET: Race
        public ActionResult Index()
        {
            IEnumerable<RaceViewModel> races = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Race");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<RaceViewModel>>();
                    readTask.Wait();
                    races = readTask.Result;
                }
                else
                {
                    races = Enumerable.Empty<RaceViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(races);
        }

        // GET: Race/Details/5
        public ActionResult Details(int id)
        {
            RaceViewModel races = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Race/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceViewModel>();
                    readTask.Wait();
                    races = readTask.Result;
                }
                else
                {
                    races = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(races);
        }

        // GET: Race/Create
        public ActionResult Create()
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
            RaceViewModel rvm = new RaceViewModel();
            rvm.Tracks = new SelectList(tracks, "Id", "Name");
            return View(rvm);
        }

        // POST: Race/Create
        [HttpPost]
        public ActionResult Create(RaceViewModel race)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PostAsJsonAsync<RaceDTO>("Race", Mapper.Map<RaceViewModel, RaceDTO>(race));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(race);
        }

        // GET: Race/Edit/5
        public ActionResult Edit(int id)
        {
            RaceViewModel races = null;
            IEnumerable<TrackViewModel> tracks = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Race?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceViewModel>();
                    readTask.Wait();
                    races = readTask.Result;
                    using (var tc = new HttpClient())
                    {
                        tc.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                        var trackResponse = tc.GetAsync("Track");
                        trackResponse.Wait();

                        var trackResult = trackResponse.Result;
                        if (trackResult.IsSuccessStatusCode)
                        {
                            var trackRead = trackResult.Content.ReadAsAsync<IEnumerable<TrackViewModel>>();
                            trackRead.Wait();
                            tracks = trackRead.Result;
                            races.Tracks = new SelectList(tracks, "Id", "Name");
                        }
                    }
                }
            }
            return View(races);
        }

        // POST: Race/Edit/5
        [HttpPost]
        public ActionResult Edit(RaceViewModel race)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PutAsJsonAsync<RaceDTO>("Race", Mapper.Map<RaceViewModel, RaceDTO>(race));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(race);
        }

        // GET: Race/Delete/5
        public ActionResult Delete(int id)
        {
            RaceViewModel races = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Race?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RaceViewModel>();
                    readTask.Wait();
                    races = readTask.Result;
                }
                else
                {
                    races = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(races);
        }

        // POST: Race/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.DeleteAsync("Race?Id=" + id);
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
