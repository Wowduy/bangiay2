namespace quanlibangiay2
{
    partial class quenmatkhau
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
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            labelResult = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.Location = new Point(63, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 234);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.vecteezy_creative_abstract_black_silhouette_running_shoe_design_logo_8956590;
            pictureBox1.Location = new Point(3, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(298, 210);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.BackColor = SystemColors.HighlightText;
            labelResult.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            labelResult.Location = new Point(135, 368);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(153, 17);
            labelResult.TabIndex = 1;
            labelResult.Text = "-----------------------------";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBox1.Location = new Point(183, 324);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 25);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            button1.Location = new Point(77, 406);
            button1.Name = "button1";
            button1.Size = new Size(127, 50);
            button1.TabIndex = 4;
            button1.Text = "Lấy lại mật khẩu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            button2.Location = new Point(261, 406);
            button2.Name = "button2";
            button2.Size = new Size(103, 50);
            button2.TabIndex = 5;
            button2.Text = "Đăng nhập";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(123, 26);
            label2.Name = "label2";
            label2.Size = new Size(200, 28);
            label2.TabIndex = 6;
            label2.Text = "QUÊN MẬT KHẨU";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(63, 327);
            label1.Name = "label1";
            label1.Size = new Size(106, 17);
            label1.TabIndex = 7;
            label1.Text = "Nhập Username";
            // 
            // quenmatkhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 491);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(labelResult);
            Controls.Add(groupBox1);
            Name = "quenmatkhau";
            Text = "quenmatkhau";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label labelResult;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label1;
    }
}