
namespace MagicMaze
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.ActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebuildMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneWindow = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.FindExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.GripMargin = new System.Windows.Forms.Padding(2);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionMenuItem,
            this.DetailMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.menu.Size = new System.Drawing.Size(600, 24);
            this.menu.TabIndex = 0;
            // 
            // ActionMenuItem
            // 
            this.ActionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RebuildMenuItem,
            this.FindExitMenuItem});
            this.ActionMenuItem.Name = "ActionMenuItem";
            this.ActionMenuItem.Size = new System.Drawing.Size(70, 24);
            this.ActionMenuItem.Text = "Действия";
            // 
            // RebuildMenuItem
            // 
            this.RebuildMenuItem.Name = "RebuildMenuItem";
            this.RebuildMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RebuildMenuItem.Text = "Пересоздать";
            this.RebuildMenuItem.Click += new System.EventHandler(this.RebuildMenuItem_Click);
            // 
            // DetailMenuItem
            // 
            this.DetailMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuItem,
            this.ContactMenuItem});
            this.DetailMenuItem.Name = "DetailMenuItem";
            this.DetailMenuItem.Size = new System.Drawing.Size(94, 24);
            this.DetailMenuItem.Text = "О программе";
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(162, 22);
            this.HelpMenuItem.Text = "Справка";
            // 
            // ContactMenuItem
            // 
            this.ContactMenuItem.Name = "ContactMenuItem";
            this.ContactMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ContactMenuItem.Text = "О разработчике";
            // 
            // sceneWindow
            // 
            this.sceneWindow.AccumBits = ((byte)(0));
            this.sceneWindow.AutoCheckErrors = false;
            this.sceneWindow.AutoFinish = false;
            this.sceneWindow.AutoMakeCurrent = true;
            this.sceneWindow.AutoSwapBuffers = true;
            this.sceneWindow.BackColor = System.Drawing.Color.Black;
            this.sceneWindow.ColorBits = ((byte)(32));
            this.sceneWindow.DepthBits = ((byte)(16));
            this.sceneWindow.Location = new System.Drawing.Point(0, 27);
            this.sceneWindow.Name = "sceneWindow";
            this.sceneWindow.Size = new System.Drawing.Size(600, 600);
            this.sceneWindow.StencilBits = ((byte)(0));
            this.sceneWindow.TabIndex = 1;
            this.sceneWindow.Load += new System.EventHandler(this.SceneWindow_Load);
            this.sceneWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SceneWindow_KeyDown);
            // 
            // findExitMenuItem
            // 
            this.FindExitMenuItem.Name = "FindExitMenuItem";
            this.FindExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FindExitMenuItem.Text = "Найти выход";
            this.FindExitMenuItem.Click += new System.EventHandler(this.FindExitMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 627);
            this.Controls.Add(this.sceneWindow);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.Text = "Game: Magis Maze";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem DetailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContactMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RebuildMenuItem;
        private Tao.Platform.Windows.SimpleOpenGlControl sceneWindow;
        private System.Windows.Forms.ToolStripMenuItem FindExitMenuItem;
    }
}

