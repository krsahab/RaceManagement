using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RacingBattlegrounds.UI.Models.ViewModel;
using System.Configuration;
using RacingBattlegrounds.UI.Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class DriverDetailsController : Controller
    {
        // GET: DriverDetails
        public ActionResult Index()
        {
            IEnumerable<DriverDetailsViewModel> driverDetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("DriverDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<DriverDetailsViewModel>>();
                    readTask.Wait();
                    driverDetails = readTask.Result;
                }
                else
                {
                    driverDetails = Enumerable.Empty<DriverDetailsViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(driverDetails);
        }
    }
}