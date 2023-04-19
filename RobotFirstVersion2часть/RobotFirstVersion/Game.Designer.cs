namespace RobotFirstVersion
{
    partial class Game
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextField = new System.Windows.Forms.RichTextBox();
            this.Up = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Editing = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ifBtn = new System.Windows.Forms.Button();
            this.not = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.insertIf = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.upIf = new System.Windows.Forms.RadioButton();
            this.downIf = new System.Windows.Forms.RadioButton();
            this.rightIf = new System.Windows.Forms.RadioButton();
            this.leftIf = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.freeIf = new System.Windows.Forms.RadioButton();
            this.notFreeIf = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.insertWhile = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.upWhile = new System.Windows.Forms.RadioButton();
            this.downWhile = new System.Windows.Forms.RadioButton();
            this.rightWhile = new System.Windows.Forms.RadioButton();
            this.leftWhile = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.freeWhile = new System.Windows.Forms.RadioButton();
            this.notFreeWhile = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 631);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TextField
            // 
            this.TextField.AcceptsTab = true;
            this.TextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextField.Location = new System.Drawing.Point(671, 12);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(519, 458);
            this.TextField.TabIndex = 1;
            this.TextField.Text = "";
            this.TextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextField_KeyDown);
            this.TextField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextField_KeyPress);
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(747, 499);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(68, 41);
            this.Up.TabIndex = 2;
            this.Up.Text = "Up";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(747, 595);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(68, 41);
            this.Down.TabIndex = 3;
            this.Down.Text = "Down";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Up_Click);
            // 
            // Left
            // 
            this.Left.Location = new System.Drawing.Point(680, 548);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(65, 41);
            this.Left.TabIndex = 4;
            this.Left.Text = "Left";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Up_Click);
            // 
            // Right
            // 
            this.Right.Location = new System.Drawing.Point(820, 548);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(63, 41);
            this.Right.TabIndex = 5;
            this.Right.Text = "Right";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Up_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Editing,
            this.playToolStripMenuItem,
            this.nextStepToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1520, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Editing
            // 
            this.Editing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy,
            this.Delete,
            this.Clear,
            this.Reset,
            this.Insert});
            this.Editing.Name = "Editing";
            this.Editing.Size = new System.Drawing.Size(56, 20);
            this.Editing.Text = "Editing";
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(107, 22);
            this.Copy.Text = "Copy";
            this.Copy.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(107, 22);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // Clear
            // 
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(107, 22);
            this.Clear.Text = "Clear";
            this.Clear.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // Reset
            // 
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(107, 22);
            this.Reset.Text = "Reset";
            this.Reset.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // Insert
            // 
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(107, 22);
            this.Insert.Text = "Insert";
            this.Insert.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // nextStepToolStripMenuItem
            // 
            this.nextStepToolStripMenuItem.Name = "nextStepToolStripMenuItem";
            this.nextStepToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.nextStepToolStripMenuItem.Text = "NextStep";
            this.nextStepToolStripMenuItem.Click += new System.EventHandler(this.nextStepToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ifBtn
            // 
            this.ifBtn.Location = new System.Drawing.Point(917, 548);
            this.ifBtn.Name = "ifBtn";
            this.ifBtn.Size = new System.Drawing.Size(75, 41);
            this.ifBtn.TabIndex = 14;
            this.ifBtn.Text = "If";
            this.ifBtn.UseVisualStyleBackColor = true;
            this.ifBtn.Click += new System.EventHandler(this.ifBtn_Click);
            // 
            // not
            // 
            this.not.Location = new System.Drawing.Point(1020, 548);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(72, 41);
            this.not.TabIndex = 15;
            this.not.Text = "!";
            this.not.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.insertIf);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(1196, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 259);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Если";
            // 
            // insertIf
            // 
            this.insertIf.Location = new System.Drawing.Point(237, 207);
            this.insertIf.Name = "insertIf";
            this.insertIf.Size = new System.Drawing.Size(75, 23);
            this.insertIf.TabIndex = 8;
            this.insertIf.Text = "Вставить";
            this.insertIf.UseVisualStyleBackColor = true;
            this.insertIf.Click += new System.EventHandler(this.insertIf_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.upIf);
            this.groupBox3.Controls.Add(this.downIf);
            this.groupBox3.Controls.Add(this.rightIf);
            this.groupBox3.Controls.Add(this.leftIf);
            this.groupBox3.Location = new System.Drawing.Point(25, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 119);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Направление";
            // 
            // upIf
            // 
            this.upIf.AutoSize = true;
            this.upIf.Location = new System.Drawing.Point(6, 24);
            this.upIf.Name = "upIf";
            this.upIf.Size = new System.Drawing.Size(49, 17);
            this.upIf.TabIndex = 0;
            this.upIf.TabStop = true;
            this.upIf.Text = "Верх";
            this.upIf.UseVisualStyleBackColor = true;
            // 
            // downIf
            // 
            this.downIf.AutoSize = true;
            this.downIf.Location = new System.Drawing.Point(6, 47);
            this.downIf.Name = "downIf";
            this.downIf.Size = new System.Drawing.Size(45, 17);
            this.downIf.TabIndex = 1;
            this.downIf.TabStop = true;
            this.downIf.Text = "Низ";
            this.downIf.UseVisualStyleBackColor = true;
            // 
            // rightIf
            // 
            this.rightIf.AutoSize = true;
            this.rightIf.Location = new System.Drawing.Point(6, 93);
            this.rightIf.Name = "rightIf";
            this.rightIf.Size = new System.Drawing.Size(57, 17);
            this.rightIf.TabIndex = 3;
            this.rightIf.TabStop = true;
            this.rightIf.Text = "Право";
            this.rightIf.UseVisualStyleBackColor = true;
            // 
            // leftIf
            // 
            this.leftIf.AutoSize = true;
            this.leftIf.Location = new System.Drawing.Point(6, 70);
            this.leftIf.Name = "leftIf";
            this.leftIf.Size = new System.Drawing.Size(51, 17);
            this.leftIf.TabIndex = 2;
            this.leftIf.TabStop = true;
            this.leftIf.Text = "Лево";
            this.leftIf.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.freeIf);
            this.groupBox2.Controls.Add(this.notFreeIf);
            this.groupBox2.Location = new System.Drawing.Point(25, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 81);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Условие";
            // 
            // freeIf
            // 
            this.freeIf.AutoSize = true;
            this.freeIf.Location = new System.Drawing.Point(16, 24);
            this.freeIf.Name = "freeIf";
            this.freeIf.Size = new System.Drawing.Size(73, 17);
            this.freeIf.TabIndex = 4;
            this.freeIf.TabStop = true;
            this.freeIf.Text = "свободно";
            this.freeIf.UseVisualStyleBackColor = true;
            // 
            // notFreeIf
            // 
            this.notFreeIf.AutoSize = true;
            this.notFreeIf.Location = new System.Drawing.Point(16, 47);
            this.notFreeIf.Name = "notFreeIf";
            this.notFreeIf.Size = new System.Drawing.Size(90, 17);
            this.notFreeIf.TabIndex = 5;
            this.notFreeIf.TabStop = true;
            this.notFreeIf.Text = "Не свободно";
            this.notFreeIf.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.insertWhile);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(1197, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 277);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Пока";
            // 
            // insertWhile
            // 
            this.insertWhile.Location = new System.Drawing.Point(230, 215);
            this.insertWhile.Name = "insertWhile";
            this.insertWhile.Size = new System.Drawing.Size(75, 23);
            this.insertWhile.TabIndex = 9;
            this.insertWhile.Text = "Вставить";
            this.insertWhile.UseVisualStyleBackColor = true;
            this.insertWhile.Click += new System.EventHandler(this.insertWhile_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.upWhile);
            this.groupBox6.Controls.Add(this.downWhile);
            this.groupBox6.Controls.Add(this.rightWhile);
            this.groupBox6.Controls.Add(this.leftWhile);
            this.groupBox6.Location = new System.Drawing.Point(24, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(195, 119);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Направление";
            // 
            // upWhile
            // 
            this.upWhile.AutoSize = true;
            this.upWhile.Location = new System.Drawing.Point(6, 24);
            this.upWhile.Name = "upWhile";
            this.upWhile.Size = new System.Drawing.Size(49, 17);
            this.upWhile.TabIndex = 0;
            this.upWhile.TabStop = true;
            this.upWhile.Text = "Верх";
            this.upWhile.UseVisualStyleBackColor = true;
            // 
            // downWhile
            // 
            this.downWhile.AutoSize = true;
            this.downWhile.Location = new System.Drawing.Point(6, 47);
            this.downWhile.Name = "downWhile";
            this.downWhile.Size = new System.Drawing.Size(45, 17);
            this.downWhile.TabIndex = 1;
            this.downWhile.TabStop = true;
            this.downWhile.Text = "Низ";
            this.downWhile.UseVisualStyleBackColor = true;
            // 
            // rightWhile
            // 
            this.rightWhile.AutoSize = true;
            this.rightWhile.Location = new System.Drawing.Point(6, 93);
            this.rightWhile.Name = "rightWhile";
            this.rightWhile.Size = new System.Drawing.Size(57, 17);
            this.rightWhile.TabIndex = 3;
            this.rightWhile.TabStop = true;
            this.rightWhile.Text = "Право";
            this.rightWhile.UseVisualStyleBackColor = true;
            // 
            // leftWhile
            // 
            this.leftWhile.AutoSize = true;
            this.leftWhile.Location = new System.Drawing.Point(6, 70);
            this.leftWhile.Name = "leftWhile";
            this.leftWhile.Size = new System.Drawing.Size(51, 17);
            this.leftWhile.TabIndex = 2;
            this.leftWhile.TabStop = true;
            this.leftWhile.Text = "Лево";
            this.leftWhile.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.freeWhile);
            this.groupBox5.Controls.Add(this.notFreeWhile);
            this.groupBox5.Location = new System.Drawing.Point(24, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(195, 81);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Условие";
            // 
            // freeWhile
            // 
            this.freeWhile.AutoSize = true;
            this.freeWhile.Location = new System.Drawing.Point(16, 24);
            this.freeWhile.Name = "freeWhile";
            this.freeWhile.Size = new System.Drawing.Size(73, 17);
            this.freeWhile.TabIndex = 4;
            this.freeWhile.TabStop = true;
            this.freeWhile.Text = "свободно";
            this.freeWhile.UseVisualStyleBackColor = true;
            // 
            // notFreeWhile
            // 
            this.notFreeWhile.AutoSize = true;
            this.notFreeWhile.Location = new System.Drawing.Point(16, 47);
            this.notFreeWhile.Name = "notFreeWhile";
            this.notFreeWhile.Size = new System.Drawing.Size(90, 17);
            this.notFreeWhile.TabIndex = 5;
            this.notFreeWhile.TabStop = true;
            this.notFreeWhile.Text = "Не свободно";
            this.notFreeWhile.UseVisualStyleBackColor = true;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 689);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.not);
            this.Controls.Add(this.ifBtn);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox TextField;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Editing;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private System.Windows.Forms.ToolStripMenuItem Reset;
        private System.Windows.Forms.ToolStripMenuItem Insert;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ifBtn;
        private System.Windows.Forms.Button not;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button insertIf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton upIf;
        private System.Windows.Forms.RadioButton downIf;
        private System.Windows.Forms.RadioButton rightIf;
        private System.Windows.Forms.RadioButton leftIf;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton freeIf;
        private System.Windows.Forms.RadioButton notFreeIf;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button insertWhile;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton upWhile;
        private System.Windows.Forms.RadioButton downWhile;
        private System.Windows.Forms.RadioButton rightWhile;
        private System.Windows.Forms.RadioButton leftWhile;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton freeWhile;
        private System.Windows.Forms.RadioButton notFreeWhile;
    }
}