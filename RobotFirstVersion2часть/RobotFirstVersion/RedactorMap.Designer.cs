namespace RobotFirstVersion
{
    partial class RedactorMap
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
            this.DeleteMap = new System.Windows.Forms.Button();
            this.RedactMap = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.CreateMazeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(199, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 481);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DeleteMap
            // 
            this.DeleteMap.Location = new System.Drawing.Point(199, 526);
            this.DeleteMap.Name = "DeleteMap";
            this.DeleteMap.Size = new System.Drawing.Size(108, 62);
            this.DeleteMap.TabIndex = 1;
            this.DeleteMap.Text = "Удалить карту";
            this.DeleteMap.UseVisualStyleBackColor = true;
            this.DeleteMap.Click += new System.EventHandler(this.DeleteMap_Click);
            // 
            // RedactMap
            // 
            this.RedactMap.Location = new System.Drawing.Point(413, 526);
            this.RedactMap.Name = "RedactMap";
            this.RedactMap.Size = new System.Drawing.Size(105, 62);
            this.RedactMap.TabIndex = 2;
            this.RedactMap.Text = "Редактировать карту";
            this.RedactMap.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(766, 260);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(110, 62);
            this.Next.TabIndex = 4;
            this.Next.Text = "Вперед";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Back_Click_1);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(63, 235);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(103, 61);
            this.Back.TabIndex = 5;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click_1);
            // 
            // CreateMazeBtn
            // 
            this.CreateMazeBtn.Location = new System.Drawing.Point(632, 526);
            this.CreateMazeBtn.Name = "CreateMazeBtn";
            this.CreateMazeBtn.Size = new System.Drawing.Size(103, 62);
            this.CreateMazeBtn.TabIndex = 6;
            this.CreateMazeBtn.Text = "Создать карту";
            this.CreateMazeBtn.UseVisualStyleBackColor = true;
            this.CreateMazeBtn.Click += new System.EventHandler(this.CreateMazeBtn_Click);
            // 
            // RedactorMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 621);
            this.Controls.Add(this.CreateMazeBtn);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.RedactMap);
            this.Controls.Add(this.DeleteMap);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RedactorMap";
            this.Text = "RedactorMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RedactorMap_FormClosing);
            this.Load += new System.EventHandler(this.RedactorMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DeleteMap;
        private System.Windows.Forms.Button RedactMap;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button CreateMazeBtn;
    }
}