using System;
using System.Collections.Generic;
using System.Text;

namespace GBDD
{
    public class AllData
    {
        static DBModel prof = new DBModel();
        static AppealModel AppealM = new AppealModel();

        public static void PushDBModel(DBModel model)
        {
            prof = model;
        }
        public static DBModel GetDBModel()
        {
            return prof;
        }

        public static void PushAppealModel(AppealModel model)
        {
            AppealM = (AppealModel)model;
        }
        public static AppealModel GetAppealModel()
        {
            return AppealM;
        }
    }
}
