namespace SJPCheck
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.txtSlowo = new System.Windows.Forms.TextBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.SuspendLayout();
			// 
			// txtSlowo
			// 
			this.txtSlowo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSlowo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
			this.txtSlowo.Location = new System.Drawing.Point(0, 0);
			this.txtSlowo.Name = "txtSlowo";
			this.txtSlowo.Size = new System.Drawing.Size(284, 35);
			this.txtSlowo.TabIndex = 0;
			this.txtSlowo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlowo_KeyPress);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 36);
			this.Controls.Add(this.txtSlowo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.Text = "Słowo do wyszukania";
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSlowo;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
	}
}

