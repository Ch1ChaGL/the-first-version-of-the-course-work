﻿namespace RobotFirstVersion
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
            this.Play = new System.Windows.Forms.Button();
            this.NextStep = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 642);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TextField
            // 
            this.TextField.Location = new System.Drawing.Point(671, 12);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(519, 378);
            this.TextField.TabIndex = 1;
            this.TextField.Text = "";
            this.TextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextField_KeyDown);
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(671, 418);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(103, 41);
            this.Up.TabIndex = 2;
            this.Up.Text = "Up";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(809, 418);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(103, 41);
            this.Down.TabIndex = 3;
            this.Down.Text = "Down";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Up_Click);
            // 
            // Left
            // 
            this.Left.Location = new System.Drawing.Point(955, 418);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(103, 41);
            this.Left.TabIndex = 4;
            this.Left.Text = "Left";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Up_Click);
            // 
            // Right
            // 
            this.Right.Location = new System.Drawing.Point(1087, 418);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(103, 41);
            this.Right.TabIndex = 5;
            this.Right.Text = "Right";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Up_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(671, 489);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(103, 42);
            this.Play.TabIndex = 6;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // NextStep
            // 
            this.NextStep.Location = new System.Drawing.Point(809, 489);
            this.NextStep.Name = "NextStep";
            this.NextStep.Size = new System.Drawing.Size(103, 42);
            this.NextStep.TabIndex = 7;
            this.NextStep.Text = "NextStep";
            this.NextStep.UseVisualStyleBackColor = true;
            this.NextStep.Click += new System.EventHandler(this.NextStep_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(955, 549);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(103, 42);
            this.Reset.TabIndex = 8;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(671, 549);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(103, 42);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(809, 549);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(103, 42);
            this.Copy.TabIndex = 10;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(1087, 549);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(103, 42);
            this.Clear.TabIndex = 11;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(671, 612);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(103, 42);
            this.Insert.TabIndex = 12;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 689);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.NextStep);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Down);
            this.Controls.Add(this.Up);
            this.Controls.Add(this.TextField);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox TextField;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button NextStep;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Insert;
    }
}