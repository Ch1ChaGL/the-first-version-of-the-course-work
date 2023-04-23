namespace RobotFirstVersion
{
    partial class CreateMaze
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
            this.sizeMazeNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wall = new System.Windows.Forms.RadioButton();
            this.cell = new System.Windows.Forms.RadioButton();
            this.exit = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.RadioButton();
            this.save = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeMazeNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(168, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sizeMazeNumeric
            // 
            this.sizeMazeNumeric.Location = new System.Drawing.Point(12, 44);
            this.sizeMazeNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sizeMazeNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sizeMazeNumeric.Name = "sizeMazeNumeric";
            this.sizeMazeNumeric.Size = new System.Drawing.Size(120, 20);
            this.sizeMazeNumeric.TabIndex = 1;
            this.sizeMazeNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sizeMazeNumeric.ValueChanged += new System.EventHandler(this.sizeMazeNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Размер карты";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.exit);
            this.groupBox1.Controls.Add(this.cell);
            this.groupBox1.Controls.Add(this.wall);
            this.groupBox1.Location = new System.Drawing.Point(757, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 255);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование";
            // 
            // wall
            // 
            this.wall.AutoSize = true;
            this.wall.Location = new System.Drawing.Point(7, 34);
            this.wall.Name = "wall";
            this.wall.Size = new System.Drawing.Size(58, 17);
            this.wall.TabIndex = 0;
            this.wall.TabStop = true;
            this.wall.Text = "Стена ";
            this.wall.UseVisualStyleBackColor = true;
            // 
            // cell
            // 
            this.cell.AutoSize = true;
            this.cell.Location = new System.Drawing.Point(6, 57);
            this.cell.Name = "cell";
            this.cell.Size = new System.Drawing.Size(62, 17);
            this.cell.TabIndex = 1;
            this.cell.TabStop = true;
            this.cell.Text = "Ячейка";
            this.cell.UseVisualStyleBackColor = true;
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Location = new System.Drawing.Point(7, 80);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(57, 17);
            this.exit.TabIndex = 2;
            this.exit.TabStop = true;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Location = new System.Drawing.Point(6, 103);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(55, 17);
            this.start.TabIndex = 3;
            this.start.TabStop = true;
            this.start.Text = "Робот";
            this.start.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(757, 357);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(241, 54);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(757, 469);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(241, 57);
            this.back.TabIndex = 5;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(757, 314);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 6;
            // 
            // CreateMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 581);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeMazeNumeric);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CreateMaze";
            this.Text = "CreateMaze";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateMaze_FormClosing);
            this.Load += new System.EventHandler(this.CreateMaze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeMazeNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown sizeMazeNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton start;
        private System.Windows.Forms.RadioButton exit;
        private System.Windows.Forms.RadioButton cell;
        private System.Windows.Forms.RadioButton wall;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox textBox1;
    }
}