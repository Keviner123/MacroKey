using Newtonsoft.Json;
using Plugin.Vibrate;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MacroKey
{
    public class Item
    {
        public string Image { get; set; }
        public string MacroID { get; set; }
        public string Type { get; set; }
    }

    public class RootObject
    {
        public List<Item> items { get; set; }
    }


    public partial class MainPage : ContentPage
    {
        public class MacroContainer
        {
            public string Image;
            public string MacroID;
            public string Type;
        }

        public string ServerIP = "192.168.1.33:5000";
        public string CurrentPage = "MainPage";
        public List<MacroContainer> CurrentPageMacros;

        public List<MacroContainer> GetMacroPage(string Page)
        {
            var client = new RestClient("http://" + ServerIP + "/page/" + Page);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            RootObject MacroPage = JsonConvert.DeserializeObject<RootObject>(response.Content);

            List<MacroContainer> MacroList = new List<MacroContainer>();

            for (int ItemCounter = 0; ItemCounter < MacroPage.items.Count; ItemCounter++)
            {
                MacroContainer Macro = new MacroContainer();
                Macro.Image = MacroPage.items[ItemCounter].Image;
                Macro.MacroID = MacroPage.items[ItemCounter].MacroID;
                Macro.Type = MacroPage.items[ItemCounter].Type;

                MacroList.Add(Macro);
            }

            CurrentPageMacros = MacroList;
            return MacroList;
        }

        public void SetButtons(List<MacroContainer> Macros)
        {

            Button1.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[0].Image),
                CachingEnabled = false,
            };
            Button1.ClassId = "1";

            Button2.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[1].Image),
                CachingEnabled = false,
            };
            Button2.ClassId = "2";

            Button3.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[2].Image),
                CachingEnabled = false,
            };
            Button3.ClassId = "3";

            Button4.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[3].Image),
                CachingEnabled = false,
            };
            Button4.ClassId = "4";

            Button5.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[4].Image),
                CachingEnabled = false,
            };
            Button5.ClassId = "5";

            Button6.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[5].Image),
                CachingEnabled = false,
            };
            Button6.ClassId = "6";

            Button7.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[6].Image),
                CachingEnabled = false,
            };
            Button7.ClassId = "7";

            Button8.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[7].Image),
                CachingEnabled = false,
            };
            Button8.ClassId = "8";

            Button9.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[8].Image),
                CachingEnabled = false,
            };
            Button9.ClassId = "9";

            Button10.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[9].Image),
                CachingEnabled = false,
            };
            Button10.ClassId = "10";

            Button11.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[10].Image),
                CachingEnabled = false,
            };
            Button11.ClassId = "11";

            Button12.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[11].Image),
                CachingEnabled = false,
            };
            Button12.ClassId = "12";

            Button13.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[12].Image),
                CachingEnabled = false,
            };
            Button13.ClassId = "13";

            Button14.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[13].Image),
                CachingEnabled = false,
            };
            Button14.ClassId = "14";

            Button15.Source = new UriImageSource
            {
                Uri = new Uri("http://" + ServerIP + "/Images/" + Macros[14].Image),
                CachingEnabled = false,
            };
            Button15.ClassId = "15";

        }

        public MainPage(string IP)
        {
            InitializeComponent();

            ServerIP = IP+":5000";

            List<MacroContainer> DefaultMacros = GetMacroPage(CurrentPage);

            SetButtons(DefaultMacros);
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            CrossVibrate.Current.Vibration(TimeSpan.FromMilliseconds(50));

            var ButtonSender = (Image)sender;
            MacroContainer Macro = CurrentPageMacros[(Int32.Parse(ButtonSender.ClassId) - 1)];

            if (Macro.Type == "Folder")
            {
                List<MacroContainer> NewMacroPage = GetMacroPage(Macro.MacroID);

                SetButtons(NewMacroPage);
            }
            else
            {
                var client = new RestClient("http://" + ServerIP + "/macro/" + Macro.MacroID);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

            }
        }
    }
}
