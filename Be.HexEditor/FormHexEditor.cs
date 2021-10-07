using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Be.Windows.Forms;
using System.IO;

namespace Be.HexEditor
{
	/// <summary>
	/// Summary description for FormHexEditor.
	/// </summary>
	public class FormHexEditor : System.Windows.Forms.Form
	{
		FormFind _formFind = new FormFind();
		FormFindCancel _formFindCancel;
		FormGoTo _formGoto = new FormGoTo();
		byte[] _findBuffer = new byte[0];
		string _fileName;

		private Be.Windows.Forms.HexBox hexBox;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.MenuItem miEdit;
		private System.Windows.Forms.MenuItem miFindNext;
		private System.Windows.Forms.MenuItem miHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem miGoTo;
		private System.Windows.Forms.ToolBarButton btnOpen;
		private System.Windows.Forms.ToolBarButton btnSave;
		private System.Windows.Forms.ToolBar tb;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miClose;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.StatusBarPanel sbCharacterPosition;
		private System.Windows.Forms.MenuItem miCut;
		private System.Windows.Forms.MenuItem miCopy;
		private System.Windows.Forms.MenuItem miPaste;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton btnCut;
		private System.Windows.Forms.ToolBarButton btnCopy;
		private System.Windows.Forms.ToolBarButton btnPaste;
		private System.Windows.Forms.MenuItem miFind;
		private System.Windows.Forms.MenuItem miOpenDynamic;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormHexEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Init();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormHexEditor));
			this.hexBox = new Be.Windows.Forms.HexBox();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.miOpenDynamic = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.miClose = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miCut = new System.Windows.Forms.MenuItem();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.miPaste = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.miFind = new System.Windows.Forms.MenuItem();
			this.miFindNext = new System.Windows.Forms.MenuItem();
			this.miGoTo = new System.Windows.Forms.MenuItem();
			this.miHelp = new System.Windows.Forms.MenuItem();
			this.miAbout = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.sbCharacterPosition = new System.Windows.Forms.StatusBarPanel();
			this.tb = new System.Windows.Forms.ToolBar();
			this.btnOpen = new System.Windows.Forms.ToolBarButton();
			this.btnSave = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.btnCut = new System.Windows.Forms.ToolBarButton();
			this.btnCopy = new System.Windows.Forms.ToolBarButton();
			this.btnPaste = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.sbCharacterPosition)).BeginInit();
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
			this.hexBox.LineInfoForeColor = System.Drawing.Color.Gray;
			this.hexBox.LineInfoVisible = true;
			this.hexBox.Location = new System.Drawing.Point(8, 32);
			this.hexBox.Name = "hexBox";
			this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((System.Byte)(100)), ((System.Byte)(60)), ((System.Byte)(188)), ((System.Byte)(255)));
			this.hexBox.Size = new System.Drawing.Size(712, 480);
			this.hexBox.StringViewVisible = true;
			this.hexBox.TabIndex = 7;
			this.hexBox.UseFixedBytesPerLine = true;
			this.hexBox.VScrollBarVisible = true;
			this.hexBox.CurrentPositionInLineChanged += new System.EventHandler(this.Position_Changed);
			this.hexBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hexBox_KeyDown);
			this.hexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexBox_KeyPress);
			this.hexBox.SelectionStartChanged += new System.EventHandler(this.hexBox_SelectionStartChanged);
			this.hexBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hexBox_KeyUp);
			this.hexBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.hexBox_DragDrop);
			this.hexBox.CurrentLineChanged += new System.EventHandler(this.Position_Changed);
			this.hexBox.SelectionLengthChanged += new System.EventHandler(this.hexBox_SelectionLengthChanged);
			this.hexBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.hexBox_DragEnter);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miFile,
																					 this.miEdit,
																					 this.miHelp});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miOpen,
																				   this.miOpenDynamic,
																				   this.miSave,
																				   this.miClose,
																				   this.menuItem4,
																				   this.miExit});
			this.miFile.Text = "&File";
			// 
			// miOpen
			// 
			this.miOpen.Index = 0;
			this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.miOpen.Text = "&Open";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miOpenDynamic
			// 
			this.miOpenDynamic.Index = 1;
			this.miOpenDynamic.Text = "Open &Dynamic (Small files only)";
			this.miOpenDynamic.Click += new System.EventHandler(this.miOpenDynamic_Click);
			// 
			// miSave
			// 
			this.miSave.Enabled = false;
			this.miSave.Index = 2;
			this.miSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.miSave.Text = "&Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// miClose
			// 
			this.miClose.Enabled = false;
			this.miClose.Index = 3;
			this.miClose.Text = "&Close";
			this.miClose.Click += new System.EventHandler(this.miClose_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 5;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// miEdit
			// 
			this.miEdit.Index = 1;
			this.miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miCut,
																				   this.miCopy,
																				   this.miPaste,
																				   this.menuItem5,
																				   this.miFind,
																				   this.miFindNext,
																				   this.miGoTo});
			this.miEdit.Text = "&Edit";
			// 
			// miCut
			// 
			this.miCut.Enabled = false;
			this.miCut.Index = 0;
			this.miCut.Text = "Cu&t";
			this.miCut.Click += new System.EventHandler(this.miCut_Click);
			// 
			// miCopy
			// 
			this.miCopy.Enabled = false;
			this.miCopy.Index = 1;
			this.miCopy.Text = "&Copy";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// miPaste
			// 
			this.miPaste.Enabled = false;
			this.miPaste.Index = 2;
			this.miPaste.Text = "&Paste";
			this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// miFind
			// 
			this.miFind.Enabled = false;
			this.miFind.Index = 4;
			this.miFind.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.miFind.Text = "&Find";
			this.miFind.Click += new System.EventHandler(this.miFind_Click);
			// 
			// miFindNext
			// 
			this.miFindNext.Enabled = false;
			this.miFindNext.Index = 5;
			this.miFindNext.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.miFindNext.Text = "Find &Next";
			this.miFindNext.Click += new System.EventHandler(this.miFindNext_Click);
			// 
			// miGoTo
			// 
			this.miGoTo.Enabled = false;
			this.miGoTo.Index = 6;
			this.miGoTo.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.miGoTo.Text = "&Go To";
			this.miGoTo.Click += new System.EventHandler(this.miGoTo_Click);
			// 
			// miHelp
			// 
			this.miHelp.Index = 2;
			this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miAbout});
			this.miHelp.Text = "&Help";
			// 
			// miAbout
			// 
			this.miAbout.Index = 0;
			this.miAbout.Text = "About Be.HexEditor";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 515);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.sbCharacterPosition});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(728, 22);
			this.statusBar.TabIndex = 12;
			// 
			// sbCharacterPosition
			// 
			this.sbCharacterPosition.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.sbCharacterPosition.Width = 200;
			// 
			// tb
			// 
			this.tb.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																				  this.btnOpen,
																				  this.btnSave,
																				  this.toolBarButton1,
																				  this.btnCut,
																				  this.btnCopy,
																				  this.btnPaste});
			this.tb.ButtonSize = new System.Drawing.Size(23, 22);
			this.tb.DropDownArrows = true;
			this.tb.Location = new System.Drawing.Point(0, 0);
			this.tb.Name = "tb";
			this.tb.ShowToolTips = true;
			this.tb.Size = new System.Drawing.Size(728, 28);
			this.tb.TabIndex = 13;
			this.tb.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tb_ButtonClick);
			// 
			// btnOpen
			// 
			this.btnOpen.ToolTipText = "Open";
			// 
			// btnSave
			// 
			this.btnSave.ToolTipText = "Save";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnCut
			// 
			this.btnCut.Enabled = false;
			this.btnCut.ToolTipText = "Cut";
			// 
			// btnCopy
			// 
			this.btnCopy.Enabled = false;
			this.btnCopy.ToolTipText = "Copy";
			// 
			// btnPaste
			// 
			this.btnPaste.Enabled = false;
			this.btnPaste.ToolTipText = "Paste";
			// 
			// FormHexEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(728, 537);
			this.Controls.Add(this.tb);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.hexBox);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "FormHexEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Be.HexEditor";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormHexEditor_Closing);
			this.Load += new System.EventHandler(this.FormHexEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbCharacterPosition)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread()]
		static void Main(string[] args)
		{
			using(new EnableThemingInScope(true))
			{
				FormHexEditor fhe = new FormHexEditor();

				if(args.Length > 0)
					fhe.OpenFile(args[0]);

				Application.Run(fhe);
			}
		}

		/// <summary>
		/// Initializes the hex editor´s main form
		/// </summary>
		void Init()
		{
			DisplayText(null);

			ImageList il = Resources.Images.GenerateImageList();
			tb.ImageList = il;
			btnOpen.ImageIndex = 1;
			btnSave.ImageIndex = 2;
			btnCut.ImageIndex = 3;
			btnCopy.ImageIndex = 4;
			btnPaste.ImageIndex = 5;

			ManageAbility();
		}

		/// <summary>
		/// Displays the file name in the Form´s text property
		/// </summary>
		/// <param name="fileName">the file name to display</param>
		void DisplayText(string fileName)
		{
			if(fileName != null && fileName.Length > 0)
			{
				string text = Path.GetFileName(fileName);
				this.Text = string.Format("{0} - Be.HexEditor", text);
			}
			else
			{
				this.Text = "Be.HexEditor";
			}
		}

		/// <summary>
		/// Manages enabling or disabling of menu items and toolbar buttons.
		/// </summary>
		void ManageAbility()
		{
			if(hexBox.ByteProvider == null)
			{
				miClose.Enabled = false;
				miSave.Enabled = btnSave.Enabled = false;

				miFind.Enabled = false;
				miFindNext.Enabled = false;
			}
			else
			{
				miSave.Enabled = btnSave.Enabled = hexBox.ByteProvider.HasChanges();
				
				miClose.Enabled = true;

				miFind.Enabled = true;
				miFindNext.Enabled = true;
				miGoTo.Enabled = true;
			}

			ManageAbilityForCopyAndPaste();
		}

		/// <summary>
		/// Manages enabling or disabling of menu items and toolbar buttons for copy and paste
		/// </summary>
		void ManageAbilityForCopyAndPaste()
		{
			miCopy.Enabled = btnCopy.Enabled = hexBox.CanCopy();
			miCut.Enabled = btnCut.Enabled =hexBox.CanCut();
			miPaste.Enabled = btnPaste.Enabled =hexBox.CanPaste();
		}

		/// <summary>
		/// Shows the open file dialog.
		/// </summary>
		void OpenFile()
		{
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				OpenFile(openFileDialog.FileName);
			}
		}


		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="fileName">the file name of the file to open</param>
		void OpenFile(string fileName)
		{
			if(!File.Exists(fileName))
			{
				MessageBox.Show("File does not exist!");
				return;
			}

			if(hexBox.ByteProvider != null)
			{
				if(CloseFile() == DialogResult.Cancel)
					return;
			}

			try
			{
				FileByteProvider fileByteProvider = new FileByteProvider(fileName);
				fileByteProvider.Changed += new EventHandler(fileByteProvider_Changed);
				hexBox.ByteProvider = fileByteProvider;
				_fileName = fileName;

				DisplayText(fileName);
			}
			catch(Exception ex1)
			{
				MessageBox.Show(ex1.Message, "Be.HexEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				ManageAbility();
			}
		}

		
		/// <summary>
		/// Shows the open file dialog.
		/// </summary>
		void OpenFileDynamic()
		{
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				OpenFileDynamic(openFileDialog.FileName);
			}
		}

		/// <summary>
		/// Opens a file with dynamic byte provider.
		/// </summary>
		/// <param name="fileName">the file name of the file to open</param>
		void OpenFileDynamic(string fileName)
		{
			if(!File.Exists(fileName))
			{
				MessageBox.Show("File does not exist!");
				return;
			}

			if(hexBox.ByteProvider != null)
			{
				if(CloseFile() == DialogResult.Cancel)
					return;
			}

			try
			{
				using(FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					byte[] data = new byte[stream.Length];
					stream.Read(data, 0, data.Length);
					DynamicByteProvider dynamicByteProvider = new DynamicByteProvider(data);
					dynamicByteProvider.Changed += new EventHandler(dynamicByteProvider_Changed);
					hexBox.ByteProvider = dynamicByteProvider;
					_fileName = fileName;
					DisplayText(fileName);
				}
			}
			catch(Exception ex1)
			{
				MessageBox.Show(ex1.Message, "Be.HexEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			finally
			{
				ManageAbility();
			}
		}

		/// <summary>
		/// Saves the current file.
		/// </summary>
		void SaveFile()
		{
			if(hexBox.ByteProvider == null)
				return;

			try
			{

				FileByteProvider fileByteProvider = hexBox.ByteProvider as FileByteProvider;
				if(fileByteProvider != null)
				{
					fileByteProvider.ApplyChanges();
				}

				DynamicByteProvider dynamicByteProvider = hexBox.ByteProvider as DynamicByteProvider;
				if(dynamicByteProvider != null)
				{
					byte[] data = dynamicByteProvider.Bytes.ToArray();
					using(FileStream stream = File.Open(_fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
					{
						stream.Write(data, 0, data.Length);
					}
					dynamicByteProvider.ApplyChanges();
				}
			}
			catch(Exception ex1)
			{
				MessageBox.Show(ex1.Message, "Be.HexEditor", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				ManageAbility();
			}
		}

		/// <summary>
		/// Closes the current file
		/// </summary>
		/// <returns>OK, if the current file was closed.</returns>
		DialogResult CloseFile()
		{
			if(hexBox.ByteProvider == null)
				return DialogResult.OK;

			try
			{
				if(hexBox.ByteProvider != null && hexBox.ByteProvider.HasChanges())
				{
					DialogResult res = MessageBox.Show("Do you want to save changes?", 
						"Be.HexEditor", 
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Warning);

					if(res == DialogResult.Yes)
					{
						SaveFile();
						CleanUp();
					}
					else if(res == DialogResult.No)
					{
						CleanUp();
					}
					else if(res == DialogResult.Cancel)
					{
						return res;
					}

					return res;
				}
				else
				{
					CleanUp();
					return DialogResult.OK;
				}
			}
			finally
			{
				ManageAbility();
			}
		}

		void CleanUp()
		{
			if(hexBox.ByteProvider != null)
			{
				IDisposable byteProvider = hexBox.ByteProvider as IDisposable;
				if(byteProvider != null)
					byteProvider.Dispose();
				hexBox.ByteProvider = null;
			}
			_fileName = null;
			DisplayText(null);
		}

		/// <summary>
		/// Opens the Find dialog
		/// </summary>
		void Find()
		{
			if(_formFind.ShowDialog() == DialogResult.OK)
			{
				_findBuffer = _formFind.GetFindBytes();
				FindNext();
			}
		}

		/// <summary>
		/// Find next match
		/// </summary>
		void FindNext()
		{
			if(_findBuffer.Length == 0)
			{
				Find();
				return;
			}

			// show cancel dialog
			_formFindCancel = new FormFindCancel();
			_formFindCancel.SetHexBox(hexBox);
			_formFindCancel.Closed += new EventHandler(FormFindCancel_Closed);
			_formFindCancel.Show();

			// block activation of main form
			Activated += new EventHandler(FocusToFormFindCancel);

			// start find process
			long res = hexBox.Find(_findBuffer, hexBox.SelectionStart + hexBox.SelectionLength);

			_formFindCancel.Dispose();

			// unblock activation of main form
			Activated -= new EventHandler(FocusToFormFindCancel);

			if(res == -1) // -1 = no match
			{
				MessageBox.Show("Find reached end of file", "Be.HexEditor", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if(res == -2) // -2 = find was aborted
			{
				return;
			}
			else // something was found
			{
				if(!hexBox.Focused) 
					hexBox.Focus();
			}

			ManageAbility();
		}

		/// <summary>
		/// Aborts the current find process
		/// </summary>
		void FormFindCancel_Closed(object sender, EventArgs e)
		{
			hexBox.AbortFind();
		}

		/// <summary>
		/// Put focus back to the cancel form.
		/// </summary>
		void FocusToFormFindCancel(object sender, EventArgs e)
		{
			_formFindCancel.Focus();
		}

		/// <summary>
		/// Displays the goto byte dialog.
		/// </summary>
		void Goto()
		{
			_formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
			_formGoto.SetDefaultValue(hexBox.SelectionStart);
			if(_formGoto.ShowDialog() == DialogResult.OK)
			{
				hexBox.SelectionStart = _formGoto.GetByteIndex();
				hexBox.SelectionLength = 1;
				hexBox.Focus();
			}
		}

		/// <summary>
		/// Enables drag&drop
		/// </summary>
		private void hexBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		/// <summary>
		/// Processes a file drop
		/// </summary>
		private void hexBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
		 	string[] formats = e.Data.GetFormats();
			object oFileNames = e.Data.GetData(DataFormats.FileDrop);
			string[] fileNames = (string[])oFileNames;
			if(fileNames.Length == 1)
			{
				OpenFile(fileNames[0]);
			}
		}

		void Position_Changed(object sender, EventArgs e)
		{
			this.sbCharacterPosition.Text = string.Format("Ln {0}    Col {1}", 
				hexBox.CurrentLine, hexBox.CurrentPositionInLine);
		}

		private void fileByteProvider_Changed(object sender, EventArgs e)
		{
			ManageAbility();
		}

		private void dynamicByteProvider_Changed(object sender, EventArgs e)
		{
			ManageAbility();
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void FormHexEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(CloseFile() == DialogResult.Cancel)
				e.Cancel = true;
		}

		private void miFind_Click(object sender, System.EventArgs e)
		{
			Find();
		}

		private void miFindNext_Click(object sender, System.EventArgs e)
		{
			FindNext();
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			new FormAbout().ShowDialog();
		}

		private void miGoTo_Click(object sender, System.EventArgs e)
		{
			Goto();
		}

		private void FormHexEditor_Load(object sender, System.EventArgs e)
		{
		
		}

		private void tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == btnOpen) OpenFile();
			else if(e.Button == btnSave) SaveFile();
			else if(e.Button == btnCut) hexBox.Cut();
			else if(e.Button == btnCopy) hexBox.Copy();
			else if(e.Button == btnPaste) hexBox.Paste();
			
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		private void miOpenDynamic_Click(object sender, System.EventArgs e)
		{
			OpenFileDynamic();
		}

		private void miSave_Click(object sender, System.EventArgs e)
		{
			SaveFile();
		}

		private void miClose_Click(object sender, System.EventArgs e)
		{
			CloseFile();
		}

		private void hexBox_SelectionLengthChanged(object sender, System.EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		private void hexBox_SelectionStartChanged(object sender, System.EventArgs e)
		{
			ManageAbilityForCopyAndPaste();
		}

		private void miCut_Click(object sender, System.EventArgs e)
		{
			hexBox.Cut();
		}

		private void miCopy_Click(object sender, System.EventArgs e)
		{
			hexBox.Copy();
		}

		private void miPaste_Click(object sender, System.EventArgs e)
		{
			hexBox.Paste();
		}

		private void hexBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// for testing purpose only - ignore this...
			System.Diagnostics.Debug.WriteLine("hexBox_KeyDown");
		}

		private void hexBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// for testing purpose only - ignore this...
			System.Diagnostics.Debug.WriteLine("hexBox_KeyPress");
		}

		private void hexBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// for testing purpose only - ignore this...
			System.Diagnostics.Debug.WriteLine("hexBox_KeyUp");
		}
	}
}
