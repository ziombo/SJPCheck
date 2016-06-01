using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SJPCheck
{
	public partial class Form1 : Form
	{
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
				this.notifyIcon1.Visible = true;
				this.Visible = false;
				e.Handled = true;
			}
		}


		private void Form1_Resize(object sender, EventArgs e)
		{

		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.notifyIcon1.Visible = false;
			this.Show();
			txtSlowo.Text = "";
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.Hide();
			this.notifyIcon1.Visible = true;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{

		}
	}
}
