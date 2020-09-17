using RacingBattlegrounds.UI.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class RaceDetailsController : Controller
    {
        // GET: RaceDetails
        public async Task<ActionResult> Index()
        {
            IEnumerable<RaceDetailsViewModel> raceDetails = Enumerable.Empty<RaceDetailsViewModel>();
            var result = await APIHelper.GetDataAsync("RaceDetails");
            if (result.IsSuccessStatusCode)
                raceDetails = result.Content.ReadAsAsync<IEnumerable<RaceDetailsViewModel>>().Result;
            else
                ModelState.AddModelError(string.Empty, Constants.NO_DATA);
            return View(raceDetails);
        }
    }
}