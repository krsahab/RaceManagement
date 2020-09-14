using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;

namespace RacingBattlegrounds.BusinessLayer
{
    public class TrackBO
    {
        Mapper mapperOP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Track, TrackDTO>()));
        Mapper mapperIP = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TrackDTO, Track>()));
        public IEnumerable<TrackDTO> GetTracks()
        {
            return mapperOP.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(TrackDAO.GetTracks());
        }
        public TrackDTO GetTrackDetails(int Id)
        {
            return mapperOP.Map<Track, TrackDTO>(TrackDAO.GetTrackDetails(Id));
        }
        public void UpdateTrackDetails(TrackDTO track)
        {
            TrackDAO.UpdateTrackDetails(mapperIP.Map<TrackDTO, Track>(track));
        }
        public void AddTrack(TrackDTO track)
        {
            TrackDAO.AddTrack(mapperIP.Map<TrackDTO, Track>(track));
        }
        public void DeleteTrack(int Id)
        {
            TrackDAO.DeleteTrack(Id);
        }
    }
}
