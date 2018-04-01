using ClientGUI.JCDLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
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

            List<string> fidelity = client.getFidelityLevels().ToList();
            foreach (string item in fidelity)
            {
                cbFidelity.Items.Add(item);
            }
            cbFidelity.SelectedIndex = 0;

            stations = new List<Station>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            stations.Clear();

            string ville = cBoxVilles.SelectedItem.ToString();

            stations = client.getListStationFromCity(cBoxVilles.SelectedItem.ToString(), txtStation.Text, cbFidelity.SelectedItem.ToString()).ToList<Station>();

            lblLastUpdateValue.Text = (client.getLastUpdate(ville)).ToString("h:mm:ss tt");

            listItems.SelectedIndexChanged -= listItems_SelectedIndexChanged;
            listItems.DataSource = null;
            listItems.DisplayMember = "Name";
            listItems.DataSource = stations;
            listItems.SelectedIndex = -1; // This optional line keeps the first item from being selected.
            listItems.SelectedIndexChanged += listItems_SelectedIndexChanged;

        }

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {

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

    }
}
