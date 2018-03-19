using ClientGUIAsync.JCDLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUIAsync
{
    public partial class App : Form
    {
        List<Station> stations;

        VelibsRetrieverClient client;

        public App()
        {
            InitializeComponent();

            client = new VelibsRetrieverClient();

            List<string> cities = client.getCities().ToList();

            foreach (string item in cities)
            {
                cBoxVilles.Items.Add(item);
            }
            cBoxVilles.SelectedIndex = 0;
            stations = new List<Station>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            stations.Clear();

            getStationDataStation(cBoxVilles.SelectedItem.ToString(), txtStation.Text, listItems).ContinueWith(delegate { });

            /*Task<List<Station>> task = client.getListStationFromCityAsync(cBoxVilles.SelectedItem.ToString(), txtStation.Text);

            Task continuation = task.ContinueWith(t =>
            {

                listItems.SelectedIndexChanged -= listItems_SelectedIndexChanged;
                listItems.DataSource = null;
                listItems.DisplayMember = "Name";
                listItems.DataSource = task.Result;
                //listItems.SelectedIndex = -1; // This optional line keeps the first item from being selected.
                listItems.SelectedIndexChanged += listItems_SelectedIndexChanged;

            });
            continuation.Wait();*/

            ////stations = client.getListStationFromCity(cBoxVilles.SelectedItem.ToString(), txtStation.Text).ToList<Station>();

            //string ville = cBoxVilles.SelectedItem.ToString();
            //string station = txtStation.Text;

            //Task t = Task.Factory.StartNew(() => getStationDataStation(ville, station));
            //t.Wait();


        }

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //msgBox.Show(listItems.SelectedItem.ToString());
            MsgBox msgBox = new MsgBox();
            msgBox.Text = ((Station)listItems.SelectedItem).Name;
            msgBox.Show(stationToString((Station)listItems.SelectedItem));



        }

        private string stationToString(Station station)
        {

            return "Nom : " + station.Name + "\n"
                + "Status : " + station.Status + "\n"
                + "Address : " + station.Address + "\n"
                + "Available bike stands : " + station.Available_bike_stands + "\n"
                + "Available bikes : " + station.Available_bikes;

        }

        async Task getStationDataStation(string city, string station, ListBox listItems)
        {

            try
            {
                Task<List<Station>> task = new VelibsRetrieverClient().getListStationFromCityAsync(city, station);
                if (task == await Task.WhenAny(task, Task.Delay(10000000)))
                {
                    listItems.SelectedIndexChanged -= listItems_SelectedIndexChanged;
                    listItems.DataSource = null;
                    listItems.DisplayMember = "Name";
                    listItems.DataSource = await task;
                    listItems.SelectedIndex = -1; // This optional line keeps the first item from being selected.
                    listItems.SelectedIndexChanged += listItems_SelectedIndexChanged;
                }
                else Console.WriteLine("Timed out");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
