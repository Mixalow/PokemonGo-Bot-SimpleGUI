namespace PokemonGo.RocketAPI.GUI
{
    partial class LocationSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationSelector));
            this.boxLat = new System.Windows.Forms.TextBox();
            this.boxLng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLocations = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.settingStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveSelectedLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addrBox = new System.Windows.Forms.TextBox();
            this.addrSearch = new System.Windows.Forms.Button();
            this.updLocationBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.settingStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxLat
            // 
            this.boxLat.Location = new System.Drawing.Point(377, 569);
            this.boxLat.Name = "boxLat";
            this.boxLat.Size = new System.Drawing.Size(87, 20);
            this.boxLat.TabIndex = 2;
            this.boxLat.TextChanged += new System.EventHandler(this.boxLat_TextChanged);
            this.boxLat.Leave += new System.EventHandler(this.boxLat_Leave);
            // 
            // boxLng
            // 
            this.boxLng.Location = new System.Drawing.Point(530, 569);
            this.boxLng.Name = "boxLng";
            this.boxLng.Size = new System.Drawing.Size(87, 20);
            this.boxLng.TabIndex = 3;
            this.boxLng.TextChanged += new System.EventHandler(this.boxLng_TextChanged);
            this.boxLng.Leave += new System.EventHandler(this.boxLng_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Longitude";
            // 
            // btnSetLocation
            // 
            this.btnSetLocation.Location = new System.Drawing.Point(623, 567);
            this.btnSetLocation.Name = "btnSetLocation";
            this.btnSetLocation.Size = new System.Drawing.Size(87, 23);
            this.btnSetLocation.TabIndex = 6;
            this.btnSetLocation.Text = "Set Location";
            this.btnSetLocation.UseVisualStyleBackColor = true;
            this.btnSetLocation.Click += new System.EventHandler(this.btnSetLocation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Saved Locations";
            // 
            // comboLocations
            // 
            this.comboLocations.ContextMenuStrip = this.contextMenuStrip1;
            this.comboLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocations.FormattingEnabled = true;
            this.comboLocations.Location = new System.Drawing.Point(105, 574);
            this.comboLocations.Name = "comboLocations";
            this.comboLocations.Size = new System.Drawing.Size(194, 21);
            this.comboLocations.TabIndex = 8;
            this.comboLocations.SelectedIndexChanged += new System.EventHandler(this.comboLocations_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLocationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // deleteLocationToolStripMenuItem
            // 
            this.deleteLocationToolStripMenuItem.Name = "deleteLocationToolStripMenuItem";
            this.deleteLocationToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteLocationToolStripMenuItem.Text = "Delete Location";
            this.deleteLocationToolStripMenuItem.Click += new System.EventHandler(this.deleteLocationToolStripMenuItem_Click);
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.ContextMenuStrip = this.settingStrip;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(12, 12);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(698, 544);
            this.MainMap.TabIndex = 9;
            this.MainMap.Zoom = 0D;
            this.MainMap.Load += new System.EventHandler(this.MainMap_Load_1);
            // 
            // settingStrip
            // 
            this.settingStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSelectedLocationToolStripMenuItem});
            this.settingStrip.Name = "settingStrip";
            this.settingStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.settingStrip.ShowImageMargin = false;
            this.settingStrip.Size = new System.Drawing.Size(170, 48);
            this.settingStrip.Text = "Settings";
            this.settingStrip.Opening += new System.ComponentModel.CancelEventHandler(this.settingStrip_Opening);
            // 
            // saveSelectedLocationToolStripMenuItem
            // 
            this.saveSelectedLocationToolStripMenuItem.Name = "saveSelectedLocationToolStripMenuItem";
            this.saveSelectedLocationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveSelectedLocationToolStripMenuItem.Text = "Save Selected Location";
            this.saveSelectedLocationToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedLocationToolStripMenuItem_Click);
            // 
            // addrBox
            // 
            this.addrBox.Location = new System.Drawing.Point(377, 598);
            this.addrBox.Name = "addrBox";
            this.addrBox.Size = new System.Drawing.Size(240, 20);
            this.addrBox.TabIndex = 10;
            this.addrBox.Leave += new System.EventHandler(this.addrBox_Leave);
            // 
            // addrSearch
            // 
            this.addrSearch.Location = new System.Drawing.Point(623, 598);
            this.addrSearch.Name = "addrSearch";
            this.addrSearch.Size = new System.Drawing.Size(86, 22);
            this.addrSearch.TabIndex = 11;
            this.addrSearch.Text = "Search";
            this.addrSearch.UseVisualStyleBackColor = true;
            this.addrSearch.Click += new System.EventHandler(this.addrSearch_Click);
            // 
            // updLocationBtn
            // 
            this.updLocationBtn.Location = new System.Drawing.Point(12, 598);
            this.updLocationBtn.Name = "updLocationBtn";
            this.updLocationBtn.Size = new System.Drawing.Size(287, 23);
            this.updLocationBtn.TabIndex = 12;
            this.updLocationBtn.Text = "Update Locations";
            this.updLocationBtn.UseVisualStyleBackColor = true;
            this.updLocationBtn.Click += new System.EventHandler(this.updLocationBtn_Click);
            // 
            // LocationSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 628);
            this.Controls.Add(this.updLocationBtn);
            this.Controls.Add(this.addrSearch);
            this.Controls.Add(this.addrBox);
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.comboLocations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxLng);
            this.Controls.Add(this.boxLat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationSelector";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Starting Location";
            this.Load += new System.EventHandler(this.LocationSelector_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.settingStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox boxLat;
        private System.Windows.Forms.TextBox boxLng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLocations;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.TextBox addrBox;
        private System.Windows.Forms.Button addrSearch;
        private System.Windows.Forms.Button updLocationBtn;
        private System.Windows.Forms.ContextMenuStrip settingStrip;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedLocationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteLocationToolStripMenuItem;
    }
}