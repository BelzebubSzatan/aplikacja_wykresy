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
    public partial class DataPage : ContentPage
    {
        List<GraphElement> elements=new List<GraphElement>();
        public DataPage()
        {
            InitializeComponent();
        }

        private async void ChangeData_Clicked(object sender, EventArgs e)
        {
            App.Elements.Clear();
            for(int i = 0; i < 7; ++i)
            {
                List<Entry> entries=DataGrid.Children.OfType<Entry>().Where(z=>z.ClassId==i.ToString()).ToList();
                if (entries.Count == 2)
                {
                    if (entries[0].Text !=null && entries[1].Text !=null)
                    {
                        elements.Add(new GraphElement()
                        {
                            Name = entries[0].Text,
                            Value = double.Parse(entries[1].Text),
                        });
                    }
                }
            }
            App.Elements = elements;
            await Navigation.PopToRootAsync();
        }
    }
}