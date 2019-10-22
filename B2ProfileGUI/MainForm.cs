using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2Profile
{
	public partial class MainForm : Form
	{
		private B2Profile profile;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			profile = new B2Profile();

			BonusStatsTable_Initialize();
		}

		private void BonusStatsTable_Initialize()
		{
			// BonusStatsTable.Rows.Add("Maximum Health");
			// BonusStatsTable.Rows.Add("Shield Capacity");
			// BonusStatsTable.Rows.Add("Shield Recharge Delay");
			// BonusStatsTable.Rows.Add("Shield Recharge Rate");
			// BonusStatsTable.Rows.Add("Melee Damage");
			// BonusStatsTable.Rows.Add("Grenade Damage");
			// BonusStatsTable.Rows.Add("Gun Accuracy");
			// BonusStatsTable.Rows.Add("Gun Damage");
			// BonusStatsTable.Rows.Add("Fire Rate");
			// BonusStatsTable.Rows.Add("Recoil Reduction");
			// BonusStatsTable.Rows.Add("Reload Speed");
			// BonusStatsTable.Rows.Add("Elemental Effect Chance");
			// BonusStatsTable.Rows.Add("Elemental Effect Damage");
			// BonusStatsTable.Rows.Add("Critical Hit Damage");

			// for (int i = 0; i < BonusStatsTable.Rows.Count; i++)
			// {
			// 	BonusStatsTable.Rows[i].Cells[1].Value = "0.0";
			// 	BonusStatsTable.Rows[i].Cells[2].Value = 0;
			// }
		}
	}
}
