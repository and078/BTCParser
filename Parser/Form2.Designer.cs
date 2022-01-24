
namespace Parser
{
    partial class Form2
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
            this.ParseButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.URLtextBox = new System.Windows.Forms.TextBox();
            this.PrefixtextBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TagtextBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassNametextBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ParseButton1
            // 
            this.ParseButton1.Location = new System.Drawing.Point(142, 311);
            this.ParseButton1.Name = "ParseButton1";
            this.ParseButton1.Size = new System.Drawing.Size(160, 51);
            this.ParseButton1.TabIndex = 0;
            this.ParseButton1.Text = "Parse";
            this.ParseButton1.UseVisualStyleBackColor = true;
            this.ParseButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // URLtextBox
            // 
            this.URLtextBox.Location = new System.Drawing.Point(12, 50);
            this.URLtextBox.Name = "URLtextBox";
            this.URLtextBox.Size = new System.Drawing.Size(417, 23);
            this.URLtextBox.TabIndex = 2;
            // 
            // PrefixtextBox2
            // 
            this.PrefixtextBox2.Location = new System.Drawing.Point(12, 117);
            this.PrefixtextBox2.Name = "PrefixtextBox2";
            this.PrefixtextBox2.Size = new System.Drawing.Size(417, 23);
            this.PrefixtextBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prefix";
            // 
            // TagtextBox3
            // 
            this.TagtextBox3.Location = new System.Drawing.Point(12, 186);
            this.TagtextBox3.Name = "TagtextBox3";
            this.TagtextBox3.Size = new System.Drawing.Size(417, 23);
            this.TagtextBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tag";
            // 
            // ClassNametextBox4
            // 
            this.ClassNametextBox4.Location = new System.Drawing.Point(12, 253);
            this.ClassNametextBox4.Name = "ClassNametextBox4";
            this.ClassNametextBox4.Size = new System.Drawing.Size(417, 23);
            this.ClassNametextBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class Name";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(446, 416);
            this.Controls.Add(this.ClassNametextBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TagtextBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrefixtextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.URLtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParseButton1);
            this.Location = new System.Drawing.Point(700, 200);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ParseButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox URLtextBox;
        private System.Windows.Forms.TextBox PrefixtextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TagtextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClassNametextBox4;
        private System.Windows.Forms.Label label4;
    }
}