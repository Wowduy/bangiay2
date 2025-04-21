namespace C_CuoiKi
{
    partial class FormQLKho
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            panel1 = new Panel();
            label4 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            buttonRefresh = new Button();
            label3 = new Label();
            button3 = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            button4 = new Button();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.Location = new Point(34, 185);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(433, 311);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(643, 185);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(730, 311);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Image = Properties.Resources.download;
            button1.Location = new Point(551, 220);
            button1.Name = "button1";
            button1.Size = new Size(34, 34);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(179, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(307, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Image = Properties.Resources.OIP__2_;
            button2.Location = new Point(434, 18);
            button2.Name = "button2";
            button2.Size = new Size(75, 34);
            button2.TabIndex = 6;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(45, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 79);
            panel1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 8);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 11;
            label4.Text = "ID Kho";
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(54, 26);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 8);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 9;
            label2.Text = "Số lượng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(179, 8);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 8;
            label1.Text = "ID Sản phẩm";
            label1.Click += label1_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.AutoSize = true;
            buttonRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRefresh.Image = Properties.Resources.OIP__3_;
            buttonRefresh.Location = new Point(554, 504);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(26, 26);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Berlin Sans FB Demi", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(836, 130);
            label3.Name = "label3";
            label3.Size = new Size(270, 27);
            label3.TabIndex = 10;
            label3.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // button3
            // 
            button3.Location = new Point(216, 516);
            button3.Name = "button3";
            button3.Size = new Size(110, 35);
            button3.TabIndex = 12;
            button3.Text = "Xuất Excel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(80, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(374, 23);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(505, 282);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 14;
            label5.Text = "Thêm nguồn hàng mới";
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.Image = Properties.Resources.download;
            button4.Location = new Point(551, 300);
            button4.Name = "button4";
            button4.Size = new Size(34, 34);
            button4.TabIndex = 15;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(500, 202);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 16;
            label6.Text = "Thêm nguồn hàng đã có";
            // 
            // button5
            // 
            button5.Location = new Point(626, 79);
            button5.Name = "button5";
            button5.Size = new Size(75, 54);
            button5.TabIndex = 17;
            button5.Text = "Quay trở lại";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.AutoSize = true;
            button6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button6.Image = Properties.Resources.OIP__1_;
            button6.Location = new Point(551, 371);
            button6.Name = "button6";
            button6.Size = new Size(34, 34);
            button6.TabIndex = 18;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.AutoSize = true;
            button7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button7.Image = Properties.Resources.th__2_;
            button7.Location = new Point(551, 430);
            button7.Name = "button7";
            button7.Size = new Size(34, 34);
            button7.TabIndex = 19;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // FormQLKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1409, 586);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(buttonRefresh);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "FormQLKho";
            Text = "FormQLKho";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Panel panel1;
        private Button buttonRefresh;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private Button button3;
        private ComboBox comboBox1;
        private Label label5;
        private Button button4;
        private Label label6;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}