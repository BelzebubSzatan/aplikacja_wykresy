using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aplikacja_wykresy
{
    public partial class App : Application
    {
        public static List<GraphElement> Elements = new List<GraphElement>();
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
