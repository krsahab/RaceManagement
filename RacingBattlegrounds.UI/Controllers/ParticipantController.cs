using Newtonsoft.Json;
using RacingBattlegrounds.UI.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Participant
        public async Task<ActionResult> Index()
        {
            IEnumerable<ParticipantViewModel> Participants = Enumerable.Empty<ParticipantViewModel>();
            var result = await APIHelper.GetDataAsync("Participant");
            if (result.IsSuccessStatusCode)
                Participants = result.Content.ReadAsAsync<IEnumerable<ParticipantViewModel>>().Result;
            else
                ModelState.AddModelError(string.Empty, Constants.NO_DATA);
            return View(Participants);
        }

        // GET: Participant/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ParticipantViewModel Participants = null;
            var result = await APIHelper.GetDataAsync("Participant/" + id);
            if (result.IsSuccessStatusCode)
                Participants = result.Content.ReadAsAsync<ParticipantViewModel>().Result;
            else
                ModelState.AddModelError(string.Empty, Constants.NO_DATA);
            return View(Participants);
        }

        // GET: Participant/Create
        public async Task<ActionResult> Create()
        {
            var drivers = await GetAllDriversAsync();
            var cars = await GetAllCarsAsync();
            var races = await GetAllRacesAsync();
            ParticipantViewModel pvm = new ParticipantViewModel();
            pvm.Drivers = new SelectList(drivers, "Id", "Name");
            pvm.Races = new SelectList(races, "Id", "Name");
            pvm.Cars = new SelectList(cars, "Id", "Name");
            return View(pvm);
        }

        // POST: Participant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ParticipantViewModel Participant)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(Participant);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PostDataAsync("Participant", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(Participant);
        }

        // GET: Participant/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ParticipantViewModel Participant = null;
            var result = await APIHelper.GetDataAsync("Participant?Id=" + id);
            if (result.IsSuccessStatusCode)
            {
                Participant = result.Content.ReadAsAsync<ParticipantViewModel>().Result;
                var drivers = await GetAllDriversAsync();
                var cars = await GetAllCarsAsync();
                var races = await GetAllRacesAsync();
                Participant.Drivers = new SelectList(drivers, "Id", "Name");
                Participant.Races = new SelectList(races, "Id", "Name");
                Participant.Cars = new SelectList(cars, "Id", "Name");
            }
            return View(Participant);
        }

        // POST: Participant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ParticipantViewModel Participant)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(Participant);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PutDataAsync("Participant", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(Participant);
        }

        // GET: Participant/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ParticipantViewModel Participants = null;
            var result = await APIHelper.GetDataAsync("Participant?Id=" + id);
            if (result.IsSuccessStatusCode)
                Participants = result.Content.ReadAsAsync<ParticipantViewModel>().Result;
            else
                ModelState.AddModelError(string.Empty, Constants.NO_DATA);
            return View(Participants);
        }

        // POST: Participant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            var result = await APIHelper.DeleteDataAsync("Participant?Id=" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, "Error Occured");
            return View(id);
        }
        [NonAction]
        public async Task<IEnumerable<DriverViewModel>> GetAllDriversAsync()
        {
            IEnumerable<DriverViewModel> drivers = Enumerable.Empty<DriverViewModel>();
            var result = await APIHelper.GetDataAsync("driver");
            if (result.IsSuccessStatusCode)
                drivers = result.Content.ReadAsAsync<IEnumerable<DriverViewModel>>().Result;
            return drivers;
        }
        [NonAction]
        public async Task<IEnumerable<RaceViewModel>> GetAllRacesAsync()
        {
            IEnumerable<RaceViewModel> races = Enumerable.Empty<RaceViewModel>();
            var result = await APIHelper.GetDataAsync("Race");
            if (result.IsSuccessStatusCode)
                races = result.Content.ReadAsAsync<IEnumerable<RaceViewModel>>().Result;
            return races;
        }
        [NonAction]
        public async Task<IEnumerable<CarViewModel>> GetAllCarsAsync()
        {
            IEnumerable<CarViewModel> cars = Enumerable.Empty<CarViewModel>();
            var result = await APIHelper.GetDataAsync("Car");
            if (result.IsSuccessStatusCode)
                cars = result.Content.ReadAsAsync<IEnumerable<CarViewModel>>().Result;
            return cars;
        }
    }
}