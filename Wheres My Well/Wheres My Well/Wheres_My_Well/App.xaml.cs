﻿using Xamarin.Forms;

namespace Wheres_My_Well
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Wheres_My_Well.Views.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
