using System.Collections.Generic;
using Wheres_My_Well.Services;
using Wheres_My_Well.Views;
using Xamarin.Forms;

namespace Wheres_My_Well
{
    public partial class App : Application
    {
        public IOCService IOC { get; private set; }

        public App()
        {
            InitializeComponent();
            IOC = new IOCService();

            MainPage = IOC.Resolve<MainPage>();
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
