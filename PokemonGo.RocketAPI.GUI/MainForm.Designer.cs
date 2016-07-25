namespace PokemonGo.RocketAPI.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbCanEvolveCont = new System.Windows.Forms.Label();
            this.cbKeepPkToEvolve = new System.Windows.Forms.CheckBox();
            this.btnRecycleItems = new System.Windows.Forms.Button();
            this.btnTransferDuplicates = new System.Windows.Forms.Button();
            this.btnEvolvePokemons = new System.Windows.Forms.Button();
            this.btnStopFarming = new System.Windows.Forms.Button();
            this.btnStartFarming = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPkmnCaptured = new System.Windows.Forms.Label();
            this.lbPkmnHr = new System.Windows.Forms.Label();
            this.lbExpHour = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbItemsInventory = new System.Windows.Forms.Label();
            this.lbPokemonsInventory = new System.Windows.Forms.Label();
            this.lbExperience = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.dGrid = new System.Windows.Forms.DataGridView();
            this.loggingBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxPokestopCount = new System.Windows.Forms.TextBox();
            this.boxPokestopInit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxPokestopName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxPokemonName = new System.Windows.Forms.TextBox();
            this.boxPokemonCaughtProb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbCanEvolveCont);
            this.groupBox1.Controls.Add(this.cbKeepPkToEvolve);
            this.groupBox1.Controls.Add(this.btnRecycleItems);
            this.groupBox1.Controls.Add(this.btnTransferDuplicates);
            this.groupBox1.Controls.Add(this.btnEvolvePokemons);
            this.groupBox1.Controls.Add(this.btnStopFarming);
            this.groupBox1.Controls.Add(this.btnStartFarming);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot Control";
            // 
            // lbCanEvolveCont
            // 
            this.lbCanEvolveCont.AutoSize = true;
            this.lbCanEvolveCont.Location = new System.Drawing.Point(28, 199);
            this.lbCanEvolveCont.Name = "lbCanEvolveCont";
            this.lbCanEvolveCont.Size = new System.Drawing.Size(61, 13);
            this.lbCanEvolveCont.TabIndex = 6;
            this.lbCanEvolveCont.Text = "can Evolve";
            // 
            // cbKeepPkToEvolve
            // 
            this.cbKeepPkToEvolve.AutoSize = true;
            this.cbKeepPkToEvolve.Checked = true;
            this.cbKeepPkToEvolve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepPkToEvolve.Enabled = false;
            this.cbKeepPkToEvolve.Location = new System.Drawing.Point(9, 186);
            this.cbKeepPkToEvolve.Name = "cbKeepPkToEvolve";
            this.cbKeepPkToEvolve.Size = new System.Drawing.Size(125, 17);
            this.cbKeepPkToEvolve.TabIndex = 5;
            this.cbKeepPkToEvolve.Text = "Keep Pokemons that";
            this.cbKeepPkToEvolve.UseVisualStyleBackColor = true;
            // 
            // btnRecycleItems
            // 
            this.btnRecycleItems.Enabled = false;
            this.btnRecycleItems.Location = new System.Drawing.Point(6, 225);
            this.btnRecycleItems.Name = "btnRecycleItems";
            this.btnRecycleItems.Size = new System.Drawing.Size(144, 46);
            this.btnRecycleItems.TabIndex = 4;
            this.btnRecycleItems.Text = "Recycle Items";
            this.btnRecycleItems.UseVisualStyleBackColor = true;
            this.btnRecycleItems.Click += new System.EventHandler(this.btnRecycleItems_Click);
            // 
            // btnTransferDuplicates
            // 
            this.btnTransferDuplicates.Enabled = false;
            this.btnTransferDuplicates.Location = new System.Drawing.Point(6, 139);
            this.btnTransferDuplicates.Name = "btnTransferDuplicates";
            this.btnTransferDuplicates.Size = new System.Drawing.Size(144, 46);
            this.btnTransferDuplicates.TabIndex = 3;
            this.btnTransferDuplicates.Text = "Transfer Duplicate Pokemons";
            this.btnTransferDuplicates.UseVisualStyleBackColor = true;
            this.btnTransferDuplicates.Click += new System.EventHandler(this.btnTransferDuplicates_Click);
            // 
            // btnEvolvePokemons
            // 
            this.btnEvolvePokemons.Enabled = false;
            this.btnEvolvePokemons.Location = new System.Drawing.Point(6, 87);
            this.btnEvolvePokemons.Name = "btnEvolvePokemons";
            this.btnEvolvePokemons.Size = new System.Drawing.Size(144, 46);
            this.btnEvolvePokemons.TabIndex = 2;
            this.btnEvolvePokemons.Text = "Evolve Pokemons w/Candy";
            this.btnEvolvePokemons.UseVisualStyleBackColor = true;
            this.btnEvolvePokemons.Click += new System.EventHandler(this.btnEvolvePokemons_Click);
            // 
            // btnStopFarming
            // 
            this.btnStopFarming.Enabled = false;
            this.btnStopFarming.Location = new System.Drawing.Point(6, 48);
            this.btnStopFarming.Name = "btnStopFarming";
            this.btnStopFarming.Size = new System.Drawing.Size(144, 23);
            this.btnStopFarming.TabIndex = 1;
            this.btnStopFarming.Text = "Stop Farming";
            this.btnStopFarming.UseVisualStyleBackColor = true;
            this.btnStopFarming.Click += new System.EventHandler(this.btnStopFarming_Click);
            // 
            // btnStartFarming
            // 
            this.btnStartFarming.Enabled = false;
            this.btnStartFarming.Location = new System.Drawing.Point(6, 19);
            this.btnStartFarming.Name = "btnStartFarming";
            this.btnStartFarming.Size = new System.Drawing.Size(144, 23);
            this.btnStartFarming.TabIndex = 0;
            this.btnStartFarming.Text = "Start Farming";
            this.btnStartFarming.UseVisualStyleBackColor = true;
            this.btnStartFarming.Click += new System.EventHandler(this.btnStartFarming_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbPkmnCaptured);
            this.groupBox3.Controls.Add(this.lbPkmnHr);
            this.groupBox3.Controls.Add(this.lbExpHour);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bot Stats";
            // 
            // lbPkmnCaptured
            // 
            this.lbPkmnCaptured.AutoSize = true;
            this.lbPkmnCaptured.Location = new System.Drawing.Point(6, 51);
            this.lbPkmnCaptured.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbPkmnCaptured.Name = "lbPkmnCaptured";
            this.lbPkmnCaptured.Size = new System.Drawing.Size(85, 13);
            this.lbPkmnCaptured.TabIndex = 3;
            this.lbPkmnCaptured.Text = "lbPkmnCaptured";
            // 
            // lbPkmnHr
            // 
            this.lbPkmnHr.AutoSize = true;
            this.lbPkmnHr.Location = new System.Drawing.Point(6, 35);
            this.lbPkmnHr.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbPkmnHr.Name = "lbPkmnHr";
            this.lbPkmnHr.Size = new System.Drawing.Size(53, 13);
            this.lbPkmnHr.TabIndex = 1;
            this.lbPkmnHr.Text = "lbPkmnHr";
            // 
            // lbExpHour
            // 
            this.lbExpHour.AutoSize = true;
            this.lbExpHour.Location = new System.Drawing.Point(6, 19);
            this.lbExpHour.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbExpHour.Name = "lbExpHour";
            this.lbExpHour.Size = new System.Drawing.Size(56, 13);
            this.lbExpHour.TabIndex = 0;
            this.lbExpHour.Text = "lbExpHour";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbItemsInventory);
            this.groupBox4.Controls.Add(this.lbPokemonsInventory);
            this.groupBox4.Controls.Add(this.lbExperience);
            this.groupBox4.Controls.Add(this.lbLevel);
            this.groupBox4.Controls.Add(this.lbName);
            this.groupBox4.Location = new System.Drawing.Point(12, 448);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 103);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Player Information";
            // 
            // lbItemsInventory
            // 
            this.lbItemsInventory.AutoSize = true;
            this.lbItemsInventory.Location = new System.Drawing.Point(6, 83);
            this.lbItemsInventory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbItemsInventory.Name = "lbItemsInventory";
            this.lbItemsInventory.Size = new System.Drawing.Size(84, 13);
            this.lbItemsInventory.TabIndex = 4;
            this.lbItemsInventory.Text = "lbItemsInventory";
            // 
            // lbPokemonsInventory
            // 
            this.lbPokemonsInventory.AutoSize = true;
            this.lbPokemonsInventory.Location = new System.Drawing.Point(6, 67);
            this.lbPokemonsInventory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbPokemonsInventory.Name = "lbPokemonsInventory";
            this.lbPokemonsInventory.Size = new System.Drawing.Size(65, 13);
            this.lbPokemonsInventory.TabIndex = 3;
            this.lbPokemonsInventory.Text = "lbPokemons";
            // 
            // lbExperience
            // 
            this.lbExperience.AutoSize = true;
            this.lbExperience.Location = new System.Drawing.Point(6, 51);
            this.lbExperience.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbExperience.Name = "lbExperience";
            this.lbExperience.Size = new System.Drawing.Size(68, 13);
            this.lbExperience.TabIndex = 2;
            this.lbExperience.Text = "lbExperience";
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Location = new System.Drawing.Point(6, 35);
            this.lbLevel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(41, 13);
            this.lbLevel.TabIndex = 1;
            this.lbLevel.Text = "lbLevel";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 19);
            this.lbName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(43, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "lbName";
            // 
            // dGrid
            // 
            this.dGrid.AllowUserToAddRows = false;
            this.dGrid.AllowUserToDeleteRows = false;
            this.dGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid.Location = new System.Drawing.Point(174, 21);
            this.dGrid.Name = "dGrid";
            this.dGrid.ReadOnly = true;
            this.dGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGrid.Size = new System.Drawing.Size(458, 212);
            this.dGrid.TabIndex = 0;
            // 
            // loggingBox
            // 
            this.loggingBox.Enabled = false;
            this.loggingBox.Location = new System.Drawing.Point(174, 322);
            this.loggingBox.Multiline = true;
            this.loggingBox.Name = "loggingBox";
            this.loggingBox.Size = new System.Drawing.Size(458, 229);
            this.loggingBox.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.boxPokestopCount);
            this.groupBox2.Controls.Add(this.boxPokestopInit);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.boxPokestopName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(174, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 73);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Pokestop";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "of";
            // 
            // boxPokestopCount
            // 
            this.boxPokestopCount.Enabled = false;
            this.boxPokestopCount.Location = new System.Drawing.Point(172, 45);
            this.boxPokestopCount.Name = "boxPokestopCount";
            this.boxPokestopCount.Size = new System.Drawing.Size(80, 20);
            this.boxPokestopCount.TabIndex = 8;
            this.boxPokestopCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // boxPokestopInit
            // 
            this.boxPokestopInit.Enabled = false;
            this.boxPokestopInit.Location = new System.Drawing.Point(57, 45);
            this.boxPokestopInit.Name = "boxPokestopInit";
            this.boxPokestopInit.Size = new System.Drawing.Size(87, 20);
            this.boxPokestopInit.TabIndex = 3;
            this.boxPokestopInit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Count";
            // 
            // boxPokestopName
            // 
            this.boxPokestopName.Enabled = false;
            this.boxPokestopName.Location = new System.Drawing.Point(57, 19);
            this.boxPokestopName.Name = "boxPokestopName";
            this.boxPokestopName.Size = new System.Drawing.Size(195, 20);
            this.boxPokestopName.TabIndex = 1;
            this.boxPokestopName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.boxPokemonName);
            this.groupBox5.Controls.Add(this.boxPokemonCaughtProb);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(438, 243);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(194, 73);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fighting Pokemon";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Capture %";
            // 
            // boxPokemonName
            // 
            this.boxPokemonName.Enabled = false;
            this.boxPokemonName.Location = new System.Drawing.Point(67, 19);
            this.boxPokemonName.Name = "boxPokemonName";
            this.boxPokemonName.Size = new System.Drawing.Size(118, 20);
            this.boxPokemonName.TabIndex = 11;
            this.boxPokemonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // boxPokemonCaughtProb
            // 
            this.boxPokemonCaughtProb.Enabled = false;
            this.boxPokemonCaughtProb.Location = new System.Drawing.Point(67, 45);
            this.boxPokemonCaughtProb.Name = "boxPokemonCaughtProb";
            this.boxPokemonCaughtProb.Size = new System.Drawing.Size(118, 20);
            this.boxPokemonCaughtProb.TabIndex = 18;
            this.boxPokemonCaughtProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Name";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "Change Location";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 562);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.loggingBox);
            this.Controls.Add(this.dGrid);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokemon Go Bot - SimpleGUI v0.11 (Beta)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStopFarming;
        private System.Windows.Forms.Button btnStartFarming;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbPkmnCaptured;
        private System.Windows.Forms.Label lbPkmnHr;
        private System.Windows.Forms.Label lbExpHour;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.DataGridView dGrid;
        private System.Windows.Forms.TextBox loggingBox;
        private System.Windows.Forms.Button btnRecycleItems;
        private System.Windows.Forms.Button btnTransferDuplicates;
        private System.Windows.Forms.Button btnEvolvePokemons;
        private System.Windows.Forms.Label lbCanEvolveCont;
        private System.Windows.Forms.CheckBox cbKeepPkToEvolve;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox boxPokestopCount;
        private System.Windows.Forms.TextBox boxPokestopInit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox boxPokestopName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox boxPokemonName;
        private System.Windows.Forms.TextBox boxPokemonCaughtProb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbExperience;
        private System.Windows.Forms.Label lbItemsInventory;
        private System.Windows.Forms.Label lbPokemonsInventory;
        private System.Windows.Forms.Button button1;
    }
}

