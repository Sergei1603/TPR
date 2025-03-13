
namespace ЛР5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dgwLeft = new System.Windows.Forms.DataGridView();
            dgw2 = new System.Windows.Forms.DataGridView();
            cbCriteria = new System.Windows.Forms.ComboBox();
            cbType = new System.Windows.Forms.ComboBox();
            cbFunction = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            lblQ = new System.Windows.Forms.Label();
            lblS = new System.Windows.Forms.Label();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox1 = new System.Windows.Forms.GroupBox();
            nudS = new System.Windows.Forms.NumericUpDown();
            nudQ = new System.Windows.Forms.NumericUpDown();
            nudWeight = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();
            listBox2 = new System.Windows.Forms.ListBox();
            textBox1 = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgwLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgw2).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(166, 57);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(65, 27);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new System.Drawing.Point(166, 93);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(65, 27);
            numericUpDown2.TabIndex = 3;
            numericUpDown2.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(542, 559);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(547, 49);
            button2.TabIndex = 5;
            button2.Text = "Рассчитать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(149, 20);
            label1.TabIndex = 6;
            label1.Text = "Кол-во альтернатив";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 96);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 20);
            label2.TabIndex = 7;
            label2.Text = "Кол-во критериев";
            // 
            // dgwLeft
            // 
            dgwLeft.AllowUserToAddRows = false;
            dgwLeft.AllowUserToDeleteRows = false;
            dgwLeft.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgwLeft.BackgroundColor = System.Drawing.Color.White;
            dgwLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwLeft.Location = new System.Drawing.Point(13, 153);
            dgwLeft.Name = "dgwLeft";
            dgwLeft.RowHeadersWidth = 51;
            dgwLeft.RowTemplate.Height = 29;
            dgwLeft.Size = new System.Drawing.Size(509, 255);
            dgwLeft.TabIndex = 8;
            // 
            // dgw2
            // 
            dgw2.AllowUserToAddRows = false;
            dgw2.AllowUserToDeleteRows = false;
            dgw2.BackgroundColor = System.Drawing.Color.White;
            dgw2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgw2.Location = new System.Drawing.Point(542, 153);
            dgw2.Name = "dgw2";
            dgw2.ReadOnly = true;
            dgw2.RowHeadersWidth = 51;
            dgw2.RowTemplate.Height = 29;
            dgw2.Size = new System.Drawing.Size(547, 379);
            dgw2.TabIndex = 9;
            // 
            // cbCriteria
            // 
            cbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCriteria.FormattingEnabled = true;
            cbCriteria.Location = new System.Drawing.Point(7, 60);
            cbCriteria.Name = "cbCriteria";
            cbCriteria.Size = new System.Drawing.Size(155, 28);
            cbCriteria.TabIndex = 10;
            cbCriteria.SelectedIndexChanged += cbCriteria_SelectedIndexChanged;
            // 
            // cbType
            // 
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new System.Drawing.Point(259, 127);
            cbType.Name = "cbType";
            cbType.Size = new System.Drawing.Size(229, 28);
            cbType.TabIndex = 11;
            // 
            // cbFunction
            // 
            cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFunction.FormattingEnabled = true;
            cbFunction.Location = new System.Drawing.Point(6, 127);
            cbFunction.Name = "cbFunction";
            cbFunction.Size = new System.Drawing.Size(246, 28);
            cbFunction.TabIndex = 12;
            cbFunction.SelectedIndexChanged += cbFunction_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(260, 57);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(155, 40);
            button1.TabIndex = 15;
            button1.Text = "Создать таблицу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += onCreateTable;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(365, 188);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(125, 41);
            button3.TabIndex = 16;
            button3.Text = "Задать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 20);
            label3.TabIndex = 17;
            label3.Text = "Критерий";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(173, 36);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 20);
            label4.TabIndex = 18;
            label4.Text = "Вес";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 104);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 20);
            label5.TabIndex = 19;
            label5.Text = "Функция";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(259, 104);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(35, 20);
            label6.TabIndex = 20;
            label6.Text = "Тип";
            // 
            // lblQ
            // 
            lblQ.AutoSize = true;
            lblQ.Location = new System.Drawing.Point(7, 172);
            lblQ.Name = "lblQ";
            lblQ.Size = new System.Drawing.Size(20, 20);
            lblQ.TabIndex = 21;
            lblQ.Text = "Q";
            // 
            // lblS
            // 
            lblS.AutoSize = true;
            lblS.Location = new System.Drawing.Point(90, 172);
            lblS.Name = "lblS";
            lblS.Size = new System.Drawing.Size(17, 20);
            lblS.TabIndex = 23;
            lblS.Text = "S";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            menuStrip1.Size = new System.Drawing.Size(1104, 30);
            menuStrip1.TabIndex = 24;
            menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += Load_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += Save_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudS);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(nudQ);
            groupBox1.Controls.Add(lblS);
            groupBox1.Controls.Add(nudWeight);
            groupBox1.Controls.Add(cbType);
            groupBox1.Controls.Add(lblQ);
            groupBox1.Controls.Add(cbCriteria);
            groupBox1.Controls.Add(cbFunction);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new System.Drawing.Point(14, 415);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(507, 249);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Задание критерия";
            // 
            // nudS
            // 
            nudS.DecimalPlaces = 2;
            nudS.Location = new System.Drawing.Point(90, 196);
            nudS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nudS.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudS.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
            nudS.Name = "nudS";
            nudS.Size = new System.Drawing.Size(77, 27);
            nudS.TabIndex = 21;
            // 
            // nudQ
            // 
            nudQ.DecimalPlaces = 2;
            nudQ.Location = new System.Drawing.Point(7, 196);
            nudQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nudQ.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudQ.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
            nudQ.Name = "nudQ";
            nudQ.Size = new System.Drawing.Size(77, 27);
            nudQ.TabIndex = 21;
            // 
            // nudWeight
            // 
            nudWeight.DecimalPlaces = 2;
            nudWeight.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudWeight.Location = new System.Drawing.Point(173, 60);
            nudWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            nudWeight.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new System.Drawing.Size(110, 27);
            nudWeight.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(542, 30);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(109, 20);
            label7.TabIndex = 27;
            label7.Text = "Альтернативы";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(721, 30);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(77, 20);
            label8.TabIndex = 28;
            label8.Text = "Критерии";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new System.Drawing.Point(542, 57);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(139, 84);
            listBox1.TabIndex = 26;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new System.Drawing.Point(721, 57);
            listBox2.Name = "listBox2";
            listBox2.Size = new System.Drawing.Size(139, 84);
            listBox2.TabIndex = 29;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(886, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(125, 27);
            textBox1.TabIndex = 30;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(886, 68);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(203, 29);
            button4.TabIndex = 31;
            button4.Text = "Добавить альтернативу";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(886, 112);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(203, 29);
            button5.TabIndex = 32;
            button5.Text = "Добавить критерий";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(260, 96);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(155, 40);
            button6.TabIndex = 33;
            button6.Text = "Очистить таблицу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1104, 680);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(listBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(listBox1);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(dgw2);
            Controls.Add(dgwLeft);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Метод PROMETHEE";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgwLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgw2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudS).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCriteria;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgwLeft;
        private System.Windows.Forms.DataGridView dgw2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudQ;
        private System.Windows.Forms.NumericUpDown nudS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

