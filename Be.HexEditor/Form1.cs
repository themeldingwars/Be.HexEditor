using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Be.HexEditor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Be.Windows.Forms.HexBox hexBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hexBox = new Be.Windows.Forms.HexBox();
			this.SuspendLayout();
			// 
			// hexBox
			// 
			this.hexBox.AllowDrop = true;
			this.hexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hexBox.HexCasing = Be.Windows.Forms.HexCasing.Lower;
			this.hexBox.Location = new System.Drawing.Point(88, 95);
			this.hexBox.Name = "hexBox";
			this.hexBox.SelectionLength = ((long)(0));
			this.hexBox.SelectionStart = ((long)(-1));
			this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((System.Byte)(100)), ((System.Byte)(60)), ((System.Byte)(188)), ((System.Byte)(255)));
			this.hexBox.Size = new System.Drawing.Size(712, 480);
			this.hexBox.TabIndex = 8;
			this.hexBox.UseFixedBytesPerLine = true;
			this.hexBox.VScrollBarVisible = true;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(888, 670);
			this.Controls.Add(this.hexBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
