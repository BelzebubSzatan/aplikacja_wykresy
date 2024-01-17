using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aplikacja_wykresy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ChangeData_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}