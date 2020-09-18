using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class RaceDetailsBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Participant, RaceDetailsDTO>()
        .ForMember(d => d.CarName, x => x.MapFrom(y => y.Car.Name))
        .ForMember(d => d.City, x => x.MapFrom(y => y.Race.Track.City))
        .ForMember(d => d.DriverName, x => x.MapFrom(y => y.Driver.Name))
        .ForMember(d => d.EngineCapacity, x => x.MapFrom(y => y.Race.EngineCapacity))
        .ForMember(d => d.TrackLength, x => x.MapFrom(y => y.Race.Track.Length))
        .ForMember(d => d.TrackName, x => x.MapFrom(y => y.Race.Track.Name))));
        public IEnumerable<RaceDetailsDTO> GetRaceDetails()
        {
            return mapperOP.Map<IEnumerable<Participant>, IEnumerable<RaceDetailsDTO>>(RaceDetailsDAO.GetRaceDetails());
        }
    }
}
