using System;
using System.Windows.Forms;

namespace B2ProfileGUI
{
	public class BadassRankUpDown : NumericUpDown
	{
		public void Inc()
		{
			decimal nextRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value + 1, 1.8));

			base.Increment = nextRank - base.Value;

			base.UpButton();
		}

		public override void UpButton()
		{
			decimal nextRank = (decimal)Math.Floor(Math.Pow((double)Program.MainForm.BadassTokensEarnedInput.Value + 1, 1.8));

			base.Increment = nextRank - base.Value;

			Program.MainForm.BadassTokensEarnedInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();

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

	public class BadassTokensAvailableUpDown : NumericUpDown
	{
		public void Inc()
		{
			if (base.Value == 0)
			{
				// TODO this needs to be in the badass token updown
				// Program.MainForm.BadassRankInput.Inc();
				// Program.MainForm.BadassTokensEarnedInput.Inc();
			}

			base.UpButton();
		}

		public override void UpButton()
		{
			if (base.Value == 0)
			{
				// TODO this needs to be in the badass token updown
				// Program.MainForm.BadassRankInput.Inc();
				// Program.MainForm.BadassTokensEarnedInput.Inc();
			}

			base.UpButton();
		}

		public void Dec()
		{
			if (base.Value == 0)
			{
				Program.MainForm.MainForm_DecreaseNextBonusStat();
			}

			base.DownButton();
		}

		public override void DownButton()
		{
			if (base.Value == 0)
			{
				Program.MainForm.MainForm_DecreaseNextBonusStat();
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
			Program.MainForm.BadassRankInput.Inc();
			Program.MainForm.BadassTokensAvailableInput.Inc();

			base.UpButton();
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

	public class BonusStatPercentUpDown : NumericUpDown
	{

	}

	public class BonusStatTokenUpDown : NumericUpDown
	{

	}

	public class GoldenKeysUpDown : NumericUpDown
	{

	}

	public class GoldenKeysUsedUpDown : NumericUpDown
	{

	}
}
