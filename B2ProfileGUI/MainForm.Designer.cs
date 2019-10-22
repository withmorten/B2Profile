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
			this.MainMenuStrip = new System.Windows.Forms.ToolStrip();
			this.MainMenuOpenButton = new System.Windows.Forms.ToolStripButton();
			this.MainMenuSaveButton = new System.Windows.Forms.ToolStripButton();
			this.MainMenuAboutButton = new System.Windows.Forms.ToolStripButton();
			this.MainMenuCloseButton = new System.Windows.Forms.ToolStripButton();
			this.BadassRankLabel = new System.Windows.Forms.Label();
			this.BadassRankInput = new System.Windows.Forms.NumericUpDown();
			this.BadassTokensLabel = new System.Windows.Forms.Label();
			this.BadassTokensInput = new System.Windows.Forms.NumericUpDown();
			this.BadassTokensEarnedLabel = new System.Windows.Forms.Label();
			this.BadassTokensEarnedInput = new System.Windows.Forms.NumericUpDown();
			this.MaximumHealthLabel = new System.Windows.Forms.Label();
			this.ShieldCapacityLabel = new System.Windows.Forms.Label();
			this.ShieldRechargeDelayLabel = new System.Windows.Forms.Label();
			this.ShieldRechargeRateLabel = new System.Windows.Forms.Label();
			this.MeleeDamageLabel = new System.Windows.Forms.Label();
			this.GrenadeDamageLabel = new System.Windows.Forms.Label();
			this.GunAccuracyLabel = new System.Windows.Forms.Label();
			this.GunDamageLabel = new System.Windows.Forms.Label();
			this.FireRateLabel = new System.Windows.Forms.Label();
			this.RecoilReductionLabel = new System.Windows.Forms.Label();
			this.ReloadSpeedLabel = new System.Windows.Forms.Label();
			this.ElementalEffectChanceLabel = new System.Windows.Forms.Label();
			this.ElementalEffectDamageLabel = new System.Windows.Forms.Label();
			this.CriticalHitDamageLabel = new System.Windows.Forms.Label();
			this.BonusPercentLabel = new System.Windows.Forms.Label();
			this.BonusTokensLabel = new System.Windows.Forms.Label();
			this.BonusStatLabel = new System.Windows.Forms.Label();
			this.MaximumHealthBonusPercent = new System.Windows.Forms.NumericUpDown();
			this.MaximumHealthBonusTokensInput = new System.Windows.Forms.NumericUpDown();
			this.MainMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BadassRankInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BadassTokensInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BadassTokensEarnedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumHealthBonusPercent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumHealthBonusTokensInput)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenuStrip
			// 
			this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuOpenButton,
            this.MainMenuSaveButton,
            this.MainMenuAboutButton,
            this.MainMenuCloseButton});
			this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainMenuStrip.Name = "MainMenuStrip";
			this.MainMenuStrip.Size = new System.Drawing.Size(584, 25);
			this.MainMenuStrip.TabIndex = 0;
			this.MainMenuStrip.Text = "Main Menu";
			// 
			// MainMenuOpenButton
			// 
			this.MainMenuOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuOpenButton.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Open;
			this.MainMenuOpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuOpenButton.Name = "MainMenuOpenButton";
			this.MainMenuOpenButton.Size = new System.Drawing.Size(23, 22);
			this.MainMenuOpenButton.Text = "Open";
			// 
			// MainMenuSaveButton
			// 
			this.MainMenuSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuSaveButton.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Save;
			this.MainMenuSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuSaveButton.Name = "MainMenuSaveButton";
			this.MainMenuSaveButton.Size = new System.Drawing.Size(23, 22);
			this.MainMenuSaveButton.Text = "Save";
			// 
			// MainMenuAboutButton
			// 
			this.MainMenuAboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuAboutButton.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_About;
			this.MainMenuAboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuAboutButton.Name = "MainMenuAboutButton";
			this.MainMenuAboutButton.Size = new System.Drawing.Size(23, 22);
			this.MainMenuAboutButton.Text = "About";
			// 
			// MainMenuCloseButton
			// 
			this.MainMenuCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainMenuCloseButton.Image = global::B2ProfileGUI.Properties.Resources.MainMenu_Close;
			this.MainMenuCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainMenuCloseButton.Name = "MainMenuCloseButton";
			this.MainMenuCloseButton.Size = new System.Drawing.Size(23, 22);
			this.MainMenuCloseButton.Text = "Close";
			// 
			// BadassRankLabel
			// 
			this.BadassRankLabel.AutoSize = true;
			this.BadassRankLabel.Location = new System.Drawing.Point(12, 31);
			this.BadassRankLabel.Name = "BadassRankLabel";
			this.BadassRankLabel.Size = new System.Drawing.Size(74, 13);
			this.BadassRankLabel.TabIndex = 1;
			this.BadassRankLabel.Text = "Badass Rank:";
			// 
			// BadassRankInput
			// 
			this.BadassRankInput.Location = new System.Drawing.Point(148, 31);
			this.BadassRankInput.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
			this.BadassRankInput.Name = "BadassRankInput";
			this.BadassRankInput.Size = new System.Drawing.Size(81, 20);
			this.BadassRankInput.TabIndex = 2;
			this.BadassRankInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// BadassTokensLabel
			// 
			this.BadassTokensLabel.AutoSize = true;
			this.BadassTokensLabel.Location = new System.Drawing.Point(249, 66);
			this.BadassTokensLabel.Name = "BadassTokensLabel";
			this.BadassTokensLabel.Size = new System.Drawing.Size(130, 13);
			this.BadassTokensLabel.TabIndex = 3;
			this.BadassTokensLabel.Text = "Available Badass Tokens:";
			// 
			// BadassTokensInput
			// 
			this.BadassTokensInput.Location = new System.Drawing.Point(392, 64);
			this.BadassTokensInput.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
			this.BadassTokensInput.Name = "BadassTokensInput";
			this.BadassTokensInput.Size = new System.Drawing.Size(81, 20);
			this.BadassTokensInput.TabIndex = 6;
			this.BadassTokensInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// BadassTokensEarnedLabel
			// 
			this.BadassTokensEarnedLabel.AutoSize = true;
			this.BadassTokensEarnedLabel.Location = new System.Drawing.Point(12, 66);
			this.BadassTokensEarnedLabel.Name = "BadassTokensEarnedLabel";
			this.BadassTokensEarnedLabel.Size = new System.Drawing.Size(121, 13);
			this.BadassTokensEarnedLabel.TabIndex = 5;
			this.BadassTokensEarnedLabel.Text = "Earned Badass Tokens:";
			// 
			// BadassTokensEarnedInput
			// 
			this.BadassTokensEarnedInput.Location = new System.Drawing.Point(148, 64);
			this.BadassTokensEarnedInput.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
			this.BadassTokensEarnedInput.Name = "BadassTokensEarnedInput";
			this.BadassTokensEarnedInput.Size = new System.Drawing.Size(81, 20);
			this.BadassTokensEarnedInput.TabIndex = 4;
			this.BadassTokensEarnedInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MaximumHealthLabel
			// 
			this.MaximumHealthLabel.AutoSize = true;
			this.MaximumHealthLabel.Location = new System.Drawing.Point(12, 139);
			this.MaximumHealthLabel.Name = "MaximumHealthLabel";
			this.MaximumHealthLabel.Size = new System.Drawing.Size(88, 13);
			this.MaximumHealthLabel.TabIndex = 7;
			this.MaximumHealthLabel.Text = "Maximum Health:";
			// 
			// ShieldCapacityLabel
			// 
			this.ShieldCapacityLabel.AutoSize = true;
			this.ShieldCapacityLabel.Location = new System.Drawing.Point(12, 166);
			this.ShieldCapacityLabel.Name = "ShieldCapacityLabel";
			this.ShieldCapacityLabel.Size = new System.Drawing.Size(83, 13);
			this.ShieldCapacityLabel.TabIndex = 8;
			this.ShieldCapacityLabel.Text = "Shield Capacity:";
			// 
			// ShieldRechargeDelayLabel
			// 
			this.ShieldRechargeDelayLabel.AutoSize = true;
			this.ShieldRechargeDelayLabel.Location = new System.Drawing.Point(12, 193);
			this.ShieldRechargeDelayLabel.Name = "ShieldRechargeDelayLabel";
			this.ShieldRechargeDelayLabel.Size = new System.Drawing.Size(119, 13);
			this.ShieldRechargeDelayLabel.TabIndex = 9;
			this.ShieldRechargeDelayLabel.Text = "Shield Recharge Delay:";
			// 
			// ShieldRechargeRateLabel
			// 
			this.ShieldRechargeRateLabel.AutoSize = true;
			this.ShieldRechargeRateLabel.Location = new System.Drawing.Point(12, 220);
			this.ShieldRechargeRateLabel.Name = "ShieldRechargeRateLabel";
			this.ShieldRechargeRateLabel.Size = new System.Drawing.Size(115, 13);
			this.ShieldRechargeRateLabel.TabIndex = 10;
			this.ShieldRechargeRateLabel.Text = "Shield Recharge Rate:";
			// 
			// MeleeDamageLabel
			// 
			this.MeleeDamageLabel.AutoSize = true;
			this.MeleeDamageLabel.Location = new System.Drawing.Point(12, 247);
			this.MeleeDamageLabel.Name = "MeleeDamageLabel";
			this.MeleeDamageLabel.Size = new System.Drawing.Size(82, 13);
			this.MeleeDamageLabel.TabIndex = 11;
			this.MeleeDamageLabel.Text = "Melee Damage:";
			// 
			// GrenadeDamageLabel
			// 
			this.GrenadeDamageLabel.AutoSize = true;
			this.GrenadeDamageLabel.Location = new System.Drawing.Point(12, 274);
			this.GrenadeDamageLabel.Name = "GrenadeDamageLabel";
			this.GrenadeDamageLabel.Size = new System.Drawing.Size(94, 13);
			this.GrenadeDamageLabel.TabIndex = 12;
			this.GrenadeDamageLabel.Text = "Grenade Damage:";
			// 
			// GunAccuracyLabel
			// 
			this.GunAccuracyLabel.AutoSize = true;
			this.GunAccuracyLabel.Location = new System.Drawing.Point(12, 301);
			this.GunAccuracyLabel.Name = "GunAccuracyLabel";
			this.GunAccuracyLabel.Size = new System.Drawing.Size(78, 13);
			this.GunAccuracyLabel.TabIndex = 13;
			this.GunAccuracyLabel.Text = "Gun Accuracy:";
			// 
			// GunDamageLabel
			// 
			this.GunDamageLabel.AutoSize = true;
			this.GunDamageLabel.Location = new System.Drawing.Point(12, 328);
			this.GunDamageLabel.Name = "GunDamageLabel";
			this.GunDamageLabel.Size = new System.Drawing.Size(73, 13);
			this.GunDamageLabel.TabIndex = 14;
			this.GunDamageLabel.Text = "Gun Damage:";
			// 
			// FireRateLabel
			// 
			this.FireRateLabel.AutoSize = true;
			this.FireRateLabel.Location = new System.Drawing.Point(12, 355);
			this.FireRateLabel.Name = "FireRateLabel";
			this.FireRateLabel.Size = new System.Drawing.Size(53, 13);
			this.FireRateLabel.TabIndex = 15;
			this.FireRateLabel.Text = "Fire Rate:";
			// 
			// RecoilReductionLabel
			// 
			this.RecoilReductionLabel.AutoSize = true;
			this.RecoilReductionLabel.Location = new System.Drawing.Point(12, 382);
			this.RecoilReductionLabel.Name = "RecoilReductionLabel";
			this.RecoilReductionLabel.Size = new System.Drawing.Size(92, 13);
			this.RecoilReductionLabel.TabIndex = 16;
			this.RecoilReductionLabel.Text = "Recoil Reduction:";
			// 
			// ReloadSpeedLabel
			// 
			this.ReloadSpeedLabel.AutoSize = true;
			this.ReloadSpeedLabel.Location = new System.Drawing.Point(12, 409);
			this.ReloadSpeedLabel.Name = "ReloadSpeedLabel";
			this.ReloadSpeedLabel.Size = new System.Drawing.Size(78, 13);
			this.ReloadSpeedLabel.TabIndex = 17;
			this.ReloadSpeedLabel.Text = "Reload Speed:";
			// 
			// ElementalEffectChanceLabel
			// 
			this.ElementalEffectChanceLabel.AutoSize = true;
			this.ElementalEffectChanceLabel.Location = new System.Drawing.Point(12, 436);
			this.ElementalEffectChanceLabel.Name = "ElementalEffectChanceLabel";
			this.ElementalEffectChanceLabel.Size = new System.Drawing.Size(127, 13);
			this.ElementalEffectChanceLabel.TabIndex = 0;
			this.ElementalEffectChanceLabel.Text = "Elemental Effect Chance:";
			// 
			// ElementalEffectDamageLabel
			// 
			this.ElementalEffectDamageLabel.AutoSize = true;
			this.ElementalEffectDamageLabel.Location = new System.Drawing.Point(12, 463);
			this.ElementalEffectDamageLabel.Name = "ElementalEffectDamageLabel";
			this.ElementalEffectDamageLabel.Size = new System.Drawing.Size(130, 13);
			this.ElementalEffectDamageLabel.TabIndex = 18;
			this.ElementalEffectDamageLabel.Text = "Elemental Effect Damage:";
			// 
			// CriticalHitDamageLabel
			// 
			this.CriticalHitDamageLabel.AutoSize = true;
			this.CriticalHitDamageLabel.Location = new System.Drawing.Point(12, 490);
			this.CriticalHitDamageLabel.Name = "CriticalHitDamageLabel";
			this.CriticalHitDamageLabel.Size = new System.Drawing.Size(100, 13);
			this.CriticalHitDamageLabel.TabIndex = 19;
			this.CriticalHitDamageLabel.Text = "Critical Hit Damage:";
			// 
			// BonusPercentLabel
			// 
			this.BonusPercentLabel.AutoSize = true;
			this.BonusPercentLabel.Location = new System.Drawing.Point(175, 104);
			this.BonusPercentLabel.Name = "BonusPercentLabel";
			this.BonusPercentLabel.Size = new System.Drawing.Size(77, 13);
			this.BonusPercentLabel.TabIndex = 20;
			this.BonusPercentLabel.Text = "Bonus Percent";
			// 
			// BonusTokensLabel
			// 
			this.BonusTokensLabel.AutoSize = true;
			this.BonusTokensLabel.Location = new System.Drawing.Point(303, 104);
			this.BonusTokensLabel.Name = "BonusTokensLabel";
			this.BonusTokensLabel.Size = new System.Drawing.Size(76, 13);
			this.BonusTokensLabel.TabIndex = 21;
			this.BonusTokensLabel.Text = "Bonus Tokens";
			// 
			// BonusStatLabel
			// 
			this.BonusStatLabel.AutoSize = true;
			this.BonusStatLabel.Location = new System.Drawing.Point(12, 104);
			this.BonusStatLabel.Name = "BonusStatLabel";
			this.BonusStatLabel.Size = new System.Drawing.Size(59, 13);
			this.BonusStatLabel.TabIndex = 22;
			this.BonusStatLabel.Text = "Bonus Stat";
			// 
			// MaximumHealthBonusPercent
			// 
			this.MaximumHealthBonusPercent.DecimalPlaces = 1;
			this.MaximumHealthBonusPercent.Enabled = false;
			this.MaximumHealthBonusPercent.Location = new System.Drawing.Point(174, 137);
			this.MaximumHealthBonusPercent.Maximum = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
			this.MaximumHealthBonusPercent.Name = "MaximumHealthBonusPercent";
			this.MaximumHealthBonusPercent.ReadOnly = true;
			this.MaximumHealthBonusPercent.Size = new System.Drawing.Size(81, 20);
			this.MaximumHealthBonusPercent.TabIndex = 23;
			this.MaximumHealthBonusPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MaximumHealthBonusTokensInput
			// 
			this.MaximumHealthBonusTokensInput.Location = new System.Drawing.Point(302, 137);
			this.MaximumHealthBonusTokensInput.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
			this.MaximumHealthBonusTokensInput.Name = "MaximumHealthBonusTokensInput";
			this.MaximumHealthBonusTokensInput.Size = new System.Drawing.Size(81, 20);
			this.MaximumHealthBonusTokensInput.TabIndex = 24;
			this.MaximumHealthBonusTokensInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 536);
			this.Controls.Add(this.MaximumHealthBonusTokensInput);
			this.Controls.Add(this.MaximumHealthBonusPercent);
			this.Controls.Add(this.BonusStatLabel);
			this.Controls.Add(this.BonusTokensLabel);
			this.Controls.Add(this.BonusPercentLabel);
			this.Controls.Add(this.CriticalHitDamageLabel);
			this.Controls.Add(this.ElementalEffectDamageLabel);
			this.Controls.Add(this.ElementalEffectChanceLabel);
			this.Controls.Add(this.ReloadSpeedLabel);
			this.Controls.Add(this.RecoilReductionLabel);
			this.Controls.Add(this.FireRateLabel);
			this.Controls.Add(this.GunDamageLabel);
			this.Controls.Add(this.GunAccuracyLabel);
			this.Controls.Add(this.GrenadeDamageLabel);
			this.Controls.Add(this.MeleeDamageLabel);
			this.Controls.Add(this.ShieldRechargeRateLabel);
			this.Controls.Add(this.ShieldRechargeDelayLabel);
			this.Controls.Add(this.ShieldCapacityLabel);
			this.Controls.Add(this.MaximumHealthLabel);
			this.Controls.Add(this.BadassTokensEarnedInput);
			this.Controls.Add(this.BadassTokensEarnedLabel);
			this.Controls.Add(this.BadassTokensInput);
			this.Controls.Add(this.BadassTokensLabel);
			this.Controls.Add(this.BadassRankInput);
			this.Controls.Add(this.BadassRankLabel);
			this.Controls.Add(this.MainMenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "B2ProfileGUI";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BadassRankInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BadassTokensInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BadassTokensEarnedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumHealthBonusPercent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumHealthBonusTokensInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip MainMenuStrip;
		private System.Windows.Forms.ToolStripButton MainMenuOpenButton;
		private System.Windows.Forms.ToolStripButton MainMenuSaveButton;
		private System.Windows.Forms.ToolStripButton MainMenuAboutButton;
		private System.Windows.Forms.ToolStripButton MainMenuCloseButton;
		private System.Windows.Forms.Label BadassRankLabel;
		private System.Windows.Forms.NumericUpDown BadassRankInput;
		private System.Windows.Forms.Label BadassTokensLabel;
		private System.Windows.Forms.NumericUpDown BadassTokensInput;
		private System.Windows.Forms.Label BadassTokensEarnedLabel;
		private System.Windows.Forms.NumericUpDown BadassTokensEarnedInput;
		private System.Windows.Forms.Label MaximumHealthLabel;
		private System.Windows.Forms.Label ShieldCapacityLabel;
		private System.Windows.Forms.Label ShieldRechargeDelayLabel;
		private System.Windows.Forms.Label ShieldRechargeRateLabel;
		private System.Windows.Forms.Label MeleeDamageLabel;
		private System.Windows.Forms.Label GrenadeDamageLabel;
		private System.Windows.Forms.Label GunAccuracyLabel;
		private System.Windows.Forms.Label GunDamageLabel;
		private System.Windows.Forms.Label FireRateLabel;
		private System.Windows.Forms.Label RecoilReductionLabel;
		private System.Windows.Forms.Label ReloadSpeedLabel;
		private System.Windows.Forms.Label ElementalEffectChanceLabel;
		private System.Windows.Forms.Label ElementalEffectDamageLabel;
		private System.Windows.Forms.Label CriticalHitDamageLabel;
		private System.Windows.Forms.Label BonusPercentLabel;
		private System.Windows.Forms.Label BonusTokensLabel;
		private System.Windows.Forms.Label BonusStatLabel;
		private System.Windows.Forms.NumericUpDown MaximumHealthBonusPercent;
		private System.Windows.Forms.NumericUpDown MaximumHealthBonusTokensInput;
	}
}

