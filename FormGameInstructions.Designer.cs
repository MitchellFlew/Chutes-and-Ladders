namespace PR_05b___Chutes___Ladders
{
    partial class FormGameInstructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameInstructions));
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelHowToPlay = new System.Windows.Forms.Label();
            this.labelObjective = new System.Windows.Forms.Label();
            this.labelHowToWin = new System.Windows.Forms.Label();
            this.labelExitMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Lucida Calligraphy", 26.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(7, 7);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(423, 69);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Chutes and Ladders";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHowToPlay
            // 
            this.labelHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHowToPlay.Location = new System.Drawing.Point(91, 76);
            this.labelHowToPlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHowToPlay.Name = "labelHowToPlay";
            this.labelHowToPlay.Size = new System.Drawing.Size(226, 131);
            this.labelHowToPlay.TabIndex = 1;
            this.labelHowToPlay.Text = resources.GetString("labelHowToPlay.Text");
            // 
            // labelObjective
            // 
            this.labelObjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObjective.Location = new System.Drawing.Point(7, 76);
            this.labelObjective.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelObjective.Name = "labelObjective";
            this.labelObjective.Size = new System.Drawing.Size(81, 162);
            this.labelObjective.TabIndex = 2;
            this.labelObjective.Text = "OBJECTIVE\r\n\r\n- Be the first player to reach space #100 navigating through the gam" +
    "e board\r\n";
            // 
            // labelHowToWin
            // 
            this.labelHowToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHowToWin.Location = new System.Drawing.Point(320, 73);
            this.labelHowToWin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHowToWin.Name = "labelHowToWin";
            this.labelHowToWin.Size = new System.Drawing.Size(110, 162);
            this.labelHowToWin.TabIndex = 3;
            this.labelHowToWin.Text = "WINNING\r\n\r\n- a player wins if they land on space #100. \r\n- However, you must land" +
    " exactly on 100, if you roll and exceed the number, you stay where you are when " +
    "you rolled the dice";
            // 
            // labelExitMessage
            // 
            this.labelExitMessage.Location = new System.Drawing.Point(7, 207);
            this.labelExitMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExitMessage.Name = "labelExitMessage";
            this.labelExitMessage.Size = new System.Drawing.Size(423, 31);
            this.labelExitMessage.TabIndex = 4;
            this.labelExitMessage.Text = "Click \"X\" to exit out of instructions menu.";
            // 
            // FormGameInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 236);
            this.Controls.Add(this.labelExitMessage);
            this.Controls.Add(this.labelHowToWin);
            this.Controls.Add(this.labelObjective);
            this.Controls.Add(this.labelHowToPlay);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormGameInstructions";
            this.Text = "FormGameInstructions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelHowToPlay;
        private System.Windows.Forms.Label labelObjective;
        private System.Windows.Forms.Label labelHowToWin;
        private System.Windows.Forms.Label labelExitMessage;
    }
}