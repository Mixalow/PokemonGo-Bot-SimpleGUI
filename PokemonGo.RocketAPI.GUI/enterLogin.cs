using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGo.RocketAPI.GUI
{
    public partial class enterLogin : Form
    {
        public string returnStrUsr = "";
        public string returnStrPass = "";
        public int returnAccType = 1337;
        public enterLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                returnAccType = 0;
            else if (radioButton2.Checked)
                returnAccType = 1;
            else
                MessageBox.Show("Please Choose An Account Type!");

            if (!String.IsNullOrWhiteSpace(textBox1.Text) || !String.IsNullOrWhiteSpace(textBox2.Text) && returnAccType != 1337) {
                returnStrUsr = textBox1.Text;
                returnStrPass = textBox2.Text;
                this.Close();
            }
            else
                MessageBox.Show("Invalid Username/Password!");
        }
    }
}
