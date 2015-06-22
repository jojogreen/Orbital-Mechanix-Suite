namespace Orbital_Mechanix_Suite
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.day_numeric = new System.Windows.Forms.NumericUpDown();
            this.output_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.day_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(63, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // day_numeric
            // 
            this.day_numeric.Location = new System.Drawing.Point(210, 46);
            this.day_numeric.Name = "day_numeric";
            this.day_numeric.Size = new System.Drawing.Size(120, 20);
            this.day_numeric.TabIndex = 1;
            // 
            // output_label
            // 
            this.output_label.AutoSize = true;
            this.output_label.Location = new System.Drawing.Point(473, 137);
            this.output_label.Name = "output_label";
            this.output_label.Size = new System.Drawing.Size(35, 13);
            this.output_label.TabIndex = 2;
            this.output_label.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 405);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output_label);
            this.Controls.Add(this.day_numeric);
            this.Controls.Add(this.comboBox1);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "Form1";
            this.Text = "Orbital Mechanix Suite";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.day_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown day_numeric;
        private System.Windows.Forms.Label output_label;
        private System.Windows.Forms.Button button1;
    }
}

