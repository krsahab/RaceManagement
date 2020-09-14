using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class RaceBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Race, RaceDTO>().ForMember(x => x.Track_Id, x => x.MapFrom(y => y.Track.Id))));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<RaceDTO, Race>().ForMember(x => x.Track, x => x.MapFrom(y => TrackDAO.GetTrackDetails(y.Track_Id)))));
        public IEnumerable<RaceDTO> GetRaces()
        {
            return mapperOP.Map<IEnumerable<Race>, IEnumerable<RaceDTO>>(RaceDAO.GetRaces());
        }
        public RaceDTO GetRaceDetails(int Id)
        {
            return mapperOP.Map<Race, RaceDTO>(RaceDAO.GetRaceDetails(Id));
        }
        public void UpdateRaceDetails(RaceDTO track)
        {
            RaceDAO.UpdateRaceDetails(mapperIP.Map<RaceDTO, Race>(track));
        }
        public void AddRace(RaceDTO track)
        {
            RaceDAO.AddRace(mapperIP.Map<RaceDTO, Race>(track));
        }
        public void DeleteRace(int Id)
        {
            RaceDAO.DeleteRace(Id);
        }
    }
}
