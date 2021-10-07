using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Be.HexEditor
{
	/// <summary>
	/// Summary description for UCAbout.
	/// </summary>
	public class UCAbout : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblAuthor;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.TabControl tc;
		private System.Windows.Forms.TabPage tabLicense;
		private System.Windows.Forms.RichTextBox txtLicense;
		private System.Windows.Forms.TabPage tabChanges;
		private System.Windows.Forms.RichTextBox txtChanges;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel lnkWorkspace;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UCAbout()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			try
			{
				Assembly ca = Assembly.GetExecutingAssembly();

				string resLicense = "Be.HexEditor.Resources.License.rtf";
				txtLicense.LoadFile(ca.GetManifestResourceStream(resLicense), RichTextBoxStreamType.RichText);

				string resChanges = "Be.HexEditor.Resources.Changes.rtf";
				txtChanges.LoadFile(ca.GetManifestResourceStream(resChanges), RichTextBoxStreamType.RichText);			

				lblVersion.Text = ca.GetName().Version.ToString();
			}
			catch(Exception) 
			{
				return;
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UCAbout));
			this.label1 = new System.Windows.Forms.Label();
			this.lblAuthor = new System.Windows.Forms.Label();
			this.lnkWorkspace = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tc = new System.Windows.Forms.TabControl();
			this.tabLicense = new System.Windows.Forms.TabPage();
			this.txtLicense = new System.Windows.Forms.RichTextBox();
			this.tabChanges = new System.Windows.Forms.TabPage();
			this.txtChanges = new System.Windows.Forms.RichTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tc.SuspendLayout();
			this.tabLicense.SuspendLayout();
			this.tabChanges.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Author:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAuthor
			// 
			this.lblAuthor.BackColor = System.Drawing.Color.White;
			this.lblAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblAuthor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAuthor.Location = new System.Drawing.Point(88, 8);
			this.lblAuthor.Name = "lblAuthor";
			this.lblAuthor.Size = new System.Drawing.Size(224, 16);
			this.lblAuthor.TabIndex = 1;
			this.lblAuthor.Text = "Bernhard Elbl";
			// 
			// lnkWorkspace
			// 
			this.lnkWorkspace.BackColor = System.Drawing.Color.White;
			this.lnkWorkspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lnkWorkspace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lnkWorkspace.Location = new System.Drawing.Point(88, 32);
			this.lnkWorkspace.Name = "lnkWorkspace";
			this.lnkWorkspace.Size = new System.Drawing.Size(224, 16);
			this.lnkWorkspace.TabIndex = 3;
			this.lnkWorkspace.TabStop = true;
			this.lnkWorkspace.Text = "http://workspaces.gotdotnet.com/hexbox";
			this.lnkWorkspace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCompany_LinkClicked);
			// 
			// label5
			// 
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Link:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblVersion
			// 
			this.lblVersion.BackColor = System.Drawing.Color.White;
			this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblVersion.Location = new System.Drawing.Point(88, 56);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(224, 16);
			this.lblVersion.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Version:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tc
			// 
			this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tc.Controls.Add(this.tabLicense);
			this.tc.Controls.Add(this.tabChanges);
			this.tc.Location = new System.Drawing.Point(8, 80);
			this.tc.Name = "tc";
			this.tc.SelectedIndex = 0;
			this.tc.Size = new System.Drawing.Size(448, 224);
			this.tc.TabIndex = 9;
			// 
			// tabLicense
			// 
			this.tabLicense.Controls.Add(this.txtLicense);
			this.tabLicense.Location = new System.Drawing.Point(4, 22);
			this.tabLicense.Name = "tabLicense";
			this.tabLicense.Size = new System.Drawing.Size(440, 198);
			this.tabLicense.TabIndex = 0;
			this.tabLicense.Text = "License";
			// 
			// txtLicense
			// 
			this.txtLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLicense.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLicense.Location = new System.Drawing.Point(0, 0);
			this.txtLicense.Name = "txtLicense";
			this.txtLicense.ReadOnly = true;
			this.txtLicense.Size = new System.Drawing.Size(440, 198);
			this.txtLicense.TabIndex = 7;
			this.txtLicense.Text = "";
			this.txtLicense.WordWrap = false;
			// 
			// tabChanges
			// 
			this.tabChanges.Controls.Add(this.txtChanges);
			this.tabChanges.Location = new System.Drawing.Point(4, 22);
			this.tabChanges.Name = "tabChanges";
			this.tabChanges.Size = new System.Drawing.Size(328, 174);
			this.tabChanges.TabIndex = 1;
			this.tabChanges.Text = "Changes";
			// 
			// txtChanges
			// 
			this.txtChanges.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtChanges.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtChanges.Location = new System.Drawing.Point(0, 0);
			this.txtChanges.Name = "txtChanges";
			this.txtChanges.Size = new System.Drawing.Size(328, 174);
			this.txtChanges.TabIndex = 0;
			this.txtChanges.Text = "";
			this.txtChanges.WordWrap = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(352, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(96, 72);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// UCAbout
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.tc);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lnkWorkspace);
			this.Controls.Add(this.lblAuthor);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "UCAbout";
			this.Size = new System.Drawing.Size(464, 312);
			this.tc.ResumeLayout(false);
			this.tabLicense.ResumeLayout(false);
			this.tabChanges.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lnkCompany_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(this.lnkWorkspace.Text));
			}
			catch(Exception ex1)
			{
				MessageBox.Show(ex1.Message);
			}
		}
	}
}
