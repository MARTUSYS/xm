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
        static private ModelAll Allfile = new ModelAll();


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

        public static ObservableCollection<ClassPhoto> GetImageModel()
        {
            return imageData;
        }

        public static ModelAll GetIModelAll()
        {
            Allfile.Region = prof.Region;
            Allfile.Subdivision = prof.Subdivision;
            Allfile.Position = prof.Position;
            Allfile.Full_name = prof.Full_name;
            Allfile.Last_name = prof.Last_name;
            Allfile.First_name = prof.First_name;
            Allfile.Patronymic = prof.Patronymic;
            Allfile.Phone = prof.Phone;
            Allfile.Email = prof.Email;
            Allfile.Event_location = prof.Event_location;
            Allfile.Organization = prof.Organization;
            Allfile.Name_of_company = prof.Name_of_company;
            Allfile.Additional_information = prof.Additional_information;
            Allfile.Outgoing_number = prof.Outgoing_number;
            Allfile.date_of_registration_of_the_document_in_the_organization = prof.date_of_registration_of_the_document_in_the_organization;
            Allfile.Registered_Mail_Number = prof.Registered_Mail_Number;
            Allfile.Text = AppealM.Text;

            return Allfile;
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
