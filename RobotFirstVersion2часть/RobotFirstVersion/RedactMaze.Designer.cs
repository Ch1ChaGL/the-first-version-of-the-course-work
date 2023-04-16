namespace RobotFirstVersion
{
    partial class RedactMaze
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
            this.back = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start = new System.Windows.Forms.RadioButton();
            this.exit = new System.Windows.Forms.RadioButton();
            this.cell = new System.Windows.Forms.RadioButton();
            this.wall = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 523);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(692, 469);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(241, 57);
            this.back.TabIndex = 9;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(692, 310);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(241, 54);
            this.save.TabIndex = 8;
            this.save.Text = "Изменить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.exit);
            this.groupBox1.Controls.Add(this.cell);
            this.groupBox1.Controls.Add(this.wall);
            this.groupBox1.Location = new System.Drawing.Point(692, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 255);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование";
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
            // RedactMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 547);
            this.Controls.Add(this.back);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RedactMaze";
            this.Text = "RedactMaze";
            this.Load += new System.EventHandler(this.RedactMaze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton start;
        private System.Windows.Forms.RadioButton exit;
        private System.Windows.Forms.RadioButton cell;
        private System.Windows.Forms.RadioButton wall;
    }
}