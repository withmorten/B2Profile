using System;
using System.Windows.Forms;

namespace B2ProfileGUI
{
	public class BadassRankUpDown : NumericUpDown
	{
		public void Inc()
		{
			decimal nextRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value, 1.8));

			base.Increment = nextRank - base.Value;

			base.UpButton();
		}

		public override void UpButton()
		{
			Program.MainForm.BadassTokensEarnedInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();

			decimal nextRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value + 1, 1.8));

			base.Increment = nextRank - base.Value;

			base.UpButton();
		}

		public void Dec()
		{
			decimal prevRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value, 1.8));

			base.Increment = base.Value - prevRank;

			if (prevRank == base.Value)
			{
				prevRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value, 1.8));

				base.Increment = base.Value - prevRank;
			}

			base.DownButton();
		}

		public override void DownButton()
		{
			decimal prevRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value, 1.8));

			base.Increment = base.Value - prevRank;

			if (prevRank == base.Value)
			{
				Program.MainForm.BadassTokensEarnedInput.Dec();
				Program.MainForm.BadassTokensAvailableInput.Dec();

				prevRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value, 1.8));

				base.Increment = base.Value - prevRank;
			}

			base.DownButton();
		}
	}

	public class BadassTokensEarnedUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();
		}

		public override void UpButton()
		{
			base.UpButton();

			Program.MainForm.BadassRankInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.BadassRankInput.Dec();
			Program.MainForm.BadassTokensAvailableInput.Dec();
		}
	}

	public class BadassTokensAvailableUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();
		}

		public override void UpButton()
		{
			Program.MainForm.BadassTokensEarnedInput.Inc();
			Program.MainForm.BadassRankInput.Inc();

			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();

			if (Program.MainForm.BadassTokensEarnedInput.Value > base.Value && base.Value + 1 >= 1)
			{
				Program.MainForm.MainForm_IncreaseNextBonusStat();
			}
			else if (base.Value == 0)
			{
				Program.MainForm.MainForm_DecreaseNextBonusStat();
			}
		}

		public override void DownButton()
		{
			base.DownButton();

			if (Program.MainForm.BadassTokensEarnedInput.Value > base.Value && base.Value + 1 >= 1)
			{
				Program.MainForm.MainForm_IncreaseNextBonusStat();
			}
			else if (base.Value == 0)
			{
				Program.MainForm.MainForm_DecreaseNextBonusStat();
			}
		}
	}

	public class BonusStatPercentUpDown : NumericUpDown
	{
		public BonusStatTokenUpDown TokenUpDown;

		public void Inc()
		{
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
				Program.MainForm.BadassRankInput.Inc();
				Program.MainForm.BadassTokensEarnedInput.Inc();
			}

			TokenUpDown.Inc();

			decimal nextPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = nextPercent - base.Value;

			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.BadassTokensAvailableInput.Inc();

			TokenUpDown.Dec();

			decimal prevPercent = (decimal)Math.Round(Math.Pow((double)TokenUpDown.Value, 0.75), 1);

			base.Increment = base.Value - prevPercent;
		}
	}

	public class BonusStatTokenUpDown : NumericUpDown
	{
		public BonusStatPercentUpDown PercentUpDown;

		public void Inc()
		{
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
				Program.MainForm.BadassRankInput.Inc();
				Program.MainForm.BadassTokensEarnedInput.Inc();
			}

			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();

			Program.MainForm.BadassTokensAvailableInput.Inc();
		}
	}

	public class GoldenKeysUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();
		}

		public override void UpButton()
		{
			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();
		}
	}

	public class GoldenKeysUsedUpDown : NumericUpDown
	{
		public void Inc()
		{
			base.UpButton();
		}

		public override void UpButton()
		{
			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();
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
			base.UpButton();
		}

		public void Dec()
		{
			base.DownButton();
		}

		public override void DownButton()
		{
			base.DownButton();
		}
	}
}
