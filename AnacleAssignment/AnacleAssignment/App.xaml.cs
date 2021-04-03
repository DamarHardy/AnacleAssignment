using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnacleAssignment.datasource;
using System.IO;
using AnacleAssignment.ui;

namespace AnacleAssignment
{
    public partial class App : Application
    {
        private static UserDatabase userDatabase;
        public static UserDatabase Database
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
                }
                return userDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
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
