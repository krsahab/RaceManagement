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
    public class TrackController : Controller
    {
        // GET: Track
        public async Task<ActionResult> Index()
        {
            IEnumerable<TrackViewModel> tracks = Enumerable.Empty<TrackViewModel>();
            var result = await APIHelper.GetDataAsync("Track");
            if (result.IsSuccessStatusCode)
                tracks = result.Content.ReadAsAsync<IEnumerable<TrackViewModel>>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return View(tracks);
        }

        // GET: Track/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TrackViewModel track = null;
            var result = await APIHelper.GetDataAsync("Track?Id=" + id);
            if (result.IsSuccessStatusCode)
                track = result.Content.ReadAsAsync<TrackViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (track == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(track);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PostDataAsync("Track", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(track);
        }

        // GET: Track/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TrackViewModel track = null;
            var result = await APIHelper.GetDataAsync("Track?Id=" + id);
            if (result.IsSuccessStatusCode)
                track = result.Content.ReadAsAsync<TrackViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (track == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(track);
        }

        // POST: Track/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(track);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PutDataAsync("Track", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(track);
        }

        // GET: Track/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TrackViewModel track = null;
            var result = await APIHelper.GetDataAsync("Track?Id=" + id);
            if (result.IsSuccessStatusCode)
                track = result.Content.ReadAsAsync<TrackViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (track == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, FormCollection collection)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = await APIHelper.DeleteDataAsync("Track?Id=" + id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, Constants.ERROR);
            return View(id);
        }
    }
}
