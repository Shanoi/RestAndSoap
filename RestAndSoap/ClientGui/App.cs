using ClientGui.VelibsService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGui
{
    public partial class App : Form
    {
        
        List<Station> stations;

        VelibsRetrieverClient client;

        public App()
        {
            InitializeComponent();

            client = new VelibsRetrieverClient();

            List<string> cities = client.getCities().ToList<string>();
            
            foreach (string item in cities)
            {
                cBoxVilles.Items.Add(item);
            }
            cBoxVilles.SelectedIndex = 0;
            stations = new List<Station>();
        }

        private void getData(string city)
        {



            client.getDataFromCityStation(city, txtStation.Text);
                

           /* WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=7efd1067c82b1c9593faa098b1f7f5ea02cd272e");
            
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            data = reader.ReadToEnd();
            jsonArrayStation = JArray.Parse(data);
            Console.WriteLine(data);

            foreach (JObject item in jsonArrayStation)
            {

                string name = (String)item.GetValue("name");
                if (name.ToUpper().Contains(txtStation.Text.ToUpper()))
                {
                    stations.Add(new Station((String)item.GetValue("name"),
                        (String)item.GetValue("address"),
                        (String)item.GetValue("status"),
                        (int)item.GetValue("available_bike_stands"),
                        (int)item.GetValue("available_bikes")));

                }
            }*/

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            stations.Clear();

            getData(cBoxVilles.SelectedItem.ToString());

            listItems.SelectedIndexChanged -= listItems_SelectedIndexChanged;
            listItems.DataSource = null;
            listItems.DisplayMember = "Name";
            listItems.DataSource = stations;
            listItems.SelectedIndex = -1; // This optional line keeps the first item from being selected.
            listItems.SelectedIndexChanged += listItems_SelectedIndexChanged;

        }

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //msgBox.Show(listItems.SelectedItem.ToString());
            MsgBox msgBox = new MsgBox();
            msgBox.Text = ((Station)listItems.SelectedItem).Name;
            msgBox.Show(listItems.SelectedItem.ToString());

        }
    }
}
