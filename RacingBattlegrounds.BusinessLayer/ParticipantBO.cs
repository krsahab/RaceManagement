using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class ParticipantBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Participant, ParticipantDTO>()
        .ForMember(d => d.DriverId, x => x.MapFrom(y => y.Driver.Id))
        .ForMember(d => d.DriverName, x => x.MapFrom(y => y.Driver.Name))
        .ForMember(d => d.CarId, x => x.MapFrom(y => y.Car.Id))
        .ForMember(d => d.CarName, x => x.MapFrom(y => y.Car.Name))
        .ForMember(d => d.RaceId, x => x.MapFrom(y => y.Race.Id))
        .ForMember(d => d.RaceName, x => x.MapFrom(y => y.Race.Name))));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ParticipantDTO, Participant>()
        .ForMember(d => d.Race, x => x.MapFrom(y => RaceDAO.GetRaceDetails(y.RaceId)))
        .ForMember(d => d.Driver, x => x.MapFrom(y => DriverDAO.GetDriverDetails(y.DriverId)))
        .ForMember(d => d.Car, x => x.MapFrom(y => CarDetailsDAO.GetCarDetails(y.CarId)))));
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
