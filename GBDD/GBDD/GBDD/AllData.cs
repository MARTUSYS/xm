using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GBDD
{
    public class AllData
    {
        /*
        public struct MyStruct
        {
            public static List<ClassPhoto> imageData = new List<ClassPhoto>();
        }
        */

        static private DBModel prof = new DBModel();
        static private AppealModel AppealM = new AppealModel();
        static private ObservableCollection<ClassPhoto> imageData = new ObservableCollection<ClassPhoto>();

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
            AppealM = model;
        }
        public static AppealModel GetAppealModel()
        {
            return AppealM;
        }

        public static void PushImageModel(ObservableCollection<ClassPhoto> model)
        {
            imageData = model;
        }

        public static ObservableCollection<ClassPhoto> GetImageModel()
        {
            return imageData;
        }

        public static void ClearModel()
        {
            DBModel prof_Clear = new DBModel();
            AppealModel AppealM_Clear = new AppealModel();
            ObservableCollection<ClassPhoto> imageData_Clear = new ObservableCollection<ClassPhoto>();

            prof = prof_Clear;
            AppealM = AppealM_Clear;
            imageData = imageData_Clear;
        }
    }
}
