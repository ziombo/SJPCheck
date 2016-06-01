using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SJPCheck
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			notifyIcon1.Icon = Properties.Resources.ms_icon_2;
		}

		private void txtSlowo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && !String.IsNullOrWhiteSpace(txtSlowo.Text))
			{
				Process.Start("chrome.exe", @"http:\\www.sjp.pl\" + txtSlowo.Text);

				txtSlowo.Text = "";
				this.notifyIcon1.Visible = true;
				this.Visible = false;
				e.Handled = true;
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			notifyIcon1.Icon = Properties.Resources.ms_icon_2;
			this.notifyIcon1.Visible = false;
			this.Show();
			this.Activate();
			txtSlowo.Text = "";
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.Hide();
			if(notifyIcon1 != null)
			{
				this.notifyIcon1.Visible = true;
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			notifyIcon1 = null;
		}
	}
}
