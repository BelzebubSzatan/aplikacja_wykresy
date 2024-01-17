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

            if (App.Elements.Count == 0) return;

            Name.Text = App.Name;

            for(int i=0;i<App.Elements.Count;++i)
                BarGraph.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            double maxValue=App.Elements.Max(x => x.Value);

            for (int i = 0; i < App.Elements.Count; i++)
            {
                StackLayout container = new StackLayout();
                container.Orientation = StackOrientation.Vertical;
                container.VerticalOptions = LayoutOptions.End;
                StackLayout graphElement = new StackLayout()
                {
                    HeightRequest = App.Elements[i].Value/maxValue*500,
                    BackgroundColor = Color.Red,
                    VerticalOptions = LayoutOptions.End,
                };
                container.Children.Add(graphElement);
                container.Children.Add(new Label()
                {
                    Text = App.Elements[i].Name,
                    FontSize = 20,
                    TextColor = Color.Black,
                    HorizontalTextAlignment=TextAlignment.Center,
                });
                Grid.SetColumn(container,i);
                BarGraph.Children.Add(container);
            }

        }
    }
}