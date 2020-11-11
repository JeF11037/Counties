using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Counties
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, string> DICT_counties = new Dictionary<string, string>
        {
            ["Harju County"] = "Tallinn",
            ["Hiiu County"] = "Kardla",
            ["Ida-Viru County"] = "Johvi",
            ["Jõgeva County"] = "Jogeva",
            ["Järva County"] = "Paide",
            ["Lääne County"] = "Haapsalu",
            ["Lääne-Viru County"] = "Rakvere",
            ["Põlva County"] = "Polva",
            ["Pärnu County"] = "Parnu",
            ["Rapla County"] = "Rapla",
            ["Saare County"] = "Kuressaare",
            ["Tartu County"] = "Tartu",
            ["Valga County"] = "Valga",
            ["Viljandi County"] = "Viljandi",
            ["Võru County"] = "Voru",
        };
        public MainPage()
        {
            InitializeComponent();
            cnts.ItemsSource = DICT_counties.Keys.ToList();
            cpls.ItemsSource = DICT_counties.Values.ToList();
        }


        private void ChangeTheContent(int idx)
        {
            if (idx > 0 && idx < DICT_counties.Count)
            {
                cnts.SelectedIndex = idx;
                cpls.SelectedIndex = idx;
                img.Source = DICT_counties.Values.ElementAt(idx) + ".png";
                ent.Text = DICT_counties.Keys.ElementAt(idx);
            }
        }

        private new void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Picker pick = (Picker)sender;
            ChangeTheContent(pick.SelectedIndex);
        }

        private void ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int tick = 0; tick < DICT_counties.Count-1; tick++)
            {
                if (ent.Text.ToLower() == DICT_counties.Values.ElementAt(tick).ToLower())
                {
                    ChangeTheContent(tick);
                }
                if (ent.Text.ToLower() == DICT_counties.Keys.ElementAt(tick).ToLower())
                {
                    ChangeTheContent(tick);
                }
            }
        }
    }
}
