using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GBDD
{
    public partial class App : Application
    {
        static DataB database;

        public static DataB Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
