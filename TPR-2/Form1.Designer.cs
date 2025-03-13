namespace TPR_2
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbProb = new System.Windows.Forms.RadioButton();
            this.rbOr = new System.Windows.Forms.RadioButton();
            this.rbAnd = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbRootType = new System.Windows.Forms.ComboBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tbFAL = new System.Windows.Forms.TextBox();
            this.tbCalc = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOcenka = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.lblProb = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRootName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(372, 113);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(530, 485);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProb);
            this.groupBox1.Controls.Add(this.rbOr);
            this.groupBox1.Controls.Add(this.rbAnd);
            this.groupBox1.Location = new System.Drawing.Point(372, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(283, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "События";
            // 
            // rbProb
            // 
            this.rbProb.AutoSize = true;
            this.rbProb.Checked = true;
            this.rbProb.Location = new System.Drawing.Point(168, 23);
            this.rbProb.Margin = new System.Windows.Forms.Padding(4);
            this.rbProb.Name = "rbProb";
            this.rbProb.Size = new System.Drawing.Size(94, 20);
            this.rbProb.TabIndex = 2;
            this.rbProb.TabStop = true;
            this.rbProb.Text = "Иниц. соб.";
            this.rbProb.UseVisualStyleBackColor = true;
            // 
            // rbOr
            // 
            this.rbOr.AutoSize = true;
            this.rbOr.Location = new System.Drawing.Point(81, 23);
            this.rbOr.Margin = new System.Windows.Forms.Padding(4);
            this.rbOr.Name = "rbOr";
            this.rbOr.Size = new System.Drawing.Size(57, 20);
            this.rbOr.TabIndex = 1;
            this.rbOr.Text = "ИЛИ";
            this.rbOr.UseVisualStyleBackColor = true;
            // 
            // rbAnd
            // 
            this.rbAnd.AutoSize = true;
            this.rbAnd.Location = new System.Drawing.Point(8, 23);
            this.rbAnd.Margin = new System.Windows.Forms.Padding(4);
            this.rbAnd.Name = "rbAnd";
            this.rbAnd.Size = new System.Drawing.Size(38, 20);
            this.rbAnd.TabIndex = 0;
            this.rbAnd.Text = "И";
            this.rbAnd.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(663, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(239, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(788, 78);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbRootType
            // 
            this.cbRootType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRootType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRootType.FormattingEnabled = true;
            this.cbRootType.Items.AddRange(new object[] {
            "И",
            "ИЛИ"});
            this.cbRootType.Location = new System.Drawing.Point(933, 99);
            this.cbRootType.Margin = new System.Windows.Forms.Padding(4);
            this.cbRootType.Name = "cbRootType";
            this.cbRootType.Size = new System.Drawing.Size(160, 24);
            this.cbRootType.TabIndex = 6;
            this.cbRootType.SelectedIndexChanged += new System.EventHandler(this.cbRootType_SelectedIndexChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(934, 203);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(379, 28);
            this.btnCalc.TabIndex = 7;
            this.btnCalc.Text = "Расчет";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tbFAL
            // 
            this.tbFAL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFAL.Location = new System.Drawing.Point(934, 274);
            this.tbFAL.Margin = new System.Windows.Forms.Padding(4);
            this.tbFAL.Multiline = true;
            this.tbFAL.Name = "tbFAL";
            this.tbFAL.ReadOnly = true;
            this.tbFAL.Size = new System.Drawing.Size(377, 112);
            this.tbFAL.TabIndex = 8;
            // 
            // tbCalc
            // 
            this.tbCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCalc.Location = new System.Drawing.Point(934, 420);
            this.tbCalc.Margin = new System.Windows.Forms.Padding(4);
            this.tbCalc.Multiline = true;
            this.tbCalc.Name = "tbCalc";
            this.tbCalc.ReadOnly = true;
            this.tbCalc.Size = new System.Drawing.Size(377, 115);
            this.tbCalc.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem,
            this.экспортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1449, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(91, 26);
            this.импортToolStripMenuItem.Text = "Загрузить";
            this.импортToolStripMenuItem.Click += new System.EventHandler(this.импортToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(97, 26);
            this.экспортToolStripMenuItem.Text = "Сохранить";
            this.экспортToolStripMenuItem.Click += new System.EventHandler(this.экспортToolStripMenuItem_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            this.ofd.Filter = "Txt |*.txt";
            // 
            // sfd
            // 
            this.sfd.Filter = "Txt |*.txt";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(931, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Функция алгебры логики";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(934, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Вероятностная функция";
            // 
            // lblOcenka
            // 
            this.lblOcenka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOcenka.AutoSize = true;
            this.lblOcenka.Location = new System.Drawing.Point(934, 582);
            this.lblOcenka.Name = "lblOcenka";
            this.lblOcenka.Size = new System.Drawing.Size(323, 16);
            this.lblOcenka.TabIndex = 12;
            this.lblOcenka.Text = "Оценка риска выбранного опасного состояния: -";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(931, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Величина ущерба";
            // 
            // nudCost
            // 
            this.nudCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCost.DecimalPlaces = 2;
            this.nudCost.Location = new System.Drawing.Point(933, 162);
            this.nudCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCost.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(160, 22);
            this.nudCost.TabIndex = 13;
            this.nudCost.ThousandsSeparator = true;
            this.nudCost.ValueChanged += new System.EventHandler(this.nudCost_ValueChanged);
            // 
            // lblProb
            // 
            this.lblProb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProb.AutoSize = true;
            this.lblProb.Location = new System.Drawing.Point(934, 555);
            this.lblProb.Name = "lblProb";
            this.lblProb.Size = new System.Drawing.Size(358, 16);
            this.lblProb.TabIndex = 12;
            this.lblProb.Text = "Вероятность риска выбранного опасного состаяния: -";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(663, 78);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(338, 484);
            this.listBox1.TabIndex = 14;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 22);
            this.textBox1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(934, 623);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Оценка риска по всем ОС: -";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(663, 620);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Рассчитать оценку риска по всем ОС";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Изменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название конечного события";
            // 
            // tbRootName
            // 
            this.tbRootName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootName.Location = new System.Drawing.Point(934, 69);
            this.tbRootName.Margin = new System.Windows.Forms.Padding(4);
            this.tbRootName.Name = "tbRootName";
            this.tbRootName.ReadOnly = true;
            this.tbRootName.Size = new System.Drawing.Size(377, 22);
            this.tbRootName.TabIndex = 4;
            this.tbRootName.Text = "Конечное событие";
            this.tbRootName.TextChanged += new System.EventHandler(this.tbRootName_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 663);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.nudCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblProb);
            this.Controls.Add(this.lblOcenka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCalc);
            this.Controls.Add(this.tbFAL);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.cbRootType);
            this.Controls.Add(this.tbRootName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1021, 654);
            this.Name = "Form1";
            this.Text = "Логико-вероятностный метод";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProb;
        private System.Windows.Forms.RadioButton rbOr;
        private System.Windows.Forms.RadioButton rbAnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbRootType;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox tbFAL;
        private System.Windows.Forms.TextBox tbCalc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOcenka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.Label lblProb;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRootName;
    }
}

