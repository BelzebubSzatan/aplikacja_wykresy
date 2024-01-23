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
        List<Color> colors = new List<Color>() {
            Color.Green, Color.Blue,
            Color.Red, Color.Magenta,
            Color.Yellow,Color.Orange,
            Color.PaleGreen, Color.Purple,
        };
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

            BarGraph.Children.Clear();
            Name.Text = App.Name;
            BarGraph.ColumnDefinitions.Clear();

            double maxValue = App.Elements.Max(x => x.Value);

            for (int i = 0; i < App.Elements.Count; i++)
            {
                BarGraph.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                StackLayout container = new StackLayout();
                container.Orientation = StackOrientation.Vertical;
                container.VerticalOptions = LayoutOptions.End;
                StackLayout graphElement = new StackLayout()
                {
                    HeightRequest = App.Elements[i].Value / maxValue * 500,
                    BackgroundColor = colors[i],
                    VerticalOptions = LayoutOptions.End,
                    ScaleY = 0,
                    AnchorY = 1
                };
                graphElement.Children.Add(new Label()
                {
                    Text = App.Elements[i].Value.ToString(),
                    VerticalOptions = LayoutOptions.Start,
                    TextColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Center,
                });
                container.Children.Add(graphElement);
                container.Children.Add(new Label()
                {
                    Text = App.Elements[i].Name,
                    FontSize = 20,
                    TextColor = Color.Black,
                    HorizontalTextAlignment = TextAlignment.Center,
                });
                Grid.SetColumn(container, i);
                BarGraph.Children.Add(container);
                graphElement.ScaleYTo(1, 2000, Easing.SinInOut);
            }

        }
    }
}