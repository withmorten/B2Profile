using System;
using System.Windows.Forms;
using System.Drawing;
using B2Profile;

namespace B2ProfileGUI
{
	public partial class MainForm : Form
	{
		private string ProfileFilePath;

		public MainForm()
		{
			InitializeComponent();
		}

		public void TransferFromProfile()
		{
			BadassRankInput.Value = Program.Profile.GetBadassRank();
			BadassTokensEarnedInput.Value = Program.Profile.GetBadassTokensEarned();
			BadassTokensAvailableInput.Value = Program.Profile.GetBadassTokensAvailable();

			BadassTokensInvestedLabel.Text = Program.Profile.GetBadassTokensInvested().ToString();

			MaximumHealthBonusPercentInput.Value = (decimal)Program.Profile.GetMaximumHealthBonus();
			MaximumHealthBonusTokensInput.Value = Program.Profile.GetMaximumHealthTokens();

			ShieldCapacityBonusPercentInput.Value = (decimal)Program.Profile.GetShieldCapacityBonus();
			ShieldCapacityBonusTokensInput.Value = Program.Profile.GetShieldCapacityTokens();

			ShieldRechargeDelayBonusPercentInput.Value = (decimal)Program.Profile.GetShieldRechargeDelayBonus();
			ShieldRechargeDelayBonusTokensInput.Value = Program.Profile.GetShieldRechargeDelayTokens();

			ShieldRechargeRateBonusPercentInput.Value = (decimal)Program.Profile.GetShieldRechargeRateBonus();
			ShieldRechargeRateBonusTokensInput.Value = Program.Profile.GetShieldRechargeRateTokens();

			MeleeDamageBonusPercentInput.Value = (decimal)Program.Profile.GetMeleeDamageBonus();
			MeleeDamageBonusTokensInput.Value = Program.Profile.GetMeleeDamageTokens();

			GrenadeDamageBonusPercentInput.Value = (decimal)Program.Profile.GetGrenadeDamageBonus();
			GrenadeDamageBonusTokensInput.Value = Program.Profile.GetGrenadeDamageTokens();

			GunAccuracyBonusPercentInput.Value = (decimal)Program.Profile.GetGunAccuracyBonus();
			GunAccuracyBonusTokensInput.Value = Program.Profile.GetGunAccuracyTokens();

			GunDamageBonusPercentInput.Value = (decimal)Program.Profile.GetGunDamageBonus();
			GunDamageBonusTokensInput.Value = Program.Profile.GetGunDamageTokens();

			FireRateBonusPercentInput.Value = (decimal)Program.Profile.GetFireRateBonus();
			FireRateBonusTokensInput.Value = Program.Profile.GetFireRateTokens();

			RecoilReductionBonusPercentInput.Value = (decimal)Program.Profile.GetRecoilReductionBonus();
			RecoilReductionBonusTokensInput.Value = Program.Profile.GetRecoilReductionTokens();

			ReloadSpeedBonusPercentInput.Value = (decimal)Program.Profile.GetReloadSpeedBonus();
			ReloadSpeedBonusTokensInput.Value = Program.Profile.GetReloadSpeedTokens();

			ElementalEffectChanceBonusPercentInput.Value = (decimal)Program.Profile.GetElementalEffectChanceBonus();
			ElementalEffectChanceBonusTokensInput.Value = Program.Profile.GetElementalEffectChanceTokens();

			ElementalEffectDamageBonusPercentInput.Value = (decimal)Program.Profile.GetElementalEffectDamageBonus();
			ElementalEffectDamageBonusTokensInput.Value = Program.Profile.GetElementalEffectDamageTokens();

			CriticalHitDamageBonusPercentInput.Value = (decimal)Program.Profile.GetCriticalHitDamageBonus();
			CriticalHitDamageBonusTokensInput.Value = Program.Profile.GetCriticalHitDamageTokens();

			GoldenKeysPOPremierClubInput.Value = Program.Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeys();
			GoldenKeysPOPremierClubUsedInput.Value = Program.Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeysUsed();

			GoldenKeysTulipInput.Value = Program.Profile.GetGoldenKeysTulipEntry().GetNumKeys();
			GoldenKeysTulipUsedInput.Value = Program.Profile.GetGoldenKeysTulipEntry().GetNumKeysUsed();

			GoldenKeysShiftInput.Value = Program.Profile.GetGoldenKeysShiftEntry().GetNumKeys();
			GoldenKeysShiftUsedInput.Value = Program.Profile.GetGoldenKeysShiftEntry().GetNumKeysUsed();

			GoldenKeysTotalInput.Value
				= (GoldenKeysPOPremierClubInput.Value - GoldenKeysPOPremierClubUsedInput.Value)
				+ (GoldenKeysTulipInput.Value - GoldenKeysTulipUsedInput.Value)
				+ (GoldenKeysShiftInput.Value - GoldenKeysShiftUsedInput.Value);
		}

