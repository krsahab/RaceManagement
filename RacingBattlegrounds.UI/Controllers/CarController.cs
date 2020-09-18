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
    public class CarController : Controller
    {
        // GET: Car
        public async Task<ActionResult> Index()
        {
            IEnumerable<CarViewModel> cars = Enumerable.Empty<CarViewModel>();
            var result = await APIHelper.GetDataAsync("Car");
            if (result.IsSuccessStatusCode)
                cars = result.Content.ReadAsAsync<IEnumerable<CarViewModel>>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            return View(cars);
        }

        // GET: Car/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            CarViewModel car = null;
            var result = await APIHelper.GetDataAsync("Car?Id=" + id);
            if (result.IsSuccessStatusCode)
                car = result.Content.ReadAsAsync<CarViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (car == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(car);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PostDataAsync("Car", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            CarViewModel car = null;
            var result = await APIHelper.GetDataAsync("Car?Id=" + id);
            if (result.IsSuccessStatusCode)
                car = result.Content.ReadAsAsync<CarViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (car == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(car);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await APIHelper.PutDataAsync("Car", content);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            ModelState.AddModelError(string.Empty, Constants.BAD_DATA);
            return View(car);
        }

        // GET: Car/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            CarViewModel car = null;
            var result = await APIHelper.GetDataAsync("Car?Id=" + id);
            if (result.IsSuccessStatusCode)
                car = result.Content.ReadAsAsync<CarViewModel>().Result;
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            if (car == null)
                return new HttpNotFoundResult(Constants.NO_DATA);
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCar()
        {
            var Id = Request["Id"];
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var result = await APIHelper.DeleteDataAsync("Car?Id=" + Id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError(string.Empty, Constants.ERROR);
            return View(Id);
        }
    }
}
