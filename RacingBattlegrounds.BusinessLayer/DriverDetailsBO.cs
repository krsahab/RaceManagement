using RacingBattlegrounds.BusinessLayer.DTO;
using RacingBattlegrounds.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace RacingBattlegrounds.BusinessLayer
{
    public class DriverDetailsBO
    {
        public IEnumerable<DriverDetailsDTO> GetDriverDetails()
        {
            var DriverDetails = DriverDetailsDAO.GetDriverDetails();
            var DriverOtherDetails = DriverDetailsDAO.GetDriverOtherDetails();
            List<DriverDetailsDTO> DriverDetailsList = new List<DriverDetailsDTO>();
            foreach (var item in DriverOtherDetails)
            {
                DriverDetailsDTO driverDetailsDTO = new DriverDetailsDTO();

                driverDetailsDTO.DriverName = item.Name;
                driverDetailsDTO.RaceParticipated = item.RaceParticipated ?? 0;
                driverDetailsDTO.RaceWon = item.RaceWon ?? 0;
                driverDetailsDTO.TopSpeedDriven = item.TopSpeed ?? 0;

                var CWMW = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.CarWithMostWin).Where(x => !string.IsNullOrEmpty(x)));
                driverDetailsDTO.CarWithMostWins = string.IsNullOrEmpty(CWMW) ? Constants.NOT_AVAILABLE : CWMW;

                var CWML = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.CarWithMostLose).Where(x => !string.IsNullOrEmpty(x)));
                driverDetailsDTO.CarWithMostLosses = string.IsNullOrEmpty(CWML) ? Constants.NOT_AVAILABLE : CWML;

                var CTWMW = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.CategoryWithMostWin).Where(x => x != null));
                driverDetailsDTO.CategoryWithMostWins = string.IsNullOrEmpty(CTWMW) ? Constants.NOT_AVAILABLE : CTWMW;

                var CTWML = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.CategoryWithMostLose).Where(x => x != null));
                driverDetailsDTO.CategoryWithMostLosses = string.IsNullOrEmpty(CTWML) ? Constants.NOT_AVAILABLE : CTWML;

                var TWMW = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.TrackWithMostWin).Where(x => !string.IsNullOrEmpty(x))); ;
                driverDetailsDTO.TrackWithMostWins = string.IsNullOrEmpty(TWMW) ? Constants.NOT_AVAILABLE : TWMW;

                var TWML = String.Join(", ", DriverDetails.Where(x => x.DriverId == item.Id).Select(x => x.TrackWithMostLose).Where(x => !string.IsNullOrEmpty(x))); ;
                driverDetailsDTO.TrackWithMostLosses = string.IsNullOrEmpty(TWML) ? Constants.NOT_AVAILABLE : TWML;

                DriverDetailsList.Add(driverDetailsDTO);
            }
            return DriverDetailsList;
        }
    }
}
