﻿using System;
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
        List<GraphElement> elements = new List<GraphElement>();
        public DataPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.Elements.Count > 0)
            {
                for (int i = 0; i < App.Elements.Count; i++)
                {
                    List<Entry> entries = DataGrid.Children.OfType<Entry>().Where(z => z.ClassId == i.ToString()).ToList();
                    entries[0].Text = App.Elements[i].Name;
                    entries[1].Text = App.Elements[i].Value.ToString();
                }
            }
        }
        private async void ChangeData_Clicked(object sender, EventArgs e)
        {
            App.Elements.Clear();
            for (int i = 0; i < 7; ++i)
            {
                List<Entry> entries = DataGrid.Children.OfType<Entry>().Where(z => z.ClassId == i.ToString()).ToList();
                if (entries.Count == 2)
                {
                    if (entries[0].Text != null && entries[1].Text != null)
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
            App.Name = GraphName.Text ?? "Sample name";
            await Navigation.PopToRootAsync();
        }
    }
}