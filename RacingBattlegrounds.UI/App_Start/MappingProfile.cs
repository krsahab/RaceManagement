using AutoMapper;
using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.UI.Models.ViewModel;

namespace RacingBattlegrounds.UI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<DriverDetailsDTO, DriverDetailsViewModel>();
            Mapper.CreateMap<RaceDetailsDTO, RaceDetailsViewModel>();
            Mapper.CreateMap<CarDTO, CarViewModel>();
            Mapper.CreateMap<CarViewModel, CarDTO>();
            Mapper.CreateMap<TrackDTO, TrackViewModel>();
            Mapper.CreateMap<TrackViewModel, TrackDTO>();
            Mapper.CreateMap<RaceDTO, RaceViewModel>();
            Mapper.CreateMap<RaceViewModel, RaceDTO>();
            Mapper.CreateMap<DriverDTO, DriverViewModel>();
            Mapper.CreateMap<DriverViewModel, DriverDTO>();
            Mapper.CreateMap<ParticipantDTO, ParticipantViewModel>();
            Mapper.CreateMap<ParticipantViewModel, ParticipantDTO>();
        }
    }
}