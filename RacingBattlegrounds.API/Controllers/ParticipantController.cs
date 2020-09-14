using RacingBattlegrounds.BusinessLayer;
using RacingBattlegrounds.BusinessLayer.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace RacingBattlegrounds.API.Controllers
{
    /// <summary>
    /// Participant Details
    /// </summary>
    public class ParticipantController : ApiController
    {
        ParticipantBO Participant = new ParticipantBO();
        /// <summary>
        /// Get All Participants
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ParticipantDTO> GetParticipants()
        {
            return Participant.GetParticipants();
        }
        /// <summary>
        /// Get Details Of Particular Participant
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ParticipantDTO GetParticipantDetails(int Id)
        {
            return Participant.GetParticipantDetails(Id);
        }
        /// <summary>
        /// Update Participant Details
        /// </summary>
        /// <param name="participant"></param>
        [HttpPut]
        public void UpdateParticipantDetails(ParticipantDTO participant)
        {
            Participant.UpdateParticipantDetails(participant);
        }
        /// <summary>
        /// Add New Participant
        /// </summary>
        /// <param name="participant"></param>
        [HttpPost]
        public void AddParticipant(ParticipantDTO participant)
        {
            Participant.AddParticipant(participant);
        }
        /// <summary>
        /// Delete an Specific Participant
        /// </summary>
        /// <param name="Id"></param>
        [HttpDelete]
        public void DeleteParticipant(int Id)
        {
            Participant.DeleteParticipant(Id);
        }
    }
}
