namespace Game
{
    partial class MineSweeperForm
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
            this.start = new System.Windows.Forms.Button();
            this.gameSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.newGame = new System.Windows.Forms.Button();
            this.Mine_label = new System.Windows.Forms.Label();
            this.numberOfMines = new System.Windows.Forms.TextBox();
            this.timeText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(245, 41);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 3;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // gameSize
            // 
            this.gameSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameSize.FormattingEnabled = true;
            this.gameSize.Location = new System.Drawing.Point(48, 9);
            this.gameSize.Name = "gameSize";
            this.gameSize.Size = new System.Drawing.Size(75, 21);
            this.gameSize.TabIndex = 5;
            this.gameSize.SelectedIndexChanged += new System.EventHandler(this.gameSize_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Time:";
            // 
            // newGame
            // 
            this.newGame.Location = new System.Drawing.Point(131, 374);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(75, 32);
            this.newGame.TabIndex = 8;
            this.newGame.Text = "New Game";
            this.newGame.UseVisualStyleBackColor = true;
            this.newGame.Click += new System.EventHandler(this.newGame_Click_1);
            // 
            // Mine_label
            // 
            this.Mine_label.AutoSize = true;
            this.Mine_label.Location = new System.Drawing.Point(202, 13);
            this.Mine_label.Name = "Mine_label";
            this.Mine_label.Size = new System.Drawing.Size(35, 13);
            this.Mine_label.TabIndex = 11;
            this.Mine_label.Text = "Mines";
            // 
            // numberOfMines
            // 
            this.numberOfMines.Location = new System.Drawing.Point(243, 10);
            this.numberOfMines.Name = "numberOfMines";
            this.numberOfMines.Size = new System.Drawing.Size(77, 20);
            this.numberOfMines.TabIndex = 12;
            // 
            // timeText
            // 
            this.timeText.AutoSize = true;
            this.timeText.Location = new System.Drawing.Point(90, 50);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(0, 13);
            this.timeText.TabIndex = 13;
            // 
            // GameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 418);
            this.Controls.Add(this.timeText);
            this.Controls.Add(this.numberOfMines);
            this.Controls.Add(this.Mine_label);
            this.Controls.Add(this.newGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameSize);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameUI";
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ComboBox gameSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Label Mine_label;
        private System.Windows.Forms.TextBox numberOfMines;
        private System.Windows.Forms.Label timeText;
    }
}

