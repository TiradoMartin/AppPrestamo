using AppPrestamo.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage navPage = new NavigationPage(new RegistPrestamo());
            navPage.BarTextColor = Color.White;
            navPage.BarBackgroundColor = Color.Black;
            navPage.Title = "APP PRESTAMO";
           


            MainPage = navPage;
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
