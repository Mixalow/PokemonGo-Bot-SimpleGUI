using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using Newtonsoft.Json;

namespace PokemonGo.RocketAPI.GUI {
    public partial class LocationSelector : Form {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public class Loc {
            public string name { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }

            public override string ToString() {
                return name;
            }
        }

        public class AddressComponent {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Northeast {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Bounds {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Location {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast2 {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest2 {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport {
            public Northeast2 northeast { get; set; }
            public Southwest2 southwest { get; set; }
        }

        public class Geometry {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class RootObject {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }


        public static RootObject GetLatLongByAddress(string address) {
            var root = new RootObject();

            var url =
                string.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=true_or_false", address);
            var req = (HttpWebRequest) WebRequest.Create(url);

            var res = (HttpWebResponse) req.GetResponse();

            using (var streamreader = new StreamReader(res.GetResponseStream())) {
                var result = streamreader.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(result)) {
                    root = JsonConvert.DeserializeObject<RootObject>(result);
                }
            }
            return root;
        }

        public double lat;
        public double lng;
        public bool setPos;

        public LocationSelector() {
            InitializeComponent();
        }

        private void addGoodFarmingLocations() {
            comboLocations.Items.Clear();
            var locationArray = File.ReadAllLines(@"locations.txt");
            var numOfLocations = locationArray.Length;
            char[] strSplitInfo = {':'};

            for (var i = 0; i < numOfLocations; i++) {
                var locInfo = locationArray[i].Split(strSplitInfo);
                for (var j = 0; j < locInfo.Length; j++)
                    locInfo[j] = locInfo[j].Trim();
                comboLocations.Items.Add(new Loc {
                    name = locInfo[0],
                    lat = Convert.ToDouble(locInfo[1]),
                    lng = Convert.ToDouble(locInfo[2])
                });
            }
        }

        private void LocationSelector_Load(object sender, EventArgs e) {
            // Create the Map
            initializeMap();
            SendMessage(addrBox.Handle, 0x1501, 1, "Type Location Here...");

            // Add Options
            addGoodFarmingLocations();
        }

        private void initializeMap() {
            try {
                // Load the Map Settings
                MainMap.OnMapDrag += MainMap_OnMapDrag;
                MainMap.DragButton = MouseButtons.Left;
                MainMap.MapProvider = GMapProviders.GoogleMap;
                MainMap.Position = new PointLatLng(UserSettings.Default.DefaultLatitude,
                    UserSettings.Default.DefaultLongitude);
                MainMap.MinZoom = 0;
                MainMap.MaxZoom = 24;
                MainMap.Zoom = 15;

                // Set the Initial Position
                boxLat.Text = UserSettings.Default.DefaultLatitude.ToString("0.000000");
                boxLng.Text = UserSettings.Default.DefaultLongitude.ToString("0.000000");

                // Assign Variables
                lat = UserSettings.Default.DefaultLatitude;
                lng = UserSettings.Default.DefaultLongitude;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainMap_OnMapDrag() {
            // Update Position
            lat = MainMap.Position.Lat;
            lng = MainMap.Position.Lng;

            // Update the TextBoxes
            boxLat.Text = lat.ToString("0.000000");
            boxLng.Text = lng.ToString("0.000000");
        }

        private void btnSetLocation_Click(object sender, EventArgs e) {
            // Persist the Position
            lat = MainMap.Position.Lat;
            lng = MainMap.Position.Lng;

            // User Settings
            UserSettings.Default.DefaultLatitude = lat;
            UserSettings.Default.DefaultLongitude = lng;
            UserSettings.Default.Save();

            // Confirm Position Selection
            setPos = true;

            // Close this Window
            Hide();
        }

        private void setMiniMapLocation(double alat, double alng) {
            try {
                lat = alat;
                lng = alng;
                MainMap.Position = new PointLatLng(lat, lng);

                boxLat.Text = alat.ToString();
                boxLng.Text = alng.ToString();
            }
            catch (Exception ex) {
                boxLat.Text = lat.ToString();
                boxLng.Text = lng.ToString();
            }
        }

        private void comboLocations_SelectedIndexChanged(object sender, EventArgs e) {
            // Get the Item Selected
            var location = (Loc) comboLocations.SelectedItem;
            setMiniMapLocation(location.lat, location.lng);
        }

        private void MainMap_Load(object sender, EventArgs e) {}

        private void MainMap_Load_1(object sender, EventArgs e) {}

        private void boxLat_TextChanged(object sender, EventArgs e) {
            // Store the Variables
            //lat = Convert.ToDouble(boxLat.Text);
            //lng = Convert.ToDouble(boxLng.Text);

            //// Update the Map
            //MainMap.Position = new GMap.NET.PointLatLng(lat, lng);
        }

        private void boxLng_TextChanged(object sender, EventArgs e) {}

        private void addrSearch_Click(object sender, EventArgs e) {
            try {
                var destination_latLong = GetLatLongByAddress(addrBox.Text);
                MainMap.Position = new PointLatLng(destination_latLong.results[0].geometry.location.lat, destination_latLong.results[0].geometry.location.lng);
                boxLng.Text = Convert.ToString(destination_latLong.results[0].geometry.location.lng);
                boxLat.Text = Convert.ToString(destination_latLong.results[0].geometry.location.lat);
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid Location!", "Error");
            }
        }


        private void addrBox_Leave(object sender, EventArgs e) {
            SendMessage(addrBox.Handle, 0x1501, 1, "Please type here.");
        }

        private void boxLat_Leave(object sender, EventArgs e) {
            try {
                setMiniMapLocation(Convert.ToDouble(boxLat.Text), Convert.ToDouble((boxLng.Text)));
            }
            catch {
                boxLat.Text = lat.ToString();
                boxLng.Text = lng.ToString();
                MessageBox.Show("Invalid Input!", "Error");
            }
        }

        private void boxLng_Leave(object sender, EventArgs e) {
            try {
                setMiniMapLocation(Convert.ToDouble(boxLat.Text), Convert.ToDouble((boxLng.Text)));
            }
            catch {
                boxLat.Text = lat.ToString();
                boxLng.Text = lng.ToString();
                MessageBox.Show("Invalid Input!", "Error");
            }
        }

        private void saveSelectedLocationToolStripMenuItem_Click(object sender, EventArgs e) {
            enterName nameForm = new enterName();
            enterName.formNameTxt = "";
            nameForm.ShowDialog();

            if (!String.IsNullOrWhiteSpace(enterName.formNameTxt))
            {
                using (StreamWriter sw = File.AppendText(@"locations.txt")) {
                    sw.WriteLine(enterName.formNameTxt + ": " + lat + ": " + lng);
                }
            }
            addGoodFarmingLocations();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            
        }

        private void deleteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(@"locations.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    char[] strSplitInfo = { ':' };
                    string[] splitLines = line.Split(strSplitInfo);

                    if (splitLines[0] != comboLocations.Text)
                        sw.WriteLine(line);
                }
            }
   
            File.Delete(@"locations.txt");
            File.Move(tempFile, @"locations.txt");

            comboLocations.Items.Remove(comboLocations.SelectedIndex);
            addGoodFarmingLocations();
        }

        private void updLocationBtn_Click(object sender, EventArgs e)
        {
            addGoodFarmingLocations();
        }

        private void settingStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
