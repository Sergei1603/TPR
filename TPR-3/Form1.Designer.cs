namespace TPR_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lblNiz = new System.Windows.Forms.Label();
            this.lblVerh = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudPlayer1 = new System.Windows.Forms.NumericUpDown();
            this.nudPlayer2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.payGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudStart2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudStart1 = new System.Windows.Forms.NumericUpDown();
            this.rbIteration = new System.Windows.Forms.RadioButton();
            this.rbPrecision = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudPrecision = new System.Windows.Forms.NumericUpDown();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.iterGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lbStrategies1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbStrategies2 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Игрок 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Игрок 2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(12, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 22);
            this.button1.TabIndex = 17;
            this.button1.Text = "Построить матрицу";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(488, 40);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 22);
            this.button2.TabIndex = 25;
            this.button2.Text = "Вычислить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(15, 21);
            this.lblFirst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(88, 13);
            this.lblFirst.TabIndex = 28;
            this.lblFirst.Text = "Первого игрока\r\n";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(159, 21);
            this.lblSecond.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(86, 13);
            this.lblSecond.TabIndex = 29;
            this.lblSecond.Text = "Второго игрока";
            // 
            // sfd
            // 
            this.sfd.Filter = "Текстовый файл|*.txt";
            // 
            // ofd
            // 
            this.ofd.Filter = "Текстовый файл|*.txt";
            // 
            // lblNiz
            // 
            this.lblNiz.AutoSize = true;
            this.lblNiz.Location = new System.Drawing.Point(487, 88);
            this.lblNiz.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNiz.Name = "lblNiz";
            this.lblNiz.Size = new System.Drawing.Size(111, 13);
            this.lblNiz.TabIndex = 32;
            this.lblNiz.Text = "Нижняя цена игры: -";
            // 
            // lblVerh
            // 
            this.lblVerh.AutoSize = true;
            this.lblVerh.Location = new System.Drawing.Point(487, 69);
            this.lblVerh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVerh.Name = "lblVerh";
            this.lblVerh.Size = new System.Drawing.Size(113, 13);
            this.lblVerh.TabIndex = 33;
            this.lblVerh.Text = "Верхняя цена игры: -";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(487, 106);
            this.lblCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(70, 13);
            this.lblCost.TabIndex = 38;
            this.lblCost.Text = "Цена игры: -";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // nudPlayer1
            // 
            this.nudPlayer1.Location = new System.Drawing.Point(105, 26);
            this.nudPlayer1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPlayer1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlayer1.Name = "nudPlayer1";
            this.nudPlayer1.Size = new System.Drawing.Size(47, 20);
            this.nudPlayer1.TabIndex = 40;
            this.nudPlayer1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudPlayer2
            // 
            this.nudPlayer2.Location = new System.Drawing.Point(105, 52);
            this.nudPlayer2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPlayer2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPlayer2.Name = "nudPlayer2";
            this.nudPlayer2.Size = new System.Drawing.Size(47, 20);
            this.nudPlayer2.TabIndex = 40;
            this.nudPlayer2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudPlayer2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudPlayer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 83);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество стратегий";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Платежная матрица";
            // 
            // payGrid
            // 
            this.payGrid.AllowUserToAddRows = false;
            this.payGrid.AllowUserToDeleteRows = false;
            this.payGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.payGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.payGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.payGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payGrid.Location = new System.Drawing.Point(12, 188);
            this.payGrid.MultiSelect = false;
            this.payGrid.Name = "payGrid";
            this.payGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.payGrid.Size = new System.Drawing.Size(177, 120);
            this.payGrid.TabIndex = 42;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudStart2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudStart1);
            this.groupBox2.Location = new System.Drawing.Point(233, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 83);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Номер стратегии для 1-й итерации";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Игрок 1";
            // 
            // nudStart2
            // 
            this.nudStart2.Location = new System.Drawing.Point(135, 52);
            this.nudStart2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStart2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStart2.Name = "nudStart2";
            this.nudStart2.Size = new System.Drawing.Size(47, 20);
            this.nudStart2.TabIndex = 40;
            this.nudStart2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Игрок 2";
            // 
            // nudStart1
            // 
            this.nudStart1.Location = new System.Drawing.Point(135, 26);
            this.nudStart1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStart1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStart1.Name = "nudStart1";
            this.nudStart1.Size = new System.Drawing.Size(47, 20);
            this.nudStart1.TabIndex = 40;
            this.nudStart1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbIteration
            // 
            this.rbIteration.AutoSize = true;
            this.rbIteration.Checked = true;
            this.rbIteration.Location = new System.Drawing.Point(6, 21);
            this.rbIteration.Name = "rbIteration";
            this.rbIteration.Size = new System.Drawing.Size(109, 17);
            this.rbIteration.TabIndex = 43;
            this.rbIteration.TabStop = true;
            this.rbIteration.Text = "Кол-во итераций";
            this.rbIteration.UseVisualStyleBackColor = true;
            this.rbIteration.CheckedChanged += new System.EventHandler(this.rbIteration_CheckedChanged);
            // 
            // rbPrecision
            // 
            this.rbPrecision.AutoSize = true;
            this.rbPrecision.Location = new System.Drawing.Point(6, 47);
            this.rbPrecision.Name = "rbPrecision";
            this.rbPrecision.Size = new System.Drawing.Size(72, 17);
            this.rbPrecision.TabIndex = 43;
            this.rbPrecision.Text = "Точность";
            this.rbPrecision.UseVisualStyleBackColor = true;
            this.rbPrecision.CheckedChanged += new System.EventHandler(this.rbIteration_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudPrecision);
            this.groupBox3.Controls.Add(this.nudIterations);
            this.groupBox3.Controls.Add(this.rbPrecision);
            this.groupBox3.Controls.Add(this.rbIteration);
            this.groupBox3.Location = new System.Drawing.Point(233, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 85);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Условие окончания";
            // 
            // nudPrecision
            // 
            this.nudPrecision.DecimalPlaces = 1;
            this.nudPrecision.Enabled = false;
            this.nudPrecision.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPrecision.Location = new System.Drawing.Point(135, 47);
            this.nudPrecision.Name = "nudPrecision";
            this.nudPrecision.Size = new System.Drawing.Size(70, 20);
            this.nudPrecision.TabIndex = 44;
            this.nudPrecision.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(135, 21);
            this.nudIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(70, 20);
            this.nudIterations.TabIndex = 44;
            this.nudIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // iterGrid
            // 
            this.iterGrid.AllowUserToAddRows = false;
            this.iterGrid.AllowUserToDeleteRows = false;
            this.iterGrid.AllowUserToOrderColumns = true;
            this.iterGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iterGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.iterGrid.Location = new System.Drawing.Point(12, 359);
            this.iterGrid.MultiSelect = false;
            this.iterGrid.Name = "iterGrid";
            this.iterGrid.ReadOnly = true;
            this.iterGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.iterGrid.Size = new System.Drawing.Size(821, 211);
            this.iterGrid.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Итерации";
            // 
            // lbStrategies1
            // 
            this.lbStrategies1.FormattingEnabled = true;
            this.lbStrategies1.Location = new System.Drawing.Point(18, 37);
            this.lbStrategies1.Name = "lbStrategies1";
            this.lbStrategies1.Size = new System.Drawing.Size(115, 134);
            this.lbStrategies1.TabIndex = 45;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbStrategies2);
            this.groupBox4.Controls.Add(this.lbStrategies1);
            this.groupBox4.Controls.Add(this.lblFirst);
            this.groupBox4.Controls.Add(this.lblSecond);
            this.groupBox4.Location = new System.Drawing.Point(490, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 189);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Смешанные стратегии";
            // 
            // lbStrategies2
            // 
            this.lbStrategies2.FormattingEnabled = true;
            this.lbStrategies2.Location = new System.Drawing.Point(162, 37);
            this.lbStrategies2.Name = "lbStrategies2";
            this.lbStrategies2.Size = new System.Drawing.Size(137, 134);
            this.lbStrategies2.TabIndex = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(855, 582);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.iterGrid);
            this.Controls.Add(this.payGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblVerh);
            this.Controls.Add(this.lblNiz);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Метод Брауна-Робинсона";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlayer2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label lblNiz;
        private System.Windows.Forms.Label lblVerh;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudPlayer1;
        private System.Windows.Forms.NumericUpDown nudPlayer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView payGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudStart2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudStart1;
        private System.Windows.Forms.RadioButton rbIteration;
        private System.Windows.Forms.RadioButton rbPrecision;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudPrecision;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.DataGridView iterGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbStrategies1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbStrategies2;
    }
}

