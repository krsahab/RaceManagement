﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using RacingBattlegrounds.UI.Models.ViewModel;
using System.Configuration;
using RacingBattlegrounds.UI.Utility;

namespace RacingBattlegrounds.UI.Controllers
{
    public class RaceDetailsController : Controller
    {
        // GET: RaceDetails
        public ActionResult Index()
        {
            IEnumerable<RaceDetailsViewModel> raceDetails = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIBaseAddress"]);
                var responseTask = client.GetAsync("RaceDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<RaceDetailsViewModel>>();
                    readTask.Wait();
                    raceDetails = readTask.Result;
                }
                else
                {
                    raceDetails = Enumerable.Empty<RaceDetailsViewModel>();
                    ModelState.AddModelError(string.Empty, Constants.NO_DATA);
                }
            }
            return View(raceDetails);
        }
    }
}