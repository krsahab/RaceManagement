using RacingBattlegrounds.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace RacingBattlegrounds.DataAccess.DAO
{
    public static class DriverDetailsDAO
    {
        private static readonly ApplicationDBContext context;
        static DriverDetailsDAO()
        {
            context = new ApplicationDBContext();
        }
        public static List<DriverDetailsModel> GetDriverDetails()
        {
            var command = "EXEC SP_GetDriverDetails;";
            return context.Database.SqlQuery<DriverDetailsModel>(command).ToList();
        }

        public static List<DriverOtherDetailsModel> GetDriverOtherDetails()
        {
            var command = "EXEC SP_GetDriverOtherDetails;";
            return context.Database.SqlQuery<DriverOtherDetailsModel>(command).ToList();
        }
    }
}