		public void TransferToProfile()
		{
			Program.Profile.SetBadassRank((int)BadassRankInput.Value);
			Program.Profile.SetBadassTokensEarned((int)BadassTokensEarnedInput.Value);
			Program.Profile.SetBadassTokensAvailable((int)BadassTokensAvailableInput.Value);

			Program.Profile.SetMaximumHealthTokens((uint)MaximumHealthBonusTokensInput.Value);
			Program.Profile.SetShieldCapacityTokens((uint)ShieldCapacityBonusTokensInput.Value);
			Program.Profile.SetShieldRechargeDelayTokens((uint)ShieldRechargeDelayBonusTokensInput.Value);
			Program.Profile.SetShieldRechargeRateTokens((uint)ShieldRechargeRateBonusTokensInput.Value);
			Program.Profile.SetMeleeDamageTokens((uint)MeleeDamageBonusTokensInput.Value);
			Program.Profile.SetGrenadeDamageTokens((uint)GrenadeDamageBonusTokensInput.Value);
			Program.Profile.SetGunAccuracyTokens((uint)GunAccuracyBonusTokensInput.Value);
			Program.Profile.SetGunDamageTokens((uint)GunDamageBonusTokensInput.Value);
			Program.Profile.SetFireRateTokens((uint)FireRateBonusTokensInput.Value);
			Program.Profile.SetRecoilReductionTokens((uint)RecoilReductionBonusTokensInput.Value);
			Program.Profile.SetReloadSpeedTokens((uint)ReloadSpeedBonusTokensInput.Value);
			Program.Profile.SetElementalEffectChanceTokens((uint)ElementalEffectChanceBonusTokensInput.Value);
			Program.Profile.SetElementalEffectDamageTokens((uint)ElementalEffectDamageBonusTokensInput.Value);
			Program.Profile.SetCriticalHitDamageTokens((uint)CriticalHitDamageBonusTokensInput.Value);

			Program.Profile.GetGoldenKeysPOPremierClubEntry().SetNumKeys((byte)GoldenKeysPOPremierClubInput.Value);
			Program.Profile.GetGoldenKeysPOPremierClubEntry().SetNumKeysUsed((byte)GoldenKeysPOPremierClubUsedInput.Value);

			Program.Profile.GetGoldenKeysTulipEntry().SetNumKeys((byte)GoldenKeysTulipInput.Value);
			Program.Profile.GetGoldenKeysTulipEntry().SetNumKeysUsed((byte)GoldenKeysTulipUsedInput.Value);

			Program.Profile.GetGoldenKeysShiftEntry().SetNumKeys((byte)GoldenKeysShiftInput.Value);
			Program.Profile.GetGoldenKeysShiftEntry().SetNumKeysUsed((byte)GoldenKeysShiftUsedInput.Value);
		}

