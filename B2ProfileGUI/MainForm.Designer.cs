namespace B2Profile
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
			this.MainMenu = new System.Windows.Forms.ToolStrip();
			this.MainMenuOpen = new System.Windows.Forms.ToolStripButton();
			this.MainMenuSave = new System.Windows.Forms.ToolStripButton();
			this.MainMenuAbout = new System.Windows.Forms.ToolStripButton();
			this.MainMenuClose = new System.Windows.Forms.ToolStripButton();
			this.BonusStatsTable = new System.Windows.Forms.DataGridView();
			this.BonusStatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BonusStatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BonusStatTokens = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BonusStatsTable)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuOpen,
            this.MainMenuSave,
            this.MainMenuAbout,
            this.MainMenuClose});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(477, 25);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "Main Menu";
			// 
			// MainMenuOpen
			// 
			this.MainMenuOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuOpen.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Open;
			this.MainMenuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuOpen.Name = "MainMenuOpen";
			this.MainMenuOpen.Size = new System.Drawing.Size(23, 22);
			this.MainMenuOpen.Text = "Open";
			// 
			// MainMenuSave
			// 
			this.MainMenuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuSave.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Save;
			this.MainMenuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuSave.Name = "MainMenuSave";
			this.MainMenuSave.Size = new System.Drawing.Size(23, 22);
			this.MainMenuSave.Text = "Save";
			// 
			// MainMenuAbout
			// 
			this.MainMenuAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuAbout.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_About;
			this.MainMenuAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuAbout.Name = "MainMenuAbout";
			this.MainMenuAbout.Size = new System.Drawing.Size(23, 22);
			this.MainMenuAbout.Text = "About";
			// 
			// MainMenuClose
			// 
			this.MainMenuClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuClose.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Close;
			this.MainMenuClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuClose.Name = "MainMenuClose";
			this.MainMenuClose.Size = new System.Drawing.Size(23, 22);
			this.MainMenuClose.Text = "Close";
			// 
			// BonusStatsTable
			// 
			this.BonusStatsTable.AllowUserToAddRows = false;
			this.BonusStatsTable.AllowUserToDeleteRows = false;
			this.BonusStatsTable.AllowUserToResizeColumns = false;
			this.BonusStatsTable.AllowUserToResizeRows = false;
			this.BonusStatsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BonusStatsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BonusStatsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BonusStatName,
            this.BonusStatValue,
            this.BonusStatTokens});
			this.BonusStatsTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BonusStatsTable.Location = new System.Drawing.Point(0, 25);
			this.BonusStatsTable.MultiSelect = false;
			this.BonusStatsTable.Name = "BonusStatsTable";
			this.BonusStatsTable.RowHeadersVisible = false;
			this.BonusStatsTable.RowHeadersWidth = 82;
			this.BonusStatsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.BonusStatsTable.RowTemplate.Height = 20;
			this.BonusStatsTable.Size = new System.Drawing.Size(477, 425);
			this.BonusStatsTable.TabIndex = 1;
			// 
			// BonusStatName
			// 
			this.BonusStatName.Frozen = true;
			this.BonusStatName.HeaderText = "Bonus Stat";
			this.BonusStatName.MinimumWidth = 10;
			this.BonusStatName.Name = "BonusStatName";
			this.BonusStatName.ReadOnly = true;
			this.BonusStatName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BonusStatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.BonusStatName.Width = 275;
			// 
			// BonusStatValue
			// 
			this.BonusStatValue.Frozen = true;
			this.BonusStatValue.HeaderText = "Value";
			this.BonusStatValue.MinimumWidth = 10;
			this.BonusStatValue.Name = "BonusStatValue";
			this.BonusStatValue.ReadOnly = true;
			this.BonusStatValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BonusStatValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// BonusStatTokens
			// 
			this.BonusStatTokens.Frozen = true;
			this.BonusStatTokens.HeaderText = "Tokens";
			this.BonusStatTokens.MinimumWidth = 10;
			this.BonusStatTokens.Name = "BonusStatTokens";
			this.BonusStatTokens.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BonusStatTokens.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 450);
			this.Controls.Add(this.BonusStatsTable);
			this.Controls.Add(this.MainMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "B2ProfileGUI";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BonusStatsTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip MainMenu;
		private System.Windows.Forms.ToolStripButton MainMenuOpen;
		private System.Windows.Forms.ToolStripButton MainMenuSave;
		private System.Windows.Forms.ToolStripButton MainMenuAbout;
		private System.Windows.Forms.ToolStripButton MainMenuClose;
		private System.Windows.Forms.DataGridView BonusStatsTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn BonusStatName;
		private System.Windows.Forms.DataGridViewTextBoxColumn BonusStatValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn BonusStatTokens;
	}
}

