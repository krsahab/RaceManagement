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
    public class DriverController : Controller
    {
        // GET: Driver
        public async Task<ActionResult> Index()
        {
            IEnumerable<DriverViewModel> driver = Enumerable.Empty<DriverViewModel>();
            var result = await APIHelper.GetDataAsync("driver");
            if (result.IsSuccessStatusCode)
                driver = result.Content.ReadAsAsync<IEnumerable<DriverViewModel>>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return View(driver);
        }

        // GET: driver/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DriverViewModel driver = null;
            var result = await APIHelper.GetDataAsync("driver?Id=" + id);
            if (result.IsSuccessStatusCode)
                driver = result.Content.ReadAsAsync<DriverViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (driver == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(driver);
        }

        // GET: driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: driver/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DriverViewModel driver)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(driver);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PostDataAsync("driver", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(driver);
        }

        // GET: driver/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DriverViewModel driver = null;
            var result = await APIHelper.GetDataAsync("driver?Id=" + id);
            if (result.IsSuccessStatusCode)
                driver = result.Content.ReadAsAsync<DriverViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (driver == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(driver);
        }

        // POST: driver/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DriverViewModel driver)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(driver);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PutDataAsync("driver", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(driver);
        }

        // GET: driver/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DriverViewModel driver = null;
            var result = await APIHelper.GetDataAsync("driver?Id=" + id);
            if (result.IsSuccessStatusCode)
                driver = result.Content.ReadAsAsync<DriverViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (driver == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(driver);
        }

        // POST: driver/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteDriver()
        {
            var Id = Request["Id"];
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = await APIHelper.DeleteDataAsync("driver?Id=" + Id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, Constants.ERROR);
            return View(Id);
        }
    }
}