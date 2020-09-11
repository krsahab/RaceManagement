using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RacingBattlegrounds.UI.Models.ViewModel;
using RacingBattlegrounds.BusinessLayer.DTO;

namespace RacingBattlegrounds.UI.App_Start
{
    public class MappingProfile:Profile
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
        }
    }
}