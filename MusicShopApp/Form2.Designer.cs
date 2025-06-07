namespace MusicShopApp
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
            label1 = new Label();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button7 = new Button();
            button8 = new Button();
            button6 = new Button();
            button5 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(121, 20);
            label1.Name = "label1";
            label1.Size = new Size(122, 28);
            label1.TabIndex = 0;
            label1.Text = "Инструмент";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button3
            // 
            button3.BackColor = Color.Silver;
            button3.Font = new Font("Segoe UI", 12F);
            button3.Location = new Point(35, 3);
            button3.Name = "button3";
            button3.Size = new Size(271, 47);
            button3.TabIndex = 2;
            button3.Text = "Продать инструмент";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(35, 56);
            button1.Name = "button1";
            button1.Size = new Size(271, 47);
            button1.TabIndex = 3;
            button1.Text = "Заказать инструмент";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 192, 255);
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(35, 109);
            button2.Name = "button2";
            button2.Size = new Size(271, 47);
            button2.TabIndex = 4;
            button2.Text = "Настроить инструмент";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 192, 255);
            button4.Font = new Font("Segoe UI", 12F);
            button4.Location = new Point(35, 162);
            button4.Name = "button4";
            button4.Size = new Size(271, 47);
            button4.TabIndex = 5;
            button4.Text = "Играть на инструменте";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(12, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(333, 214);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Location = new Point(12, 280);
            panel2.Name = "panel2";
            panel2.Size = new Size(333, 106);
            panel2.TabIndex = 7;
            panel2.Visible = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(button7);
            panel3.Controls.Add(button8);
            panel3.Location = new Point(12, 280);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 106);
            panel3.TabIndex = 8;
            panel3.Visible = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(128, 128, 255);
            button7.Font = new Font("Segoe UI", 12F);
            button7.Location = new Point(35, 56);
            button7.Name = "button7";
            button7.Size = new Size(271, 47);
            button7.TabIndex = 4;
            button7.Text = "Нажимать на педаль";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(128, 128, 255);
            button8.Font = new Font("Segoe UI", 12F);
            button8.Location = new Point(35, 3);
            button8.Name = "button8";
            button8.Size = new Size(271, 47);
            button8.TabIndex = 3;
            button8.Text = "Нажимать на клавиши";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(128, 128, 255);
            button6.Font = new Font("Segoe UI", 12F);
            button6.Location = new Point(35, 56);
            button6.Name = "button6";
            button6.Size = new Size(271, 47);
            button6.TabIndex = 4;
            button6.Text = "Бить по срунам";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(128, 128, 255);
            button5.Font = new Font("Segoe UI", 12F);
            button5.Location = new Point(35, 3);
            button5.Name = "button5";
            button5.Size = new Size(271, 47);
            button5.TabIndex = 3;
            button5.Text = "Зажимать аккорды";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(367, 401);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            Text = "Инструмент";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
        private Button button1;
        private Button button2;
        private Button button4;
        private Panel panel1;
        private Panel panel2;
        private Button button6;
        private Button button5;
        private Panel panel3;
        private Button button7;
        private Button button8;
    }
}