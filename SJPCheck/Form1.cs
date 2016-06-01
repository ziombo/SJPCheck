using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJPCheck
{
	public partial class Form1 : Form
	{
		static NotifyIcon x; 
		public Form1()
		{
			InitializeComponent();
		}

		private void txtSlowo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				Process.Start("chrome.exe", @"http:\\www.sjp.pl\" + txtSlowo.Text);

				txtSlowo.Text = "";
				x.Visible = true;
				this.Visible = false;
				e.Handled = true;
			}
		}


		private void Form1_Resize(object sender, EventArgs e)
		{

		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			x.Visible = false;
			this.Show();
			txtSlowo.Text = "";
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.Hide();
			x.Visible = true;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			x = notifyIcon1;
		}
	}
}