		private void TransferIgnoresToProfile()
		{
			Program.Profile.SetIgnoreMaximumHealth(MaximumHealthIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreShieldCapacity(ShieldCapacityIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreShieldRechargeDelay(ShieldRechargeDelayIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreShieldRechargeRate(ShieldRechargeRateIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreMeleeDamage(MeleeDamageIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreGrenadeDamage(GrenadeDamageIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreGunAccuracy(GunAccuracyIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreGunDamage(GunDamageIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreFireRate(FireRateIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreRecoilReduction(RecoilReductionIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreReloadSpeed(ReloadSpeedIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreElementalEffectChance(ElementalEffectChanceIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreElementalEffectDamage(ElementalEffectDamageIgnoreCheckBox.Checked);
			Program.Profile.SetIgnoreCriticalHitDamage(CriticalHitDamageIgnoreCheckBox.Checked);
		}

		private void LoadProfile()
		{
			Program.Profile = new Profile(ProfileFilePath);

			TransferFromProfile();

			BadassRankInput.PrevValue = BadassRankInput.Value;
			BadassTokensEarnedInput.PrevValue = BadassTokensEarnedInput.Value;
			BadassTokensAvailableInput.PrevValue = BadassTokensAvailableInput.Value;

			MaximumHealthBonusTokensInput.PrevValue = MaximumHealthBonusTokensInput.Value;
			ShieldCapacityBonusTokensInput.PrevValue = ShieldCapacityBonusTokensInput.Value;
			ShieldRechargeDelayBonusTokensInput.PrevValue = ShieldRechargeDelayBonusTokensInput.Value;
			ShieldRechargeRateBonusTokensInput.PrevValue = ShieldRechargeRateBonusTokensInput.Value;
			MeleeDamageBonusTokensInput.PrevValue = MeleeDamageBonusTokensInput.Value;
			GrenadeDamageBonusTokensInput.PrevValue = GrenadeDamageBonusTokensInput.Value;
			GunAccuracyBonusTokensInput.PrevValue = GunAccuracyBonusTokensInput.Value;
			GunDamageBonusTokensInput.PrevValue = GunDamageBonusTokensInput.Value;
			FireRateBonusTokensInput.PrevValue = FireRateBonusTokensInput.Value;
			RecoilReductionBonusTokensInput.PrevValue = RecoilReductionBonusTokensInput.Value;
			ReloadSpeedBonusTokensInput.PrevValue = ReloadSpeedBonusTokensInput.Value;
			ElementalEffectChanceBonusTokensInput.PrevValue = ElementalEffectChanceBonusTokensInput.Value;
			ElementalEffectDamageBonusTokensInput.PrevValue = ElementalEffectDamageBonusTokensInput.Value;
			CriticalHitDamageBonusTokensInput.PrevValue = CriticalHitDamageBonusTokensInput.Value;

			GoldenKeysPOPremierClubInput.PrevValue = GoldenKeysPOPremierClubInput.Value;
			GoldenKeysPOPremierClubUsedInput.PrevValue = GoldenKeysPOPremierClubUsedInput.Value;

			GoldenKeysTulipInput.PrevValue = GoldenKeysTulipInput.Value;
			GoldenKeysTulipUsedInput.PrevValue = GoldenKeysTulipUsedInput.Value;

			GoldenKeysShiftInput.PrevValue = GoldenKeysShiftInput.Value;
			GoldenKeysShiftUsedInput.PrevValue = GoldenKeysShiftUsedInput.Value;
		}

		private void SaveProfile()
		{
			TransferToProfile();

			Program.Profile.Save(ProfileFilePath);

			MessageBox.Show("Profile saved!\r\n\r\nIf you want revert the changes, go to your SaveData directory and rename the profile.bin.bak generated by this tool to profile.bin!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void EnableGUI()
		{
			MainMenuSaveButton.Enabled = true;

			UnlockAllCustomizationsButton.Enabled = true;
			LockAllCustomizationsButton.Enabled = true;

			ResetBonusStatsButton.Enabled = true;
			EvenlyDistributeTokensButton.Enabled = true;

			BadassRankInput.Enabled = true;
			BadassTokensAvailableInput.Enabled = true;
			BadassTokensEarnedInput.Enabled = true;

			SyncedModeCheckBox.Enabled = true;

			BadassTokensInvestedLabel.ForeColor = SystemColors.ControlText;

			MaximumHealthBonusPercentInput.Enabled = true;
			ShieldCapacityBonusPercentInput.Enabled = true;
			ShieldRechargeDelayBonusPercentInput.Enabled = true;
			ShieldRechargeRateBonusPercentInput.Enabled = true;
			MeleeDamageBonusPercentInput.Enabled = true;
			GrenadeDamageBonusPercentInput.Enabled = true;
			GunAccuracyBonusPercentInput.Enabled = true;
			GunDamageBonusPercentInput.Enabled = true;
			FireRateBonusPercentInput.Enabled = true;
			RecoilReductionBonusPercentInput.Enabled = true;
			ReloadSpeedBonusPercentInput.Enabled = true;
			ElementalEffectChanceBonusPercentInput.Enabled = true;
			ElementalEffectDamageBonusPercentInput.Enabled = true;
			CriticalHitDamageBonusPercentInput.Enabled = true;

			MaximumHealthBonusTokensInput.Enabled = true;
			ShieldCapacityBonusTokensInput.Enabled = true;
			ShieldRechargeDelayBonusTokensInput.Enabled = true;
			ShieldRechargeRateBonusTokensInput.Enabled = true;
			MeleeDamageBonusTokensInput.Enabled = true;
			GrenadeDamageBonusTokensInput.Enabled = true;
			GunAccuracyBonusTokensInput.Enabled = true;
			GunDamageBonusTokensInput.Enabled = true;
			FireRateBonusTokensInput.Enabled = true;
			RecoilReductionBonusTokensInput.Enabled = true;
			ReloadSpeedBonusTokensInput.Enabled = true;
			ElementalEffectChanceBonusTokensInput.Enabled = true;
			ElementalEffectDamageBonusTokensInput.Enabled = true;
			CriticalHitDamageBonusTokensInput.Enabled = true;

			MaximumHealthIgnoreCheckBox.Enabled = true;
			ShieldCapacityIgnoreCheckBox.Enabled = true;
			ShieldRechargeDelayIgnoreCheckBox.Enabled = true;
			ShieldRechargeRateIgnoreCheckBox.Enabled = true;
			MeleeDamageIgnoreCheckBox.Enabled = true;
			GrenadeDamageIgnoreCheckBox.Enabled = true;
			GunAccuracyIgnoreCheckBox.Enabled = true;
			GunDamageIgnoreCheckBox.Enabled = true;
			FireRateIgnoreCheckBox.Enabled = true;
			RecoilReductionIgnoreCheckBox.Enabled = true;
			ReloadSpeedIgnoreCheckBox.Enabled = true;
			ElementalEffectChanceIgnoreCheckBox.Enabled = true;
			ElementalEffectDamageIgnoreCheckBox.Enabled = true;
			CriticalHitDamageIgnoreCheckBox.Enabled = true;

			GoldenKeysTulipInput.Enabled = true;
			GoldenKeysTulipUsedInput.Enabled = true;

			GoldenKeysShiftInput.Enabled = true;
			GoldenKeysShiftUsedInput.Enabled = true;

			GoldenKeysPOPremierClubInput.Enabled = true;
			GoldenKeysPOPremierClubUsedInput.Enabled = true;

			GoldenKeysTotalInput.Enabled = true;

			if (Program.Profile.IsClaptrapsStashSlotValid(1) == true) CopySlot1CodeButton.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(2) == true) CopySlot2CodeButton.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(3) == true) CopySlot3CodeButton.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(4) == true) CopySlot4CodeButton.Enabled = true;

			PasteSlot1CodeButton.Enabled = true;
			PasteSlot2CodeButton.Enabled = true;
			PasteSlot3CodeButton.Enabled = true;
			PasteSlot4CodeButton.Enabled = true;

			if (Program.Profile.IsClaptrapsStashSlotValid(1) == true) DeleteSlot1Button.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(2) == true) DeleteSlot2Button.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(3) == true) DeleteSlot3Button.Enabled = true;
			if (Program.Profile.IsClaptrapsStashSlotValid(4) == true) DeleteSlot4Button.Enabled = true;
		}

		public void UpdateBadassTokensInvested(decimal inc)
		{
			decimal t = Decimal.Parse(BadassTokensInvestedLabel.Text);

			t += inc;

			BadassTokensInvestedLabel.Text = t.ToString();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.O))
			{
				MainMenuOpenButton_Click(null, null);

				return true;
			}
			else if (keyData == (Keys.Control | Keys.S))
			{
				if (MainMenuSaveButton.Enabled == true)
				{
					MainMenuSaveButton_Click(null, null);

					return true;
				}

				return false;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Program.MainForm = this;
			Program.Profile = null;
			ProfileFilePath = null;

			MaximumHealthBonusPercentInput.TokenUpDown = MaximumHealthBonusTokensInput;
			MaximumHealthBonusTokensInput.PercentUpDown = MaximumHealthBonusPercentInput;

			ShieldCapacityBonusPercentInput.TokenUpDown = ShieldCapacityBonusTokensInput;
			ShieldCapacityBonusTokensInput.PercentUpDown = ShieldCapacityBonusPercentInput;

			ShieldRechargeDelayBonusPercentInput.TokenUpDown = ShieldRechargeDelayBonusTokensInput;
			ShieldRechargeDelayBonusTokensInput.PercentUpDown = ShieldRechargeDelayBonusPercentInput;

			ShieldRechargeRateBonusPercentInput.TokenUpDown = ShieldRechargeRateBonusTokensInput;
			ShieldRechargeRateBonusTokensInput.PercentUpDown = ShieldRechargeRateBonusPercentInput;

			MeleeDamageBonusPercentInput.TokenUpDown = MeleeDamageBonusTokensInput;
			MeleeDamageBonusTokensInput.PercentUpDown = MeleeDamageBonusPercentInput;

			GrenadeDamageBonusPercentInput.TokenUpDown = GrenadeDamageBonusTokensInput;
			GrenadeDamageBonusTokensInput.PercentUpDown = GrenadeDamageBonusPercentInput;

			GunAccuracyBonusPercentInput.TokenUpDown = GunAccuracyBonusTokensInput;
			GunAccuracyBonusTokensInput.PercentUpDown = GunAccuracyBonusPercentInput;

			GunDamageBonusPercentInput.TokenUpDown = GunDamageBonusTokensInput;
			GunDamageBonusTokensInput.PercentUpDown = GunDamageBonusPercentInput;

			FireRateBonusPercentInput.TokenUpDown = FireRateBonusTokensInput;
			FireRateBonusTokensInput.PercentUpDown = FireRateBonusPercentInput;

			RecoilReductionBonusPercentInput.TokenUpDown = RecoilReductionBonusTokensInput;
			RecoilReductionBonusTokensInput.PercentUpDown = RecoilReductionBonusPercentInput;

			ReloadSpeedBonusPercentInput.TokenUpDown = ReloadSpeedBonusTokensInput;
			ReloadSpeedBonusTokensInput.PercentUpDown = ReloadSpeedBonusPercentInput;

			ElementalEffectChanceBonusPercentInput.TokenUpDown = ElementalEffectChanceBonusTokensInput;
			ElementalEffectChanceBonusTokensInput.PercentUpDown = ElementalEffectChanceBonusPercentInput;

			ElementalEffectDamageBonusPercentInput.TokenUpDown = ElementalEffectDamageBonusTokensInput;
			ElementalEffectDamageBonusTokensInput.PercentUpDown = ElementalEffectDamageBonusPercentInput;

			CriticalHitDamageBonusPercentInput.TokenUpDown = CriticalHitDamageBonusTokensInput;
			CriticalHitDamageBonusTokensInput.PercentUpDown = CriticalHitDamageBonusPercentInput;

			GoldenKeysPOPremierClubInput.KeysUsedUpDown = GoldenKeysPOPremierClubUsedInput;
			GoldenKeysPOPremierClubUsedInput.KeysUpDown = GoldenKeysPOPremierClubInput;

			GoldenKeysTulipInput.KeysUsedUpDown = GoldenKeysTulipUsedInput;
			GoldenKeysTulipUsedInput.KeysUpDown = GoldenKeysTulipInput;

			GoldenKeysShiftInput.KeysUsedUpDown = GoldenKeysShiftUsedInput;
			GoldenKeysShiftUsedInput.KeysUpDown = GoldenKeysShiftInput;
	}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Program.Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					SaveProfile();

					Program.Profile = null;

					break;

				case DialogResult.No:
					Program.Profile = null;

					break;

				case DialogResult.Cancel:
					e.Cancel = true;

					break;
				}
			}
		}

		private void MainMenuOpenButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
				{
				case DialogResult.Yes:
					SaveProfile();

					Program.Profile = null;

					break;

				case DialogResult.No:
					Program.Profile = null;

					break;

				case DialogResult.Cancel:
					return;

					break;
				}
			}

			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Title = "Select BL2 profile";
			openFileDialog.Filter = "BL2 profile|*.bin";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Borderlands 2\\WillowGame\\SaveData";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ProfileFilePath = openFileDialog.FileName;

				LoadProfile();

				EnableGUI();
			}
		}

		private void MainMenuSaveButton_Click(object sender, EventArgs e)
		{
			SaveProfile();
		}

		private void MainMenuAboutButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Borderlands 2 - Profile Editor 2.0\r\nby withmorten\r\n\r\nThanks to:\r\nPhilymaster (for the original Borderlands 2 - Profile Editor)\r\nFeudalnate (for PackageIO)\r\ngibbed (for MiniLZO and his Borderlands 2 Save Editor)\r\n\r\nHover over \"Synced Mode\", the number next to it and \"Ignore\"\r\nfor additional info", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MainMenuCloseButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
				{
				case DialogResult.Yes:
					Program.Profile.Save(ProfileFilePath);

					Program.Profile = null;

					Application.Exit();

					break;

				case DialogResult.No:
					Program.Profile = null;

					Application.Exit();

					break;

				case DialogResult.Cancel:

					break;
				}
			}
			else
			{
				Application.Exit();
			}
		}

		private void UnlockAllCustomizationsButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will unlock all customizations (heads, skins),\r\noverwriting previous data, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.UnlockAllCustomizations();

				MessageBox.Show("All customizations unlocked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				break;

			case DialogResult.No:

				break;
			}
		}

		private void LockAllCustomizationsButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will lock all customizations (heads, skins),\r\noverwriting previous data, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.LockAllCustomizations();

				MessageBox.Show("All customizations locked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				break;

			case DialogResult.No:

				break;
			}
		}

		private void ResetBonusStatsButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will reset all bonus stats, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				TransferIgnoresToProfile();
				TransferToProfile();

				Program.Profile.ResetBonusStats();

				TransferFromProfile();

				break;

			case DialogResult.No:

				break;
			}
		}

		private void EvenlyDistributeTokensButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will spend all available tokens, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				TransferIgnoresToProfile();
				TransferToProfile();

				Program.Profile.EvenlyDistributeTokens();

				TransferFromProfile();

				break;

			case DialogResult.No:

				break;
			}
		}

		private void SyncedModeCheckBox_MouseHover(object sender, MouseEventArgs e)
		{
			if (SyncedModeToolTip.GetToolTip(SyncedModeCheckBox).Length == 0)
			{
				SyncedModeToolTip.SetToolTip(SyncedModeCheckBox,
					"Checking this will increase the Badass Rank automatically\r\nwhen you run out of available tokens");
			}
		}

		private void IgnoreBonusStatLabel_MouseHover(object sender, EventArgs e)
		{
			if (IgnoreBonusStatLabelToolTip.GetToolTip(IgnoreBonusStatLabel).Length == 0)
			{
				IgnoreBonusStatLabelToolTip.SetToolTip(IgnoreBonusStatLabel,
					"Checking the checkboxes below will make \r\n\"Reset Bonus Stats\" and \"Evenly Distribute Tokens\"\r\nignore the corresponding bonus stat");
			}
		}

		private void BadassTokensInvestedLabel_MouseHover(object sender, EventArgs e)
		{
			if (BadassTokensUsedToolTip.GetToolTip(BadassTokensInvestedLabel).Length == 0)
			{
				BadassTokensUsedToolTip.SetToolTip(BadassTokensInvestedLabel,
					"This shows the total number of Badass Tokens currently invested");
			}
		}

		private void CopySlot1CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(1));

			MessageBox.Show("Slot 1 gibbed code copied to clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void CopySlot2CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(2));

			MessageBox.Show("Slot 2 gibbed code copied to clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void CopySlot3CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(3));

			MessageBox.Show("Slot 3 gibbed code copied to clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void CopySlot4CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(4));

			MessageBox.Show("Slot 4 gibbed code copied to clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void PasteSlot1CodeButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will overwrite the current item in slot 1 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(1, Clipboard.GetText()) == true)
				{
					MessageBox.Show("Slot 1 gibbed code pasted from clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

					CopySlot1CodeButton.Enabled = true;
					DeleteSlot1Button.Enabled = true;
				}
				else
				{
					MessageBox.Show("Not a valid gibbed code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				break;

			case DialogResult.No:

				break;
			}
		}

		private void PasteSlot2CodeButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will overwrite the current item in slot 2 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(2, Clipboard.GetText()) == true)
				{
					MessageBox.Show("Slot 2 gibbed code pasted from clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

					CopySlot2CodeButton.Enabled = true;
					DeleteSlot2Button.Enabled = true;
				}
				else
				{
					MessageBox.Show("Not a valid gibbed code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				break;

			case DialogResult.No:

				break;
			}
		}

		private void PasteSlot3CodeButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will overwrite the current item in slot 3 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(3, Clipboard.GetText()) == true)
				{
					MessageBox.Show("Slot 3 gibbed code pasted from clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

					CopySlot3CodeButton.Enabled = true;
					DeleteSlot3Button.Enabled = true;
				}
				else
				{
					MessageBox.Show("Not a valid gibbed code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				break;

			case DialogResult.No:

				break;
			}
		}

		private void PasteSlot4CodeButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will overwrite the current item in slot 4 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(4, Clipboard.GetText()) == true)
				{
					MessageBox.Show("Slot 4 gibbed code pasted from clipboard!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

					CopySlot4CodeButton.Enabled = true;
					DeleteSlot4Button.Enabled = true;
				}
				else
				{
					MessageBox.Show("Not a valid gibbed code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				break;

			case DialogResult.No:

				break;
			}
		}

		private void DeleteSlot1Button_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will delete the current item in slot 1, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.DeleteClaptrapsStashSlot(1);

				MessageBox.Show("Slot 1 deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CopySlot1CodeButton.Enabled = false;
				DeleteSlot1Button.Enabled = false;

				break;

			case DialogResult.No:

				break;
			}
		}

		private void DeleteSlot2Button_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will delete the current item in slot 2, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.DeleteClaptrapsStashSlot(2);

				MessageBox.Show("Slot 2 deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CopySlot2CodeButton.Enabled = false;
				DeleteSlot2Button.Enabled = false;

				break;

			case DialogResult.No:

				break;
			}
		}

		private void DeleteSlot3Button_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will delete the current item in slot 3, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.DeleteClaptrapsStashSlot(3);

				MessageBox.Show("Slot 3 deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CopySlot3CodeButton.Enabled = false;
				DeleteSlot3Button.Enabled = false;

				break;

			case DialogResult.No:

				break;
			}
		}

		private void DeleteSlot4Button_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will delete the current item in slot 4, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				Program.Profile.DeleteClaptrapsStashSlot(4);

				MessageBox.Show("Slot 4 deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

				CopySlot4CodeButton.Enabled = false;
				DeleteSlot4Button.Enabled = false;

				break;

			case DialogResult.No:

				break;
			}
		}
	}
}
