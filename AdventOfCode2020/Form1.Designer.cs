namespace AdventOfCode2020
{
    partial class Form1
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
            this.Button1 = new System.Windows.Forms.Button();
            this.dayNumber = new System.Windows.Forms.NumericUpDown();
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dayNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(246, 161);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(50, 22);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "RUN 1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dayNumber
            // 
            this.dayNumber.Location = new System.Drawing.Point(246, 135);
            this.dayNumber.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.dayNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dayNumber.Name = "dayNumber";
            this.dayNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dayNumber.Size = new System.Drawing.Size(47, 20);
            this.dayNumber.TabIndex = 1;
            this.dayNumber.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(12, 23);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(228, 286);
            this.inputBox.TabIndex = 2;
            this.inputBox.Text = "";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(310, 23);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(228, 286);
            this.outputBox.TabIndex = 3;
            this.outputBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "INPUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "OUTPUT";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(246, 189);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(50, 22);
            this.Button2.TabIndex = 7;
            this.Button2.Text = "RUN 2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 323);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.dayNumber);
            this.Controls.Add(this.Button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dayNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.NumericUpDown dayNumber;
        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button2;
    }
}

