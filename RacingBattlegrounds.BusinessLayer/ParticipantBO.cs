using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class ParticipantBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Participant, ParticipantDTO>()));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ParticipantDTO, Participant>()));
        public IEnumerable<ParticipantDTO> GetParticipants()
        {
            return mapperOP.Map<IEnumerable<Participant>, IEnumerable<ParticipantDTO>>(ParticipantDAO.GetParticipants());
        }
        public ParticipantDTO GetParticipantDetails(int Id)
        {
            return mapperOP.Map<Participant, ParticipantDTO>(ParticipantDAO.GetParticipantDetails(Id));
        }
        public void UpdateParticipantDetails(ParticipantDTO Participant)
        {
            ParticipantDAO.UpdateParticipantDetails(mapperIP.Map<ParticipantDTO, Participant>(Participant));
        }
        public void AddParticipant(ParticipantDTO Participant)
        {
            ParticipantDAO.AddParticipant(mapperIP.Map<ParticipantDTO, Participant>(Participant));
        }
        public void DeleteParticipant(int Id)
        {
            ParticipantDAO.DeleteParticipant(Id);
        }
    }
}
