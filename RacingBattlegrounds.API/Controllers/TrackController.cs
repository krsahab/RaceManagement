using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Track Related Operations
    /// </summary>
    public class TrackController : ApiController
    {
        TrackBO track = new TrackBO();
        /// <summary>
        /// Get All Tracks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrackDTO> GetTracks()
        {
            return track.GetTracks();
        }
        /// <summary>
        /// Get Details Of Particular Car
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TrackDTO GetTrackDetails(int Id)
        {
            return track.GetTrackDetails(Id);
        }
        /// <summary>
        /// Update Car Details
        /// </summary>
        /// <param name="car"></param>
        [HttpPut]
        public void UpdateTrackDetails(TrackDTO car)
        {
            track.UpdateTrackDetails(car);
        }
        /// <summary>
        /// Add New Car
        /// </summary>
        /// <param name="car"></param>
        [HttpPost]
        public void AddTrack(TrackDTO car)
        {
            track.AddTrack(car);
        }
        /// <summary>
        /// Delete an Specific Car
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        public void DeleteTrack(int Id)
        {
            track.DeleteTrack(Id);
        }
    }
}
