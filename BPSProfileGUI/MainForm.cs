using System;
using System.Windows.Forms;
using System.Drawing;
using B2Profile;

namespace BPSProfileGUI
{
	public partial class MainForm : Form
	{
		private string ProfileFilePath;
		public bool ProfileDirty;

		public MainForm()
		{
			InitializeComponent();
		}

		public void TransferFromProfile()
		{
			BadassRankInput.Value = Program.Profile.BadassRank;
			BadassTokensEarnedInput.Value = Program.Profile.BadassTokensEarned;
			BadassTokensAvailableInput.Value = Program.Profile.BadassTokensAvailable;

			BadassTokensInvestedLabel.Text = Program.Profile.GetBadassTokensInvested().ToString();

			MaximumHealthBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.MaximumHealth]];
			ShieldCapacityBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ShieldCapacity]];
			ShieldRechargeDelayBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeDelay]];
			ShieldRechargeRateBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeRate]];
			MeleeDamageBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.MeleeDamage]];
			GrenadeDamageBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.GrenadeDamage]];
			GunAccuracyBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.GunAccuracy]];
			GunDamageBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.GunDamage]];
			FireRateBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.FireRate]];
			RecoilReductionBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.RecoilReduction]];
			ReloadSpeedBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ReloadSpeed]];
			ElementalEffectChanceBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectChance]];
			ElementalEffectDamageBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectDamage]];
			CriticalHitDamageBonusPercentInput.Value = (decimal)Profile.BonusPercentLUT[Program.Profile.BonusStats[Profile.BonusStatID.CriticalHitDamage]];

			MaximumHealthBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.MaximumHealth];
			ShieldCapacityBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ShieldCapacity];
			ShieldRechargeDelayBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeDelay];
			ShieldRechargeRateBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeRate];
			MeleeDamageBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.MeleeDamage];
			GrenadeDamageBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.GrenadeDamage];
			GunAccuracyBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.GunAccuracy];
			GunDamageBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.GunDamage];
			FireRateBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.FireRate];
			RecoilReductionBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.RecoilReduction];
			ReloadSpeedBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ReloadSpeed];
			ElementalEffectChanceBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectChance];
			ElementalEffectDamageBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectDamage];
			CriticalHitDamageBonusTokensInput.Value = Program.Profile.BonusStats[Profile.BonusStatID.CriticalHitDamage];

			GoldenKeysPOPremierClubInput.Value = Program.Profile.GoldenKeysPOPremierClub.GetNumKeys();
			GoldenKeysPOPremierClubUsedInput.Value = Program.Profile.GoldenKeysPOPremierClub.GetNumKeysUsed();

			GoldenKeysTulipInput.Value = Program.Profile.GoldenKeysTulip.GetNumKeys();
			GoldenKeysTulipUsedInput.Value = Program.Profile.GoldenKeysTulip.GetNumKeysUsed();

			GoldenKeysShiftInput.Value = Program.Profile.GoldenKeysShift.GetNumKeys();
			GoldenKeysShiftUsedInput.Value = Program.Profile.GoldenKeysShift.GetNumKeysUsed();

			GoldenKeysTotalInput.Value
				= (GoldenKeysPOPremierClubInput.Value - GoldenKeysPOPremierClubUsedInput.Value)
				+ (GoldenKeysTulipInput.Value - GoldenKeysTulipUsedInput.Value)
				+ (GoldenKeysShiftInput.Value - GoldenKeysShiftUsedInput.Value);

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

		public void TransferToProfile()
		{
			Program.Profile.BadassRank = (int)BadassRankInput.Value;
			Program.Profile.BadassTokensEarned = (int)BadassTokensEarnedInput.Value;
			Program.Profile.BadassTokensAvailable = (int)BadassTokensAvailableInput.Value;

			Program.Profile.BonusStats[Profile.BonusStatID.MaximumHealth] = (uint)MaximumHealthBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ShieldCapacity] = (uint)ShieldCapacityBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeDelay] = (uint)ShieldRechargeDelayBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ShieldRechargeRate] = (uint)ShieldRechargeRateBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.MeleeDamage] = (uint)MeleeDamageBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.GrenadeDamage] = (uint)GrenadeDamageBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.GunAccuracy] = (uint)GunAccuracyBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.GunDamage] = (uint)GunDamageBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.FireRate] = (uint)FireRateBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.RecoilReduction] = (uint)RecoilReductionBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ReloadSpeed] = (uint)ReloadSpeedBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectChance] = (uint)ElementalEffectChanceBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.ElementalEffectDamage] = (uint)ElementalEffectDamageBonusTokensInput.Value;
			Program.Profile.BonusStats[Profile.BonusStatID.CriticalHitDamage] = (uint)CriticalHitDamageBonusTokensInput.Value;

			Program.Profile.GoldenKeysPOPremierClub.SetNumKeys((byte)GoldenKeysPOPremierClubInput.Value);
			Program.Profile.GoldenKeysPOPremierClub.SetNumKeysUsed((byte)GoldenKeysPOPremierClubUsedInput.Value);

			Program.Profile.GoldenKeysTulip.SetNumKeys((byte)GoldenKeysTulipInput.Value);
			Program.Profile.GoldenKeysTulip.SetNumKeysUsed((byte)GoldenKeysTulipUsedInput.Value);

			Program.Profile.GoldenKeysShift.SetNumKeys((byte)GoldenKeysShiftInput.Value);
			Program.Profile.GoldenKeysShift.SetNumKeysUsed((byte)GoldenKeysShiftUsedInput.Value);
		}

		private void TransferIgnoresToProfile()
		{
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.MaximumHealth] = MaximumHealthIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ShieldCapacity] = ShieldCapacityIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ShieldRechargeDelay] = ShieldRechargeDelayIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ShieldRechargeRate] = ShieldRechargeRateIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.MeleeDamage] = MeleeDamageIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.GrenadeDamage] = GrenadeDamageIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.GunAccuracy] = GunAccuracyIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.GunDamage] = GunDamageIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.FireRate] = FireRateIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.RecoilReduction] = RecoilReductionIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ReloadSpeed] = ReloadSpeedIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ElementalEffectChance] = ElementalEffectChanceIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.ElementalEffectDamage] = ElementalEffectDamageIgnoreCheckBox.Checked;
			Program.Profile.IgnoreBonusStats[Profile.BonusStatID.CriticalHitDamage] = CriticalHitDamageIgnoreCheckBox.Checked;
		}

		private void LoadProfile()
		{
			Program.Profile = new Profile(ProfileFilePath);

			Program.Profile.IsPreSequel = true;

			TransferFromProfile();
		}

		private void SaveProfile()
		{
			TransferToProfile();

			Program.Profile.Save(ProfileFilePath);

			ProfileDirty = false;

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

			MaxGoldenKeysButton.Enabled = true;

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
			ProfileDirty = false;

			Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
			Text = "Borderlands: The Pre-Sequel Profile Editor";

			BadassRankInput.Maximum = Profile.BadassRankLUT[Profile.MaxBadassTokens];
			BadassTokensAvailableInput.Maximum = Profile.MaxBadassTokens;
			BadassTokensEarnedInput.Maximum = Profile.MaxBadassTokens;

			MaximumHealthBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ShieldCapacityBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ShieldRechargeDelayBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ShieldRechargeRateBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			MeleeDamageBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			GrenadeDamageBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			GunAccuracyBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			GunDamageBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			FireRateBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			RecoilReductionBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ReloadSpeedBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ElementalEffectChanceBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			ElementalEffectDamageBonusTokensInput.Maximum = Profile.MaxBadassTokens;
			CriticalHitDamageBonusTokensInput.Maximum = Profile.MaxBadassTokens;

			decimal percentMaximum = (decimal)Profile.BonusPercentLUT[Profile.MaxBadassTokens];

			MaximumHealthBonusPercentInput.Maximum = percentMaximum;
			ShieldCapacityBonusPercentInput.Maximum = percentMaximum;
			ShieldRechargeDelayBonusPercentInput.Maximum = percentMaximum;
			ShieldRechargeRateBonusPercentInput.Maximum = percentMaximum;
			MeleeDamageBonusPercentInput.Maximum = percentMaximum;
			GrenadeDamageBonusPercentInput.Maximum = percentMaximum;
			GunAccuracyBonusPercentInput.Maximum = percentMaximum;
			GunDamageBonusPercentInput.Maximum = percentMaximum;
			FireRateBonusPercentInput.Maximum = percentMaximum;
			RecoilReductionBonusPercentInput.Maximum = percentMaximum;
			ReloadSpeedBonusPercentInput.Maximum = percentMaximum;
			ElementalEffectChanceBonusPercentInput.Maximum = percentMaximum;
			ElementalEffectDamageBonusPercentInput.Maximum = percentMaximum;
			CriticalHitDamageBonusPercentInput.Maximum = percentMaximum;

			GoldenKeysTotalInput.Maximum = Profile.MaxGoldenKeysTotal;

			GoldenKeysPOPremierClubInput.Maximum = Profile.MaxGoldenKeys;
			GoldenKeysPOPremierClubUsedInput.Maximum = Profile.MaxGoldenKeys;

			GoldenKeysTulipInput.Maximum = Profile.MaxGoldenKeys;
			GoldenKeysTulipUsedInput.Maximum = Profile.MaxGoldenKeys;

			GoldenKeysShiftInput.Maximum = Profile.MaxGoldenKeys;
			GoldenKeysShiftUsedInput.Maximum = Profile.MaxGoldenKeys;

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
			if (Program.Profile != null && ProfileDirty == true)
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
			if (Program.Profile != null && ProfileDirty == true)
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

			openFileDialog.Title = "Select Borderlands: The Pre-Sequel profile";
			openFileDialog.Filter = "profile|*.bin";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Borderlands The Pre-Sequel\\WillowGame\\SaveData";

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
			MessageBox.Show(Text + "\r\nby withmorten\r\n\r\nThanks to:\r\nPhilymaster (for the original Borderlands 2 Profile Editor)\r\nFeudalnate (for PackageIO)\r\ngibbed (for MiniLZO and his Borderlands: The Pre-Sequel Save Editor)\r\n\r\nHover over \"Synced Mode\", the number next to it and \"Ignore\"\r\nfor additional info", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MainMenuCloseButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile != null && ProfileDirty == true)
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

				ProfileDirty = true;

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

				ProfileDirty = true;

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

				ProfileDirty = true;

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

				ProfileDirty = true;

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

			ClaptrapsStashNotifyLabel.Text = "Slot 1 gibbed code copied!";
		}

		private void CopySlot2CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(2));

			ClaptrapsStashNotifyLabel.Text = "Slot 2 gibbed code copied!";
		}

		private void CopySlot3CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(3));

			ClaptrapsStashNotifyLabel.Text = "Slot 3 gibbed code copied!";
		}

		private void CopySlot4CodeButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Program.Profile.GetClaptrapsStashSlotGibbedCode(4));

			ClaptrapsStashNotifyLabel.Text = "Slot 4 gibbed code copied!";
		}

		private void PasteSlot1CodeButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile.IsClaptrapsStashSlotValid(1) == false ||
				MessageBox.Show("This will overwrite the current item in slot 1 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(1, Clipboard.GetText()) == true)
				{
					ProfileDirty = true;

					ClaptrapsStashNotifyLabel.Text = "Slot 1 gibbed code pasted!";

					CopySlot1CodeButton.Enabled = true;
					DeleteSlot1Button.Enabled = true;
				}
				else
				{
					ClaptrapsStashNotifyLabel.Text = "Not a valid gibbed code!";
				}
			}
		}

		private void PasteSlot2CodeButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile.IsClaptrapsStashSlotValid(2) == false ||
				MessageBox.Show("This will overwrite the current item in slot 2 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(2, Clipboard.GetText()) == true)
				{
					ProfileDirty = true;

					ClaptrapsStashNotifyLabel.Text = "Slot 2 gibbed code pasted!";

					CopySlot2CodeButton.Enabled = true;
					DeleteSlot2Button.Enabled = true;
				}
				else
				{
					ClaptrapsStashNotifyLabel.Text = "Not a valid gibbed code!";
				}
			}
		}

		private void PasteSlot3CodeButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile.IsClaptrapsStashSlotValid(3) == false ||
				MessageBox.Show("This will overwrite the current item in slot 3 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(3, Clipboard.GetText()) == true)
				{
					ProfileDirty = true;

					ClaptrapsStashNotifyLabel.Text = "Slot 3 gibbed code pasted!";

					CopySlot3CodeButton.Enabled = true;
					DeleteSlot3Button.Enabled = true;
				}
				else
				{
					ClaptrapsStashNotifyLabel.Text = "Not a valid gibbed code!";
				}
			}
		}

		private void PasteSlot4CodeButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile.IsClaptrapsStashSlotValid(4) == false ||
				MessageBox.Show("This will overwrite the current item in slot 4 with the code in the clipboard, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (Program.Profile.SetClaptrapsStashSlotGibbedCode(4, Clipboard.GetText()) == true)
				{
					ProfileDirty = true;

					ClaptrapsStashNotifyLabel.Text = "Slot 4 gibbed code pasted!";

					CopySlot4CodeButton.Enabled = true;
					DeleteSlot4Button.Enabled = true;
				}
				else
				{
					ClaptrapsStashNotifyLabel.Text = "Not a valid gibbed code!";
				}
			}
		}

		private void DeleteSlot1Button_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will delete the current item in slot 1, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				Program.Profile.DeleteClaptrapsStashSlot(1);

				ProfileDirty = true;

				ClaptrapsStashNotifyLabel.Text = "Slot 1 deleted!";

				CopySlot1CodeButton.Enabled = false;
				DeleteSlot1Button.Enabled = false;
			}
		}

		private void DeleteSlot2Button_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will delete the current item in slot 2, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				Program.Profile.DeleteClaptrapsStashSlot(2);

				ProfileDirty = true;

				ClaptrapsStashNotifyLabel.Text = "Slot 2 deleted!";

				CopySlot2CodeButton.Enabled = false;
				DeleteSlot2Button.Enabled = false;
			}
		}

		private void DeleteSlot3Button_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will delete the current item in slot 3, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				Program.Profile.DeleteClaptrapsStashSlot(3);

				ProfileDirty = true;

				ClaptrapsStashNotifyLabel.Text = "Slot 3 deleted!";

				CopySlot3CodeButton.Enabled = false;
				DeleteSlot3Button.Enabled = false;
			}
		}

		private void DeleteSlot4Button_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will delete the current item in slot 4, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				Program.Profile.DeleteClaptrapsStashSlot(4);

				ProfileDirty = true;

				ClaptrapsStashNotifyLabel.Text = "Slot 4 deleted!";

				CopySlot4CodeButton.Enabled = false;
				DeleteSlot4Button.Enabled = false;
			}
		}

		private void MaxGoldenKeysButton_Click(object sender, EventArgs e)
		{
			switch (MessageBox.Show("This will set golden keys to max, do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
			{
			case DialogResult.Yes:
				GoldenKeysPOPremierClubInput.Value = Profile.MaxGoldenKeys;
				GoldenKeysPOPremierClubUsedInput.Value = 0;

				GoldenKeysTulipInput.Value = Profile.MaxGoldenKeys;
				GoldenKeysTulipUsedInput.Value = 0;

				GoldenKeysShiftInput.Value = Profile.MaxGoldenKeys;
				GoldenKeysShiftUsedInput.Value = 0;

				GoldenKeysTotalInput.Value = Profile.MaxGoldenKeysTotal;

				ProfileDirty = true;

				break;

			case DialogResult.No:

				break;
			}
		}
	}
}
