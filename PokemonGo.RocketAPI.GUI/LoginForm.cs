using PokemonGo.RocketAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGo.RocketAPI.GUI
{
    public partial class LoginForm : Form
    {
        public AuthType auth;
        public bool loginSelected = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        AuthType getLoginType(string loginType) {
            string loginTypeLow = loginType.ToLower();
            switch (loginTypeLow) {
                case "google":
                    return AuthType.Google;
                case "ptc":
                    return AuthType.Ptc;
            }
            return AuthType.Ptc;
        }

        string getLoginTypeString(int loginType)
        {
            switch (loginType)
            {
                case 0:
                    return "Google";
                case 1:
                    return "PTC";
            }
            return "PTC";
        }

        //private ToolStripMenuItem[] curMenuItems = new ToolStripMenuItem[50];
        private ToolStripMenuItem accSub = new ToolStripMenuItem("Accounts");
        private void LoadAccounts() {
            var AccountArray = File.ReadAllLines(@"Configs/accounts.txt");
            var numOfAccounts = AccountArray.Length;
            char[] strSplitInfo = { ':' };

            accLogins.Items.Add(accSub);

            for (int i = 0; i < numOfAccounts; i++) {
                var accInfo = AccountArray[i].Split(strSplitInfo);
                for (var j = 0; j < accInfo.Length; j++)
                    accInfo[j] = accInfo[j].Trim();

                ToolStripMenuItem curMenuItems = new ToolStripMenuItem(accInfo[0] + " (" + accInfo[2] + ")");
                curMenuItems.Click += (sender, eventArgs) => {   
                    if (auth == AuthType.Google)
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    boxUsername.Text = accInfo[0];
                    boxPassword.Text = accInfo[1];
                    auth = getLoginType(accInfo[2]);
                    //loginSelected = true;
                    //this.Close();
                };
                accSub.DropDownItems.Add(curMenuItems);          
            }
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            auth = (AuthType) 1337;
            radioButton2.Checked = true;
            LoadAccounts();
        }

        private void btnPtcLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGoogleLogin_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                auth = AuthType.Google;
            else if (radioButton2.Checked)
                auth = AuthType.Ptc;
            else
                MessageBox.Show("Please Choose An Account Type!", "Error");

            if (!String.IsNullOrWhiteSpace(boxUsername.Text) || !String.IsNullOrWhiteSpace(boxPassword.Text) && auth != (AuthType)1337) {
                loginSelected = true;
                this.Close();
            }
            else
                MessageBox.Show("Invalid Username/Password!", "Error");
        }

        private void boxPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void boxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void accLogins_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void sharkNGUGToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nGUSharkPTCToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void accLogins_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void createPTCAccountToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://club.pokemon.com/us/pokemon-trainer-club/sign-up/");
        }

        private void addAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enterLogin loginForm = new enterLogin();
            loginForm.ShowDialog();

            if (!String.IsNullOrWhiteSpace(loginForm.returnStrUsr) ||
                !String.IsNullOrWhiteSpace(loginForm.returnStrPass)) {
                using (StreamWriter sw = File.AppendText(@"Configs/accounts.txt")) {
                    sw.WriteLine(loginForm.returnStrUsr + ": " + loginForm.returnStrPass + ": " +
                                 getLoginTypeString(loginForm.returnAccType));
                }
            }
            accSub.DropDownItems.Clear();
            LoadAccounts();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            boxUsername.Text = "Google Login";
            boxPassword.Text = "google";
            boxUsername.Enabled = false;
            boxPassword.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            boxUsername.Text = "";
            boxPassword.Text = "";
            boxUsername.Enabled = true;
            boxPassword.Enabled = true;
        }

        private void clearLoginTokensToolStripMenuItem_Click(object sender, EventArgs e) {
            UserSettings.Default.GoogleRefreshToken = "";
        }
    }
}
