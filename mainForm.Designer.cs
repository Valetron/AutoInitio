
namespace AutoInitio
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node5");
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonFolder = new System.Windows.Forms.Button();
            this.buttonScheduler = new System.Windows.Forms.Button();
            this.buttonRegistry = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFolderOpen = new System.Windows.Forms.Button();
            this.buttonSchedulerOpen = new System.Windows.Forms.Button();
            this.buttonRegistryOpen = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconTray.BalloonTipText = "Icon_Text";
            this.notifyIconTray.BalloonTipTitle = "Icon_Title";
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Autoinitio";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseClick);
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(12, 12);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(115, 50);
            this.buttonFolder.TabIndex = 1;
            this.buttonFolder.Text = "Папка автозагрузки";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // buttonScheduler
            // 
            this.buttonScheduler.Location = new System.Drawing.Point(12, 125);
            this.buttonScheduler.Name = "buttonScheduler";
            this.buttonScheduler.Size = new System.Drawing.Size(115, 50);
            this.buttonScheduler.TabIndex = 2;
            this.buttonScheduler.Text = "Планировщик заданий";
            this.buttonScheduler.UseVisualStyleBackColor = true;
            this.buttonScheduler.Click += new System.EventHandler(this.buttonScheduler_Click);
            // 
            // buttonRegistry
            // 
            this.buttonRegistry.Location = new System.Drawing.Point(12, 237);
            this.buttonRegistry.Name = "buttonRegistry";
            this.buttonRegistry.Size = new System.Drawing.Size(115, 50);
            this.buttonRegistry.TabIndex = 3;
            this.buttonRegistry.Text = "Реестр";
            this.buttonRegistry.UseVisualStyleBackColor = true;
            this.buttonRegistry.Click += new System.EventHandler(this.buttonRegistry_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(139, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(626, 400);
            this.panelMain.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 418);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(822, 213);
            this.textBox1.TabIndex = 0;
            // 
            // buttonFolderOpen
            // 
            this.buttonFolderOpen.Location = new System.Drawing.Point(12, 69);
            this.buttonFolderOpen.Name = "buttonFolderOpen";
            this.buttonFolderOpen.Size = new System.Drawing.Size(115, 30);
            this.buttonFolderOpen.TabIndex = 5;
            this.buttonFolderOpen.Text = "Открыть";
            this.buttonFolderOpen.UseVisualStyleBackColor = true;
            this.buttonFolderOpen.Click += new System.EventHandler(this.buttonFolderOpen_Click);
            // 
            // buttonSchedulerOpen
            // 
            this.buttonSchedulerOpen.Location = new System.Drawing.Point(12, 181);
            this.buttonSchedulerOpen.Name = "buttonSchedulerOpen";
            this.buttonSchedulerOpen.Size = new System.Drawing.Size(115, 30);
            this.buttonSchedulerOpen.TabIndex = 6;
            this.buttonSchedulerOpen.Text = "Открыть";
            this.buttonSchedulerOpen.UseVisualStyleBackColor = true;
            this.buttonSchedulerOpen.Click += new System.EventHandler(this.buttonSchedulerOpen_Click);
            // 
            // buttonRegistryOpen
            // 
            this.buttonRegistryOpen.Location = new System.Drawing.Point(12, 293);
            this.buttonRegistryOpen.Name = "buttonRegistryOpen";
            this.buttonRegistryOpen.Size = new System.Drawing.Size(115, 30);
            this.buttonRegistryOpen.TabIndex = 7;
            this.buttonRegistryOpen.Text = "Открыть";
            this.buttonRegistryOpen.UseVisualStyleBackColor = true;
            this.buttonRegistryOpen.Click += new System.EventHandler(this.buttonRegistryOpen_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(713, 293);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "Node1";
            treeNode7.Text = "Node1";
            treeNode8.Name = "Node2";
            treeNode8.Text = "Node2";
            treeNode9.Name = "Node0";
            treeNode9.Text = "Node0";
            treeNode10.Name = "Node4";
            treeNode10.Text = "Node4";
            treeNode11.Name = "Node3";
            treeNode11.Text = "Node3";
            treeNode12.Name = "Node5";
            treeNode12.Text = "Node5";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11,
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 8;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(846, 643);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonRegistryOpen);
            this.Controls.Add(this.buttonSchedulerOpen);
            this.Controls.Add(this.buttonFolderOpen);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.buttonRegistry);
            this.Controls.Add(this.buttonScheduler);
            this.Controls.Add(this.buttonFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoInitio";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Button buttonScheduler;
        private System.Windows.Forms.Button buttonRegistry;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFolderOpen;
        private System.Windows.Forms.Button buttonSchedulerOpen;
        private System.Windows.Forms.Button buttonRegistryOpen;
        private System.Windows.Forms.TreeView treeView1;
    }
}

