namespace Novel
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
            this.label1 = new System.Windows.Forms.Label();
            this.verticalSpacingText = new System.Windows.Forms.TextBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.cancle_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.fontText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundText = new System.Windows.Forms.TextBox();
            this.distanceText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "行间距";
            // 
            // verticalSpacingText
            // 
            this.verticalSpacingText.Location = new System.Drawing.Point(113, 126);
            this.verticalSpacingText.Name = "verticalSpacingText";
            this.verticalSpacingText.Size = new System.Drawing.Size(54, 21);
            this.verticalSpacingText.TabIndex = 1;
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(173, 196);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(75, 23);
            this.confirm_btn.TabIndex = 2;
            this.confirm_btn.Text = "确定";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // cancle_btn
            // 
            this.cancle_btn.Location = new System.Drawing.Point(254, 196);
            this.cancle_btn.Name = "cancle_btn";
            this.cancle_btn.Size = new System.Drawing.Size(75, 23);
            this.cancle_btn.TabIndex = 3;
            this.cancle_btn.Text = "取消";
            this.cancle_btn.UseVisualStyleBackColor = true;
            this.cancle_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(317, 94);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // fontText
            // 
            this.fontText.Location = new System.Drawing.Point(274, 126);
            this.fontText.Name = "fontText";
            this.fontText.Size = new System.Drawing.Size(55, 21);
            this.fontText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字体";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "背景";
            // 
            // backgroundText
            // 
            this.backgroundText.Location = new System.Drawing.Point(274, 158);
            this.backgroundText.Name = "backgroundText";
            this.backgroundText.Size = new System.Drawing.Size(55, 21);
            this.backgroundText.TabIndex = 8;
            // 
            // distanceText
            // 
            this.distanceText.Location = new System.Drawing.Point(112, 158);
            this.distanceText.Name = "distanceText";
            this.distanceText.Size = new System.Drawing.Size(55, 21);
            this.distanceText.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "左右间距";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 241);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.distanceText);
            this.Controls.Add(this.backgroundText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fontText);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cancle_btn);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.verticalSpacingText);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "视图设置";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox verticalSpacingText;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button cancle_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox fontText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox backgroundText;
        private System.Windows.Forms.TextBox distanceText;
        private System.Windows.Forms.Label label4;
    }
}