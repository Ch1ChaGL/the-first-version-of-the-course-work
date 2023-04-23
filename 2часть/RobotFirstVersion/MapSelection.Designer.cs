namespace RobotFirstVersion
{
    partial class MapSelection
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
            this.map1 = new System.Windows.Forms.PictureBox();
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.NameMaze = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.map1)).BeginInit();
            this.SuspendLayout();
            // 
            // map1
            // 
            this.map1.Location = new System.Drawing.Point(274, 12);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(546, 509);
            this.map1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.map1.TabIndex = 0;
            this.map1.TabStop = false;
            this.map1.Click += new System.EventHandler(this.map1_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(630, 541);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(190, 97);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(274, 541);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(190, 97);
            this.Previous.TabIndex = 2;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(471, 541);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(153, 97);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // NameMaze
            // 
            this.NameMaze.AutoSize = true;
            this.NameMaze.Location = new System.Drawing.Point(28, 85);
            this.NameMaze.Name = "NameMaze";
            this.NameMaze.Size = new System.Drawing.Size(0, 13);
            this.NameMaze.TabIndex = 4;
            // 
            // MapSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 678);
            this.Controls.Add(this.NameMaze);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.map1);
            this.Name = "MapSelection";
            this.Text = "MapSelection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapSelection_FormClosing);
            this.Load += new System.EventHandler(this.MapSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.map1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox map1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label NameMaze;
    }
}