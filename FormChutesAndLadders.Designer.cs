namespace PR_05b___Chutes___Ladders
{
    partial class FormChutesAndLadders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChutesAndLadders));
            this.menuStripGame = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxGameBoard = new System.Windows.Forms.PictureBox();
            this.listBoxTurnLog = new System.Windows.Forms.ListBox();
            this.buttonTurn = new System.Windows.Forms.Button();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.toolStripSeparatorBetweenNewGameAndeXit = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripGame
            // 
            this.menuStripGame.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripGame.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStripGame.Size = new System.Drawing.Size(563, 36);
            this.menuStripGame.TabIndex = 0;
            this.menuStripGame.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparatorBetweenNewGameAndeXit,
            this.eXitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // eXitToolStripMenuItem
            // 
            this.eXitToolStripMenuItem.Name = "eXitToolStripMenuItem";
            this.eXitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.eXitToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.eXitToolStripMenuItem.Text = "eXit";
            this.eXitToolStripMenuItem.Click += new System.EventHandler(this.eXitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameInstructionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gameInstructionsToolStripMenuItem
            // 
            this.gameInstructionsToolStripMenuItem.Name = "gameInstructionsToolStripMenuItem";
            this.gameInstructionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.gameInstructionsToolStripMenuItem.Size = new System.Drawing.Size(366, 40);
            this.gameInstructionsToolStripMenuItem.Text = "Game Instructions";
            this.gameInstructionsToolStripMenuItem.Click += new System.EventHandler(this.gameInstructionsToolStripMenuItem_Click);
            // 
            // pictureBoxGameBoard
            // 
            this.pictureBoxGameBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGameBoard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGameBoard.Image")));
            this.pictureBoxGameBoard.Location = new System.Drawing.Point(0, 27);
            this.pictureBoxGameBoard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxGameBoard.Name = "pictureBoxGameBoard";
            this.pictureBoxGameBoard.Size = new System.Drawing.Size(302, 308);
            this.pictureBoxGameBoard.TabIndex = 1;
            this.pictureBoxGameBoard.TabStop = false;
            // 
            // listBoxTurnLog
            // 
            this.listBoxTurnLog.FormattingEnabled = true;
            this.listBoxTurnLog.Location = new System.Drawing.Point(305, 41);
            this.listBoxTurnLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxTurnLog.Name = "listBoxTurnLog";
            this.listBoxTurnLog.Size = new System.Drawing.Size(190, 290);
            this.listBoxTurnLog.TabIndex = 2;
            // 
            // buttonTurn
            // 
            this.buttonTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTurn.Location = new System.Drawing.Point(495, 41);
            this.buttonTurn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTurn.Name = "buttonTurn";
            this.buttonTurn.Size = new System.Drawing.Size(64, 30);
            this.buttonTurn.TabIndex = 3;
            this.buttonTurn.Text = "Turn";
            this.buttonTurn.UseVisualStyleBackColor = true;
            this.buttonTurn.Click += new System.EventHandler(this.buttonTurn_Click);
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(495, 93);
            this.comboBoxPlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(68, 21);
            this.comboBoxPlayers.TabIndex = 4;
            this.comboBoxPlayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayers_SelectedIndexChanged);
            // 
            // toolStripSeparatorBetweenNewGameAndeXit
            // 
            this.toolStripSeparatorBetweenNewGameAndeXit.Name = "toolStripSeparatorBetweenNewGameAndeXit";
            this.toolStripSeparatorBetweenNewGameAndeXit.Size = new System.Drawing.Size(312, 6);
            // 
            // FormChutesAndLadders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 350);
            this.Controls.Add(this.comboBoxPlayers);
            this.Controls.Add(this.buttonTurn);
            this.Controls.Add(this.listBoxTurnLog);
            this.Controls.Add(this.pictureBoxGameBoard);
            this.Controls.Add(this.menuStripGame);
            this.MainMenuStrip = this.menuStripGame;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormChutesAndLadders";
            this.Text = "Chutes & Ladders";
            this.Load += new System.EventHandler(this.FormChutesAndLadders_Load);
            this.menuStripGame.ResumeLayout(false);
            this.menuStripGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripGame;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameInstructionsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxGameBoard;
        private System.Windows.Forms.ListBox listBoxTurnLog;
        private System.Windows.Forms.Button buttonTurn;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
        private System.Windows.Forms.ToolStripMenuItem eXitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorBetweenNewGameAndeXit;
    }
}

