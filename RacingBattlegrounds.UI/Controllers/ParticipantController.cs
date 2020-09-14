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
    public class ParticipantController : Controller
    {
        // GET: Participant
        public ActionResult Index()
        {
            IEnumerable<ParticipantViewModel> Participants = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Participant");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ParticipantViewModel>>();
                    readTask.Wait();
                    Participants = readTask.Result;
                }
                else
                {
                    Participants = Enumerable.Empty<ParticipantViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(Participants);
        }

        // GET: Participant/Details/5
        public ActionResult Details(int id)
        {
            ParticipantViewModel Participants = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Participant/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ParticipantViewModel>();
                    readTask.Wait();
                    Participants = readTask.Result;
                }
                else
                {
                    Participants = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(Participants);
        }

        // GET: Participant/Create
        public ActionResult Create()
        {
            var drivers = GetAllDrivers();
            var cars = GetAllCars();
            var races = GetAllRaces();
            ParticipantViewModel pvm = new ParticipantViewModel();
            pvm.Drivers = new SelectList(drivers, "Id", "Name");
            pvm.Races = new SelectList(races, "Id", "Name");
            pvm.Cars = new SelectList(cars, "Id", "Name");
            return View(pvm);
        }

        // POST: Participant/Create
        [HttpPost]
        public ActionResult Create(ParticipantViewModel Participant)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PostAsJsonAsync("Participant", Mapper.Map<ParticipantViewModel, ParticipantDTO>(Participant));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(Participant);
        }

        // GET: Participant/Edit/5
        public ActionResult Edit(int id)
        {
            ParticipantViewModel Participant = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Participant?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ParticipantViewModel>();
                    readTask.Wait();
                    Participant = readTask.Result;
                    var drivers = GetAllDrivers();
                    var cars = GetAllCars();
                    var races = GetAllRaces();
                    Participant.Drivers = new SelectList(drivers, "Id", "Name");
                    Participant.Races = new SelectList(races, "Id", "Name");
                    Participant.Cars = new SelectList(cars, "Id", "Name");
                }
            }
            return View(Participant);
        }

        // POST: Participant/Edit/5
        [HttpPost]
        public ActionResult Edit(ParticipantViewModel Participant)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                    var responseTask = client.PutAsJsonAsync<ParticipantDTO>("Participant", Mapper.Map<ParticipantViewModel, ParticipantDTO>(Participant));
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(Participant);
        }

        // GET: Participant/Delete/5
        public ActionResult Delete(int id)
        {
            ParticipantViewModel Participants = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("Participant?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ParticipantViewModel>();
                    readTask.Wait();
                    Participants = readTask.Result;
                }
                else
                {
                    Participants = null;
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(Participants);
        }

        // POST: Participant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.DeleteAsync("Participant?Id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(id);
        }
        [NonAction]
        public IEnumerable<DriverViewModel> GetAllDrivers()
        {
            IEnumerable<DriverViewModel> drivers = null;
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
                    drivers = readTask.Result;
                }
                else
                    drivers = Enumerable.Empty<DriverViewModel>();

            }
            return drivers;
        }
        [NonAction]
        public IEnumerable<RaceViewModel> GetAllRaces()
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
                    races = Enumerable.Empty<RaceViewModel>();
            }
            return races;
        }
        [NonAction]
        public IEnumerable<CarViewModel> GetAllCars()
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
                    cars = Enumerable.Empty<CarViewModel>();
            }
            return cars;
        }
    }
}