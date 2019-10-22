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
		private Profile profile;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			profile = new Profile();
		}
	}
}
