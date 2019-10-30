using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

		private void MainForm_LoadProfile()
		{
			Program.Profile = new Profile(ProfileFilePath);

			BadassRankInput.Value = Program.Profile.GetBadassRank();
			BadassTokensEarnedInput.Value = Program.Profile.GetBadassTokensEarned();
			BadassTokensAvailableInput.Value = Program.Profile.GetBadassTokensAvailable();

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
				= (Program.Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeys() - Program.Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeysUsed())
				+ (Program.Profile.GetGoldenKeysTulipEntry().GetNumKeys() - Program.Profile.GetGoldenKeysTulipEntry().GetNumKeysUsed())
				+ (Program.Profile.GetGoldenKeysShiftEntry().GetNumKeys() - Program.Profile.GetGoldenKeysShiftEntry().GetNumKeysUsed());
		}

		private void MainForm_SaveProfile()
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

			Program.Profile.Save(ProfileFilePath);

			MessageBox.Show("Profile saved!\r\n\r\nIf you want revert the changes, go to your SaveData directory and rename the profile.bin.bak generated by this tool to profile.bin!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MainForm_EnableGUI()
		{
			MainMenuSaveButton.Enabled = true;

			UnlockAllCustomizationsButton.Enabled = true;
			LockAllCustomizationsButton.Enabled = true;

			BadassRankInput.Enabled = true;
			BadassTokensAvailableInput.Enabled = true;
			BadassTokensEarnedInput.Enabled = true;

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

			GoldenKeysTulipInput.Enabled = true;
			GoldenKeysTulipUsedInput.Enabled = true;

			GoldenKeysShiftInput.Enabled = true;
			GoldenKeysShiftUsedInput.Enabled = true;

			GoldenKeysPOPremierClubInput.Enabled = true;
			GoldenKeysPOPremierClubUsedInput.Enabled = true;

			GoldenKeysTotalInput.Enabled = true;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Program.MainForm = this;
			Program.Profile = null;
			ProfileFilePath = null;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Program.Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					MainForm_SaveProfile();

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
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					MainForm_SaveProfile();

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

				MainForm_LoadProfile();

				MainForm_EnableGUI();
			}
		}

		private void MainMenuSaveButton_Click(object sender, EventArgs e)
		{
			MainForm_SaveProfile();
		}

		private void MainMenuAboutButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Borderlands 2 - Profile Editor v1.0.0.0\r\nCreator: withmorten\r\n\r\nSpecial thanks to: Philymaster, Feudalnate", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MainMenuCloseButton_Click(object sender, EventArgs e)
		{
			if (Program.Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
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
			Program.Profile.UnlockAllCustomizations();

			MessageBox.Show("All customizations unlocked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void LockAllCustomizationsButton_Click(object sender, EventArgs e)
		{
			Program.Profile.LockAllCustomizations();

			MessageBox.Show("All customizations locked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
