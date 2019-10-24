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
		private Profile Profile;
		private string ProfilePath;
		bool ProfileDirty;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Profile = null;
			ProfilePath = null;
			ProfileDirty = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					Profile.Save(ProfilePath);

					Profile = null;

					break;

				case DialogResult.No:
					Profile = null;

					break;

				case DialogResult.Cancel:
					e.Cancel = true;

					break;
				}
			}
		}

		private void MainMenuOpenButton_Click(object sender, EventArgs e)
		{
			if (Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					Profile.Save(ProfilePath);

					Profile = null;

					break;

				case DialogResult.No:
					Profile = null;

					break;

				case DialogResult.Cancel:
					return;

					break;
				}
			}

			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Title = "Select BL2 Profile";
			openFileDialog.Filter = "BL2 Profile|*.bin";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Borderlands 2\\WillowGame\\SaveData";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Profile = new Profile(openFileDialog.FileName);
				ProfilePath = openFileDialog.FileName;

				BadassRankInput.Value = Profile.GetBadassRank();
				BadassTokensEarnedInput.Value = Profile.GetBadassTokensEarned();
				BadassTokensAvailableInput.Value = Profile.GetBadassTokensAvailable();

				MaximumHealthBonusPercentInput.Value = (decimal)Profile.GetMaximumHealthBonus();
				MaximumHealthBonusTokensInput.Value = Profile.GetMaximumHealthTokens();

				ShieldCapacityBonusPercentInput.Value = (decimal)Profile.GetShieldCapacityBonus();
				ShieldCapacityBonusTokensInput.Value = Profile.GetShieldCapacityTokens();

				ShieldRechargeDelayBonusPercentInput.Value = (decimal)Profile.GetShieldRechargeDelayBonus();
				ShieldRechargeDelayBonusTokensInput.Value = Profile.GetShieldRechargeDelayTokens();

				ShieldRechargeRateBonusPercentInput.Value = (decimal)Profile.GetShieldRechargeRateBonus();
				ShieldRechargeRateBonusTokensInput.Value = Profile.GetShieldRechargeRateTokens();

				MeleeDamageBonusPercentInput.Value = (decimal)Profile.GetMeleeDamageBonus();
				MeleeDamageBonusTokensInput.Value = Profile.GetMeleeDamageTokens();

				GrenadeDamageBonusPercentInput.Value = (decimal)Profile.GetGrenadeDamageBonus();
				GrenadeDamageBonusTokensInput.Value = Profile.GetGrenadeDamageTokens();

				GunAccuracyBonusPercentInput.Value = (decimal)Profile.GetGunAccuracyBonus();
				GunAccuracyBonusTokensInput.Value = Profile.GetGunAccuracyTokens();

				GunDamageBonusPercentInput.Value = (decimal)Profile.GetGunDamageBonus();
				GunDamageBonusTokensInput.Value = Profile.GetGunDamageTokens();

				FireRateBonusPercentInput.Value = (decimal)Profile.GetFireRateBonus();
				FireRateBonusTokensInput.Value = Profile.GetFireRateTokens();

				RecoilReductionBonusPercentInput.Value = (decimal)Profile.GetRecoilReductionBonus();
				RecoilReductionBonusTokensInput.Value = Profile.GetRecoilReductionTokens();

				ReloadSpeedBonusPercentInput.Value = (decimal)Profile.GetReloadSpeedBonus();
				ReloadSpeedBonusTokensInput.Value = Profile.GetReloadSpeedTokens();

				ElementalEffectChanceBonusPercentInput.Value = (decimal)Profile.GetElementalEffectChanceBonus();
				ElementalEffectChanceBonusTokensInput.Value = Profile.GetElementalEffectChanceTokens();

				ElementalEffectDamageBonusPercentInput.Value = (decimal)Profile.GetElementalEffectDamageBonus();
				ElementalEffectDamageBonusTokensInput.Value = Profile.GetElementalEffectDamageTokens();

				CriticalHitDamageBonusPercentInput.Value = (decimal)Profile.GetCriticalHitDamageBonus();
				CriticalHitDamageBonusTokensInput.Value = Profile.GetCriticalHitDamageTokens();

				GoldenKeysShiftInput.Value = Profile.GetGoldenKeysShiftEntry().GetNumKeys();
				GoldenKeysShiftUsedInput.Value = Profile.GetGoldenKeysShiftEntry().GetNumKeysUsed();
				GoldenKeysShiftSourceIDInput.Value = Profile.GetGoldenKeysShiftEntry().GetSourceID();

				GoldenKeysPOPremierClubInput.Value = Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeys();
				GoldenKeysPOPremierClubUsedInput.Value = Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeysUsed();
				GoldenKeysPOPremierClubSourceIDInput.Value = Profile.GetGoldenKeysPOPremierClubEntry().GetSourceID();

				GoldenKeysTulipInput.Value = Profile.GetGoldenKeysTulipEntry().GetNumKeys();
				GoldenKeysTulipUsedInput.Value = Profile.GetGoldenKeysTulipEntry().GetNumKeysUsed();
				GoldenKeysTulipSourceIDInput.Value = Profile.GetGoldenKeysTulipEntry().GetSourceID();

				GoldenKeysTotalInput.Value
					= (Profile.GetGoldenKeysShiftEntry().GetNumKeys() - Profile.GetGoldenKeysShiftEntry().GetNumKeysUsed())
					+ (Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeys() - Profile.GetGoldenKeysPOPremierClubEntry().GetNumKeysUsed())
					+ (Profile.GetGoldenKeysTulipEntry().GetNumKeys() - Profile.GetGoldenKeysTulipEntry().GetNumKeysUsed());
			}
		}

		private void MainMenuSaveButton_Click(object sender, EventArgs e)
		{
			if (Profile != null)
			{
				Profile.Save(ProfilePath);
			}
		}

		private void MainMenuAboutButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Borderlands 2 - Profile Editor v1.0.0.0\r\nCreator: withmorten\r\n\r\nSpecial thanks to: Philymaster, Feudalnate", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MainMenuCloseButton_Click(object sender, EventArgs e)
		{
			if (Profile != null)
			{
				switch (MessageBox.Show("A profile is loaded, do you want to save it?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
					Profile.Save(ProfilePath);

					Profile = null;

					Application.Exit();

					break;

				case DialogResult.No:
					Profile = null;

					Application.Exit();

					break;

				case DialogResult.Cancel:

					break;
				}
			}
		}
	}
}
