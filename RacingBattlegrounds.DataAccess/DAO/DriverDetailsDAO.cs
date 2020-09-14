using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class DriverDetailsDAO
    {
        public static List<DriverDetailsModel> GetDriverDetails()
        {
            using (var context = new ApplicationDBContext())
            {
                var command = "EXEC SP_GetDriverDetails;";
                return context.Database.SqlQuery<DriverDetailsModel>(command).ToList();
            }
        }

        public static List<DriverOtherDetailsModel> GetDriverOtherDetails()
        {
            using (var context = new ApplicationDBContext())
            {
                var command = "EXEC SP_GetDriverOtherDetails;";
                return context.Database.SqlQuery<DriverOtherDetailsModel>(command).ToList();
            }
        }
    }
}
