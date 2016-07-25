using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PokemonGo.RocketAPI.GUI
{
    public partial class enterName : Form
    {
        public string returnStr = "";
        public enterName()
        {
            InitializeComponent();
        }

        public static string formNameTxt = "";
        private void button1_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(textBox1.Text)) {
                formNameTxt = textBox1.Text;
                this.Close();
            }
            else
                MessageBox.Show("Invalid Name!");
        }

        private void enterName_Load(object sender, EventArgs e)
        {

        }
    }
}
