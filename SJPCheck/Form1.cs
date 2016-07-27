using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SJPCheck
{
	public partial class SjpChecker : Form
	{
		KeyboardHook hook = new KeyboardHook();

		public SjpChecker()
		{
			InitializeComponent();


			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Cursor.Position.X - 284, Cursor.Position.Y - 35);

			this.notifyIcon.ContextMenuStrip = this.contextMenu;

			// register the event that is fired after the key press.
			hook.KeyPressed +=
				new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
			// register the alt + Q combination as hot key.
			hook.RegisterHotKey(SJPCheck.ModifierKeys.Alt, Keys.Q);
		}

		void hook_KeyPressed(object sender, KeyPressedEventArgs e)
		{
			if (this.Visible == true)
			{
				this.Hide();
				this.notifyIcon.Visible = true;
			}
			else
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Location = new Point(Cursor.Position.X - 284, Cursor.Position.Y - 35);
				this.txtSlowo.Text = "";
				this.Show();
				this.Activate();
				this.notifyIcon.Visible = false;
			}
		}

		private void txtSlowo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && !String.IsNullOrWhiteSpace(txtSlowo.Text))
			{
				Process.Start("chrome.exe", @"http:\\www.sjp.pl\" + txtSlowo.Text);

				this.txtSlowo.Text = "";
				this.notifyIcon.Visible = true;
				this.Visible = false;

				e.Handled = true;
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.notifyIcon.Visible = false;
			this.Location = new Point(150, 250);
			this.Show();
			this.Activate();
			this.txtSlowo.Text = "";
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.Hide();
			if(notifyIcon != null)
			{
				this.notifyIcon.Visible = true;
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			this.notifyIcon = null;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}


	#region Shortcut Listner
	public sealed class KeyboardHook : IDisposable
	{
		// Registers a hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
		// Unregisters the hot key with Windows.
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		/// <summary>
		/// Represents the window that is used internally to get the messages.
		/// </summary>
		private class Window : NativeWindow, IDisposable
		{
			private static int WM_HOTKEY = 0x0312;

			public Window()
			{
				// create the handle for the window.
				this.CreateHandle(new CreateParams());
			}

			/// <summary>
			/// Overridden to get the notifications.
			/// </summary>
			/// <param name="m"></param>
			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);

				// check if we got a hot key pressed.
				if (m.Msg == WM_HOTKEY)
				{
					// get the keys.
					Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
					ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

					// invoke the event to notify the parent.
					if (KeyPressed != null)
						KeyPressed(this, new KeyPressedEventArgs(modifier, key));
				}
			}

			public event EventHandler<KeyPressedEventArgs> KeyPressed;

			#region IDisposable Members

			public void Dispose()
			{
				this.DestroyHandle();
			}

			#endregion
		}

		private Window _window = new Window();
		private int _currentId;

		public KeyboardHook()
		{
			// register the event of the inner native window.
			_window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
			{
				if (KeyPressed != null)
					KeyPressed(this, args);
			};
		}

		/// <summary>
		/// Registers a hot key in the system.
		/// </summary>
		/// <param name="modifier">The modifiers that are associated with the hot key.</param>
		/// <param name="key">The key itself that is associated with the hot key.</param>
		public void RegisterHotKey(ModifierKeys modifier, Keys key)
		{
			// increment the counter.
			_currentId = _currentId + 1;

			// register the hot key.
			if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
				throw new InvalidOperationException("Couldn’t register the hot key.");
		}

		/// <summary>
		/// A hot key has been pressed.
		/// </summary>
		public event EventHandler<KeyPressedEventArgs> KeyPressed;

		#region IDisposable Members

		public void Dispose()
		{
			// unregister all the registered hot keys.
			for (int i = _currentId; i > 0; i--)
			{
				UnregisterHotKey(_window.Handle, i);
			}

			// dispose the inner native window.
			_window.Dispose();
		}

		#endregion
	}

	/// <summary>
	/// Event Args for the event that is fired after the hot key has been pressed.
	/// </summary>
	public class KeyPressedEventArgs : EventArgs
	{
		private ModifierKeys _modifier;
		private Keys _key;

		internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
		{
			_modifier = modifier;
			_key = key;
		}

		public ModifierKeys Modifier
		{
			get { return _modifier; }
		}

		public Keys Key
		{
			get { return _key; }
		}
	}

	/// <summary>
	/// The enumeration of possible modifiers.
	/// </summary>
	[Flags]
	public enum ModifierKeys : uint
	{
		None = 0,
		Alt = 1,
		Control = 2,
		Shift = 4,
		Win = 8
	}
	#endregion
}
