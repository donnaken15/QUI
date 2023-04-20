partial class qdesign
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
		this.elementtitle = new System.Windows.Forms.Label();
		this.splitter1 = new System.Windows.Forms.SplitContainer();
		this.splitter2 = new System.Windows.Forms.SplitContainer();
		this.elementlist = new System.Windows.Forms.ListView();
		this.etab = new System.Windows.Forms.ColumnHeader();
		this.toolbar = new System.Windows.Forms.ToolStrip();
		this.menuCut = new System.Windows.Forms.ToolStripButton();
		this.menuCopy = new System.Windows.Forms.ToolStripButton();
		this.menuPaste = new System.Windows.Forms.ToolStripButton();
		this.menuDel = new System.Windows.Forms.ToolStripButton();
		this.eventsbtn = new System.Windows.Forms.Button();
		this.elementprops = new System.Windows.Forms.PropertyGrid();
		this.elembtns = new System.Windows.Forms.ToolStrip();
		this.menuSprite = new System.Windows.Forms.ToolStripButton();
		this.menuText = new System.Windows.Forms.ToolStripButton();
		this.menuCont = new System.Windows.Forms.ToolStripButton();
		this.menuWin = new System.Windows.Forms.ToolStripButton();
		this.menuMenu = new System.Windows.Forms.ToolStripButton();
		this.propslbl = new System.Windows.Forms.Label();
		this.elementdraw = new System.Windows.Forms.PictureBox();
		this.menubar = new System.Windows.Forms.MenuStrip();
		this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
		this.loadzBtn = new System.Windows.Forms.ToolStripMenuItem();
		this.zonesDiag = new System.Windows.Forms.OpenFileDialog();
		this.splitter1.Panel1.SuspendLayout();
		this.splitter1.Panel2.SuspendLayout();
		this.splitter1.SuspendLayout();
		this.splitter2.Panel1.SuspendLayout();
		this.splitter2.Panel2.SuspendLayout();
		this.splitter2.SuspendLayout();
		this.toolbar.SuspendLayout();
		this.elembtns.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.elementdraw)).BeginInit();
		this.menubar.SuspendLayout();
		this.SuspendLayout();
		// 
		// elementtitle
		// 
		this.elementtitle.AutoSize = true;
		this.elementtitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.elementtitle.Location = new System.Drawing.Point(3, 0);
		this.elementtitle.Name = "elementtitle";
		this.elementtitle.Size = new System.Drawing.Size(53, 13);
		this.elementtitle.TabIndex = 1;
		this.elementtitle.Text = "Elements:";
		// 
		// splitter1
		// 
		this.splitter1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
		this.splitter1.Location = new System.Drawing.Point(0, 24);
		this.splitter1.Name = "splitter1";
		// 
		// splitter1.Panel1
		// 
		this.splitter1.Panel1.Controls.Add(this.splitter2);
		// 
		// splitter1.Panel2
		// 
		this.splitter1.Panel2.Controls.Add(this.elementdraw);
		this.splitter1.Size = new System.Drawing.Size(901, 678);
		this.splitter1.SplitterDistance = 245;
		this.splitter1.TabIndex = 5;
		// 
		// splitter2
		// 
		this.splitter2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitter2.Location = new System.Drawing.Point(0, 0);
		this.splitter2.Name = "splitter2";
		this.splitter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// splitter2.Panel1
		// 
		this.splitter2.Panel1.Controls.Add(this.elementlist);
		this.splitter2.Panel1.Controls.Add(this.elementtitle);
		// 
		// splitter2.Panel2
		// 
		this.splitter2.Panel2.Controls.Add(this.toolbar);
		this.splitter2.Panel2.Controls.Add(this.eventsbtn);
		this.splitter2.Panel2.Controls.Add(this.elementprops);
		this.splitter2.Panel2.Controls.Add(this.elembtns);
		this.splitter2.Panel2.Controls.Add(this.propslbl);
		this.splitter2.Size = new System.Drawing.Size(245, 678);
		this.splitter2.SplitterDistance = 287;
		this.splitter2.TabIndex = 10;
		// 
		// elementlist
		// 
		this.elementlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.elementlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
						this.etab});
		this.elementlist.GridLines = true;
		this.elementlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.elementlist.HideSelection = false;
		this.elementlist.Location = new System.Drawing.Point(0, 16);
		this.elementlist.MultiSelect = false;
		this.elementlist.Name = "elementlist";
		this.elementlist.Size = new System.Drawing.Size(245, 273);
		this.elementlist.TabIndex = 2;
		this.elementlist.UseCompatibleStateImageBehavior = false;
		this.elementlist.View = System.Windows.Forms.View.Details;
		this.elementlist.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.selitemchange);
		this.elementlist.SelectedIndexChanged += new System.EventHandler(this.selecteditem);
		// 
		// etab
		// 
		this.etab.Text = "Element";
		this.etab.Width = 188;
		// 
		// toolbar
		// 
		this.toolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.toolbar.AutoSize = false;
		this.toolbar.Dock = System.Windows.Forms.DockStyle.None;
		this.toolbar.Enabled = false;
		this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
						this.menuCut,
						this.menuCopy,
						this.menuPaste,
						this.menuDel});
		this.toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.toolbar.Location = new System.Drawing.Point(0, 0);
		this.toolbar.Name = "toolbar";
		this.toolbar.Size = new System.Drawing.Size(245, 22);
		this.toolbar.TabIndex = 7;
		// 
		// menuCut
		// 
		this.menuCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuCut.Image = global::QUI.Properties.Resources.menuCut_Image;
		this.menuCut.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuCut.Name = "menuCut";
		this.menuCut.Size = new System.Drawing.Size(23, 20);
		this.menuCut.ToolTipText = "Cut";
		this.menuCut.Click += new System.EventHandler(this.cute);
		// 
		// menuCopy
		// 
		this.menuCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuCopy.Image = global::QUI.Properties.Resources.menuCopy_Image;
		this.menuCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuCopy.Name = "menuCopy";
		this.menuCopy.Size = new System.Drawing.Size(23, 20);
		this.menuCopy.ToolTipText = "Copy";
		this.menuCopy.Click += new System.EventHandler(this.copye);
		// 
		// menuPaste
		// 
		this.menuPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuPaste.Enabled = false;
		this.menuPaste.Image = global::QUI.Properties.Resources.menuPaste_Image;
		this.menuPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuPaste.Name = "menuPaste";
		this.menuPaste.Size = new System.Drawing.Size(23, 20);
		this.menuPaste.ToolTipText = "Paste";
		this.menuPaste.Click += new System.EventHandler(this.pastee);
		// 
		// menuDel
		// 
		this.menuDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuDel.Image = global::QUI.Properties.Resources.menuDel_Image;
		this.menuDel.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuDel.Name = "menuDel";
		this.menuDel.Size = new System.Drawing.Size(23, 20);
		this.menuDel.ToolTipText = "Delete";
		this.menuDel.Click += new System.EventHandler(this.dele);
		// 
		// eventsbtn
		// 
		this.eventsbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.eventsbtn.Enabled = false;
		this.eventsbtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.eventsbtn.Location = new System.Drawing.Point(35, 223);
		this.eventsbtn.Name = "eventsbtn";
		this.eventsbtn.Size = new System.Drawing.Size(207, 23);
		this.eventsbtn.TabIndex = 9;
		this.eventsbtn.Text = "Event Handlers";
		this.eventsbtn.UseVisualStyleBackColor = true;
		this.eventsbtn.Visible = false;
		// 
		// elementprops
		// 
		this.elementprops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.elementprops.Location = new System.Drawing.Point(0, 62);
		this.elementprops.Name = "elementprops";
		this.elementprops.Size = new System.Drawing.Size(245, 322);
		this.elementprops.TabIndex = 5;
		this.elementprops.ToolbarVisible = false;
		this.elementprops.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.updateProps);
		// 
		// elembtns
		// 
		this.elembtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
		this.elembtns.AutoSize = false;
		this.elembtns.Dock = System.Windows.Forms.DockStyle.None;
		this.elembtns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.elembtns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
						this.menuSprite,
						this.menuText,
						this.menuCont,
						this.menuWin,
						this.menuMenu});
		this.elembtns.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.elembtns.Location = new System.Drawing.Point(0, 22);
		this.elembtns.Name = "elembtns";
		this.elembtns.Size = new System.Drawing.Size(245, 22);
		this.elembtns.TabIndex = 8;
		// 
		// menuSprite
		// 
		this.menuSprite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuSprite.Image = global::QUI.Properties.Resources.menuSprite_Image;
		this.menuSprite.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuSprite.Name = "menuSprite";
		this.menuSprite.Size = new System.Drawing.Size(23, 20);
		this.menuSprite.ToolTipText = "Sprite";
		this.menuSprite.Click += new System.EventHandler(this.addSprite);
		// 
		// menuText
		// 
		this.menuText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuText.Image = global::QUI.Properties.Resources.menuText_Image;
		this.menuText.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuText.Name = "menuText";
		this.menuText.Size = new System.Drawing.Size(23, 20);
		this.menuText.ToolTipText = "Text";
		this.menuText.Click += new System.EventHandler(this.addText);
		// 
		// menuCont
		// 
		this.menuCont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuCont.Image = global::QUI.Properties.Resources.menuCont_Image;
		this.menuCont.ImageTransparentColor = System.Drawing.Color.White;
		this.menuCont.Name = "menuCont";
		this.menuCont.Size = new System.Drawing.Size(23, 20);
		this.menuCont.ToolTipText = "Container";
		// 
		// menuWin
		// 
		this.menuWin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuWin.Image = global::QUI.Properties.Resources.menuWin_Image;
		this.menuWin.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuWin.Name = "menuWin";
		this.menuWin.Size = new System.Drawing.Size(23, 20);
		this.menuWin.ToolTipText = "Window";
		// 
		// menuMenu
		// 
		this.menuMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.menuMenu.Image = global::QUI.Properties.Resources.menuMenu_Image;
		this.menuMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.menuMenu.Name = "menuMenu";
		this.menuMenu.Size = new System.Drawing.Size(23, 20);
		this.menuMenu.ToolTipText = "Menu";
		// 
		// propslbl
		// 
		this.propslbl.AutoSize = true;
		this.propslbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.propslbl.Location = new System.Drawing.Point(3, 44);
		this.propslbl.Name = "propslbl";
		this.propslbl.Size = new System.Drawing.Size(103, 13);
		this.propslbl.TabIndex = 6;
		this.propslbl.Text = "Properies (selected):";
		// 
		// elementdraw
		// 
		this.elementdraw.BackColor = System.Drawing.Color.Black;
		this.elementdraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.elementdraw.Dock = System.Windows.Forms.DockStyle.Fill;
		this.elementdraw.Location = new System.Drawing.Point(0, 0);
		this.elementdraw.Name = "elementdraw";
		this.elementdraw.Size = new System.Drawing.Size(652, 678);
		this.elementdraw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.elementdraw.TabIndex = 0;
		this.elementdraw.TabStop = false;
		this.elementdraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.layout_mmove);
		// 
		// menubar
		// 
		this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
						this.menuFile});
		this.menubar.Location = new System.Drawing.Point(0, 0);
		this.menubar.Name = "menubar";
		this.menubar.Size = new System.Drawing.Size(901, 24);
		this.menubar.TabIndex = 6;
		// 
		// menuFile
		// 
		this.menuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
						this.loadzBtn});
		this.menuFile.Name = "menuFile";
		this.menuFile.Size = new System.Drawing.Size(35, 20);
		this.menuFile.Text = "File";
		// 
		// loadzBtn
		// 
		this.loadzBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.loadzBtn.Name = "loadzBtn";
		this.loadzBtn.Size = new System.Drawing.Size(169, 22);
		this.loadzBtn.Text = "Load Custom Zones";
		this.loadzBtn.Click += new System.EventHandler(this.clickOpenZ);
		// 
		// zonesDiag
		// 
		this.zonesDiag.Filter = "PAK(/PAB) File|*.pab.xen;*.pak.xen;*.pab;*.pak|Any type|*.*";
		this.zonesDiag.RestoreDirectory = true;
		this.zonesDiag.SupportMultiDottedExtensions = true;
		this.zonesDiag.Title = "Open Zones/a PAK with assets";
		this.zonesDiag.FileOk += new System.ComponentModel.CancelEventHandler(this.gotz);
		// 
		// qdesign
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(901, 702);
		this.Controls.Add(this.splitter1);
		this.Controls.Add(this.menubar);
		this.Name = "qdesign";
		this.ShowIcon = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "i dont know what to name this";
		this.splitter1.Panel1.ResumeLayout(false);
		this.splitter1.Panel2.ResumeLayout(false);
		this.splitter1.ResumeLayout(false);
		this.splitter2.Panel1.ResumeLayout(false);
		this.splitter2.Panel1.PerformLayout();
		this.splitter2.Panel2.ResumeLayout(false);
		this.splitter2.Panel2.PerformLayout();
		this.splitter2.ResumeLayout(false);
		this.toolbar.ResumeLayout(false);
		this.toolbar.PerformLayout();
		this.elembtns.ResumeLayout(false);
		this.elembtns.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.elementdraw)).EndInit();
		this.menubar.ResumeLayout(false);
		this.menubar.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}
	private System.Windows.Forms.ColumnHeader etab;
	private System.Windows.Forms.OpenFileDialog zonesDiag;
	private System.Windows.Forms.ToolStripMenuItem loadzBtn;

	#endregion
	private System.Windows.Forms.Label elementtitle;
	private System.Windows.Forms.SplitContainer splitter1;
	private System.Windows.Forms.Label propslbl;
	private System.Windows.Forms.PropertyGrid elementprops;
	private System.Windows.Forms.PictureBox elementdraw;
	private System.Windows.Forms.MenuStrip menubar;
	private System.Windows.Forms.ToolStripMenuItem menuFile;
	private System.Windows.Forms.ToolStrip elembtns;
	private System.Windows.Forms.ToolStripButton menuSprite;
	private System.Windows.Forms.ToolStripButton menuText;
	private System.Windows.Forms.ToolStripButton menuCont;
	private System.Windows.Forms.ToolStripButton menuMenu;
	private System.Windows.Forms.ToolStripButton menuWin;
	private System.Windows.Forms.ToolStrip toolbar;
	private System.Windows.Forms.ToolStripButton menuCut;
	private System.Windows.Forms.ToolStripButton menuCopy;
	private System.Windows.Forms.ToolStripButton menuPaste;
	private System.Windows.Forms.ToolStripButton menuDel;
	private System.Windows.Forms.Button eventsbtn;
	private System.Windows.Forms.SplitContainer splitter2;
    private System.Windows.Forms.ListView elementlist;
}

