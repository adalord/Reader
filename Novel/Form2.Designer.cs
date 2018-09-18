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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.verticalSpacingText = new System.Windows.Forms.TextBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.cancle_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.distanceText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fontBtn = new System.Windows.Forms.Button();
            this.backColorBtn = new System.Windows.Forms.Button();
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
            this.verticalSpacingText.TextChanged += new System.EventHandler(this.verticalSpacingText_TextChanged);
            this.verticalSpacingText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verticalSpacingText_KeyPress);
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
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
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
            // fontBtn
            // 
            this.fontBtn.Location = new System.Drawing.Point(241, 129);
            this.fontBtn.Name = "fontBtn";
            this.fontBtn.Size = new System.Drawing.Size(88, 23);
            this.fontBtn.TabIndex = 11;
            this.fontBtn.Text = "字体";
            this.fontBtn.UseVisualStyleBackColor = true;
            this.fontBtn.Click += new System.EventHandler(this.fontbtn_Click);
            // 
            // backColorBtn
            // 
            this.backColorBtn.Location = new System.Drawing.Point(241, 161);
            this.backColorBtn.Name = "backColorBtn";
            this.backColorBtn.Size = new System.Drawing.Size(88, 23);
            this.backColorBtn.TabIndex = 12;
            this.backColorBtn.Text = "背景";
            this.backColorBtn.UseVisualStyleBackColor = true;
            this.backColorBtn.Click += new System.EventHandler(this.backColorBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 241);
            this.Controls.Add(this.backColorBtn);
            this.Controls.Add(this.fontBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.distanceText);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cancle_btn);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.verticalSpacingText);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "视图设置";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox verticalSpacingText;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button cancle_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox distanceText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button fontBtn;
        private System.Windows.Forms.Button backColorBtn;
    }
}