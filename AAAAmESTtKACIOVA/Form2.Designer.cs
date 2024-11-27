namespace AAAAmESTtKACIOVA
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
            this.backButton = new System.Windows.Forms.Button();
            this.goodsButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(621, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(124, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Вернуться";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // goodsButton
            // 
            this.goodsButton.Location = new System.Drawing.Point(40, 415);
            this.goodsButton.Name = "goodsButton";
            this.goodsButton.Size = new System.Drawing.Size(75, 23);
            this.goodsButton.TabIndex = 2;
            this.goodsButton.Text = "Товары";
            this.goodsButton.UseMnemonic = false;
            this.goodsButton.UseVisualStyleBackColor = true;
            this.goodsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(165, 415);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(108, 23);
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Сортировка";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(53, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(677, 340);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.goodsButton);
            this.Controls.Add(this.backButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button goodsButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}