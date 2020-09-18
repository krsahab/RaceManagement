using Newtonsoft.Json;
using RacingBattlegrounds.UI.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class RaceController : Controller
    {
        // GET: Race
        public async Task<ActionResult> Index()
        {
            IEnumerable<RaceViewModel> races = Enumerable.Empty<RaceViewModel>();
            var result = await APIHelper.GetDataAsync("Race");
            if (result.IsSuccessStatusCode)
                races = result.Content.ReadAsAsync<IEnumerable<RaceViewModel>>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return View(races);
        }

        // GET: Race/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RaceViewModel races = null;
            var result = await APIHelper.GetDataAsync("Race/" + id);
            if (result.IsSuccessStatusCode)
                races = result.Content.ReadAsAsync<RaceViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (races == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(races);
        }

        // GET: Race/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<TrackViewModel> tracks = Enumerable.Empty<TrackViewModel>();
            var result = await APIHelper.GetDataAsync("Track");
            if (result.IsSuccessStatusCode)
                tracks = result.Content.ReadAsAsync<IEnumerable<TrackViewModel>>().Result;
            RaceViewModel rvm = new RaceViewModel();
            rvm.Tracks = new SelectList(tracks, "Id", "Name");
            return View(rvm);
        }

        // POST: Race/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RaceViewModel race)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(race);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PostDataAsync("Race", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(race);
        }

        // GET: Race/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RaceViewModel races = null;
            IEnumerable<TrackViewModel> tracks = Enumerable.Empty<TrackViewModel>();
            var result = await APIHelper.GetDataAsync("Race?Id=" + id);
            if (result.IsSuccessStatusCode)
            {
                races = result.Content.ReadAsAsync<RaceViewModel>().Result;
                if (races == null)
                    return new HttpNotFoundResult(Constants.NO_DATA);
                var trackResult = await APIHelper.GetDataAsync("Track");
                if (trackResult.IsSuccessStatusCode)
                    tracks = trackResult.Content.ReadAsAsync<IEnumerable<TrackViewModel>>().Result;
                races.Tracks = new SelectList(tracks, "Id", "Name");
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return View(races);
        }

        // POST: Race/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RaceViewModel race)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(race);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PutDataAsync("Race", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(race);
        }

        // GET: Race/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            RaceViewModel races = null;
            var result = await APIHelper.GetDataAsync("Race?Id=" + id);
            if (result.IsSuccessStatusCode)
                races = result.Content.ReadAsAsync<RaceViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (races == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(races);
        }

        // POST: Race/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, FormCollection collection)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = await APIHelper.DeleteDataAsync("Race?Id=" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, Constants.ERROR);
            return View(id);
        }
    }
}
