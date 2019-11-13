using System;
using System.Windows.Forms;
using B2Profile;

namespace B2ProfileGUI
{
	public class BadassRankUpDown : NumericUpDown
	{
		public void Inc()
		{
			decimal nextRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

			base.Increment = nextRank - base.Value;

			base.UpButton();
		}

		public override void UpButton()
		{
			Program.MainForm.BadassTokensEarnedInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();

			decimal nextRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

			base.Increment = nextRank - base.Value;

			base.UpButton();
		}

		public void Dec()
		{
			decimal prevRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

			base.Increment = base.Value - prevRank;

			if (prevRank == base.Value)
			{
				prevRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

				base.Increment = base.Value - prevRank;
			}

			base.DownButton();
		}

		public override void DownButton()
		{
			decimal prevRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

			base.Increment = base.Value - prevRank;

			if (prevRank == base.Value)
			{
				Program.MainForm.BadassTokensEarnedInput.Dec();
				Program.MainForm.BadassTokensAvailableInput.Dec();

				prevRank = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);

				base.Increment = base.Value - prevRank;
			}

			base.DownButton();
		}
	}

	public class BadassTokensEarnedUpDown : NumericUpDown
	{
		public decimal PrevValue;

		public void Inc()
		{
			base.UpButton();

			PrevValue = base.Value;
		}

		public override void UpButton()
		{
			base.UpButton();

			Program.MainForm.BadassRankInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();

			PrevValue = base.Value;
		}

		public void Dec()
		{
			base.DownButton();

			PrevValue = base.Value;
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.BadassRankInput.Dec();
			Program.MainForm.BadassTokensAvailableInput.Dec();

			PrevValue = base.Value;
		}

		protected override void OnLostFocus(EventArgs e)
		{
			PrevValue = base.Value;

			base.OnLostFocus(e);
		}

		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);

			if (base.UserEdit == true)
			{
				Program.MainForm.BadassRankInput.Value = Profile.GetBadassRankFromTokens((uint)base.Value);

				Program.MainForm.TransferToProfile();

				if (base.Value > PrevValue)
				{
					Program.MainForm.BadassTokensAvailableInput.Value += (base.Value - PrevValue) - Program.Profile.GetBadassTokensInvested();
				}
			}
		}
	}

	public class BadassTokensAvailableUpDown : NumericUpDown
	{
		public decimal PrevValue;

		public void Inc()
		{
			base.UpButton();

			PrevValue = base.Value;
		}

		public override void UpButton()
		{
			base.UpButton();

			Program.MainForm.TransferToProfile();

			if ((base.Value + Program.Profile.GetBadassTokensInvested()) > Program.MainForm.BadassTokensEarnedInput.Value)
			{
				if (Program.MainForm.SyncedModeCheckBox.Checked == true)
				{
					Program.MainForm.BadassTokensEarnedInput.Inc();
					Program.MainForm.BadassRankInput.Inc();
				}
			}

			PrevValue = base.Value;
		}

		public void Dec()
		{
			base.DownButton();

			PrevValue = base.Value;
		}

		public override void DownButton()
		{
			base.DownButton();

			PrevValue = base.Value;
		}

		protected override void OnLostFocus(EventArgs e)
		{
			PrevValue = base.Value;

			base.OnLostFocus(e);
		}

		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);

			if (base.UserEdit == true)
			{
				if (base.Value > PrevValue)
				{
					if (Program.MainForm.SyncedModeCheckBox.Checked == true)
					{
						Program.MainForm.BadassTokensEarnedInput.Value += (base.Value - PrevValue);

						Program.MainForm.BadassRankInput.Value = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);
					}
				}
			}
		}
	}

	public class BonusStatPercentUpDown : NumericUpDown
	{
		public BonusStatTokenUpDown TokenUpDown;

		public void Inc()
		{
			decimal nextPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = nextPercent - base.Value;

			base.UpButton();
		}

		public override void UpButton()
		{
			if (Program.MainForm.BadassTokensAvailableInput.Value > 0)
			{
				Program.MainForm.BadassTokensAvailableInput.Dec();
			}
			else
			{
				Program.MainForm.BadassTokensEarnedInput.Inc();
				Program.MainForm.BadassRankInput.Inc();
			}

			TokenUpDown.Inc();

			decimal nextPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = nextPercent - base.Value;

			base.UpButton();
		}

		public void Dec()
		{
			decimal prevPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = base.Value - prevPercent;

			base.DownButton();
		}

		public override void DownButton()
		{
			if (base.Value > 0)
			{
				Program.MainForm.BadassTokensAvailableInput.Inc();
			}

			TokenUpDown.Dec();

			decimal prevPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = base.Value - prevPercent;

			base.DownButton();
		}
	}

	public class BonusStatTokenUpDown : NumericUpDown
	{
		public BonusStatPercentUpDown PercentUpDown;

		public decimal PrevValue;

		public void Inc()
		{
			base.UpButton();

			PrevValue = base.Value;
		}

		public override void UpButton()
		{
			if (Program.MainForm.BadassTokensAvailableInput.Value > 0)
			{
				Program.MainForm.BadassTokensAvailableInput.Dec();
			}
			else
			{
				if (Program.MainForm.SyncedModeCheckBox.Checked == true)
				{
					Program.MainForm.BadassTokensEarnedInput.Inc();
					Program.MainForm.BadassRankInput.Inc();
				}
			}

			base.UpButton();

			PercentUpDown.Inc();

			PrevValue = base.Value;
		}

		public void Dec()
		{
			base.DownButton();

			PrevValue = base.Value;
		}

		public override void DownButton()
		{
			if (base.Value > 0 && Program.MainForm.BadassTokensAvailableInput.Value < Program.MainForm.BadassTokensEarnedInput.Value)
			{
				Program.MainForm.BadassTokensAvailableInput.Inc();
			}

			base.DownButton();

			PercentUpDown.Dec();

			PrevValue = base.Value;
		}

		protected override void OnLostFocus(EventArgs e)
		{
			PrevValue = base.Value;

			base.OnLostFocus(e);
		}

		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);

			if (base.UserEdit == true)
			{
				PercentUpDown.Value = (decimal)Profile.GetBonusPercentFromTokens((uint)base.Value);

				if (PrevValue > base.Value)
				{
					Program.MainForm.BadassTokensAvailableInput.Value += (PrevValue - base.Value);
				}
				else if (PrevValue < base.Value)
				{
					if (Program.MainForm.BadassTokensAvailableInput.Value > 0)
					{
						if (Program.MainForm.BadassTokensAvailableInput.Value - (base.Value - PrevValue) < 0)
						{
							if (Program.MainForm.SyncedModeCheckBox.Checked == true)
							{
								Program.MainForm.BadassTokensEarnedInput.Value += (base.Value - PrevValue) - Program.MainForm.BadassTokensAvailableInput.Value;
								Program.MainForm.BadassRankInput.Value = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);
							}

							Program.MainForm.BadassTokensAvailableInput.Value = 0;
						}
						else
						{
							Program.MainForm.BadassTokensAvailableInput.Value -= (base.Value - PrevValue);
						}
					}
					else
					{
						if (Program.MainForm.SyncedModeCheckBox.Checked == true)
						{
							Program.MainForm.BadassTokensEarnedInput.Value += (base.Value - PrevValue);
							Program.MainForm.BadassRankInput.Value = Profile.GetBadassRankFromTokens((uint)Program.MainForm.BadassTokensEarnedInput.Value);
						}
					}
				}
			}
		}
	}

	public class GoldenKeysUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();

			Program.MainForm.GoldenKeysTotalInput.Inc();
		}

		public override void UpButton()
		{
			base.UpButton();

			Program.MainForm.GoldenKeysTotalInput.Inc();
		}

		public void Dec()
		{
			base.DownButton();

			Program.MainForm.GoldenKeysTotalInput.Dec();
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.GoldenKeysTotalInput.Dec();
		}
	}

	public class GoldenKeysUsedUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();

			Program.MainForm.GoldenKeysTotalInput.Dec();
		}

		public override void UpButton()
		{
			base.UpButton();

			Program.MainForm.GoldenKeysTotalInput.Dec();
		}

		public void Dec()
		{
			base.DownButton();

			Program.MainForm.GoldenKeysTotalInput.Inc();
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.GoldenKeysTotalInput.Inc();
		}
	}

	public class GoldenKeysTotalUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();
		}

		public override void UpButton()
		{
			// base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			// base.DownButton();
		}
	}
}
