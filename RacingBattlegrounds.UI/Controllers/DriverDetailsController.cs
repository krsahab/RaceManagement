using RacingBattlegrounds.UI.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class DriverDetailsController : Controller
    {
        // GET: DriverDetails
        public async Task<ActionResult> Index()
        {
            IEnumerable<DriverDetailsViewModel> driverDetails = Enumerable.Empty<DriverDetailsViewModel>(); ;
            var result = await APIHelper.GetDataAsync("DriverDetails");
            if (result.IsSuccessStatusCode)
                driverDetails = result.Content.ReadAsAsync<IEnumerable<DriverDetailsViewModel>>().Result;
            else
                ModelState.AddModelError(string.Empty, Constants.NO_DATA);
            return View(driverDetails);
        }
    }
}