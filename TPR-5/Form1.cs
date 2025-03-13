using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР5
{
    public partial class Form1 : Form
    {
        public static int alternativeCnt; //Кол-во альтернатив
        public static int critCnt; //Кол-во критериев
        public static double[,] grid1;
        public static string[,] grid2;
        public double[,] arr;
        List<double[,]> table1;
        List<double[,]> table2;
        List<double[,]> table3;
        string value;

        public Form1()
        {
            InitializeComponent();

            var list = new List<string>();
            list.Add("Обычная функция");
            list.Add("U-образная функция");
            list.Add("V-образная функция");
            list.Add("Уровневая функция");
            list.Add("V-образная функция с порогами безразличия");
            cbFunction.Items.AddRange(list.ToArray());

            cbType.Items.Add("Положительно направленный");
            cbType.Items.Add("Отрицательно направленный");

            onCreateTable(null, null);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файл Excel | *.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "VDWWD";
                excelPackage.Workbook.Properties.Title = "Документ";
                excelPackage.Workbook.Properties.Subject = "Данные";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Лист 1");

                worksheet.Cells[1, 1].Value = "Кол-во альтернатив";
                worksheet.Cells[1, 2].Value = alternativeCnt;
                worksheet.Cells[1, 4].Value = "Кол-во критериев";
                worksheet.Cells[1, 5].Value = critCnt;

                for (int i = 0; i < alternativeCnt; i++)
                {
                    for (int j = 0; j < critCnt; j++)
                    {
                        worksheet.Cells[3 + i, 1 + j].Value = grid1[i, j];
                    }
                }

                worksheet.Cells[5 + alternativeCnt, 1].Value = "Функции предпочтений";

                for (int i = 0; i < critCnt; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        worksheet.Cells[8 + i, 1 + j].Value = grid2[i, j];
                    }
                }

                int current = 8 + alternativeCnt + critCnt;
                worksheet.Cells[current, 1].Value = "Шаг 1";
                current = current + 2;
                int right = 1;

                for (int j = 0; j < critCnt; j++)
                {
                    for (int i = 0; i < alternativeCnt; i++)
                    {
                        for (int k = 0; k < alternativeCnt; k++)
                        {
                            worksheet.Cells[current + i, right + k].Value = table1[j][i, k];
                        }
                    }
                    right = right + alternativeCnt + 3;
                }

                current = current + alternativeCnt + 2;
                worksheet.Cells[current, 1].Value = "Шаг 2";
                current = current + 2;
                right = 1;

                for (int j = 0; j < critCnt; j++)
                {
                    for (int i = 0; i < alternativeCnt; i++)
                    {
                        for (int k = 0; k < alternativeCnt; k++)
                        {
                            worksheet.Cells[current + i, right + k].Value = table2[j][i, k];
                        }
                    }
                    right = right + alternativeCnt + 3;
                }

                current = current + alternativeCnt + 2;
                worksheet.Cells[current, 1].Value = "Шаг 3";
                current = current + 2;

                for (int i = 0; i < alternativeCnt + 1; i++)
                {
                    for (int k = 0; k < alternativeCnt + 1; k++)
                    {
                        worksheet.Cells[current + i, k + 1].Value = table3[0][i, k];
                    }
                }

                current = current + alternativeCnt + 2;

                worksheet.Cells[current, 1].Value = value;

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    worksheet.Cells[1, i + 16].Value = listBox1.Items[i].ToString();
                }
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    worksheet.Cells[2, i + 16].Value = listBox2.Items[i].ToString();
                }
                try
                {
                    FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                    excelPackage.SaveAs(fi);
                }
                catch
                {
                    MessageBox.Show(
                        "Открыт Excel файл",
                        "Ошибка сохранения файла!"
                    );
                    return;
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);

            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                //try
                {

                    dgwLeft.Columns.Clear();
                    dgwLeft.Rows.Clear();

                    alternativeCnt = Convert.ToInt32(worksheet.Cells[1, 2].Value);
                    critCnt = Convert.ToInt32(worksheet.Cells[1, 5].Value);

                    for (int i = 0; i < alternativeCnt; i++)
                    {
                        listBox1.Items.Add(Convert.ToString(worksheet.Cells[1, i + 16].Value));
                    }
                    for (int i = 0; i < critCnt; i++)
                    {
                        listBox2.Items.Add(Convert.ToString(worksheet.Cells[2, i + 16].Value));
                    }
                    grid1 = new double[alternativeCnt, critCnt];

                    for (int i = 0; i < critCnt; i++)
                    {
                        var column = new DataGridViewColumn();
                        //column.HeaderText = Convert.ToString(i + 1) + " критерий";
                        if (listBox2.Items.Count > i)
                        {
                            column.HeaderText = listBox2.Items[i].ToString();
                        }
                        else
                        {
                            column.HeaderText = Convert.ToString(i + 1) + " критерий";
                        }
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.CellTemplate = new DataGridViewTextBoxCell();
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        dgwLeft.Columns.Add(column);
                    }

                    for (int i = 0; i < alternativeCnt; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        if (listBox1.Items.Count > i)
                        {
                            row.HeaderCell.Value = listBox1.Items[i].ToString();
                        }
                        else
                        {
                            row.HeaderCell.Value = "a" + Convert.ToString(i + 1);
                        }
                        dgwLeft.Rows.Add(row);
                    }

                    DataGridView dgv = dgwLeft;
                    arr = new double[alternativeCnt, critCnt];

                    for (int i = 0; i < alternativeCnt; i++)
                    {
                        for (int j = 0; j < critCnt; j++)
                        {
                            arr[i, j] = Convert.ToDouble(worksheet.Cells[3 + i, 1 + j].Value);
                            dgv[j, i].Value = arr[i, j];
                            grid1[i, j] = arr[i, j];
                        }
                    }


                    CreateRightTable();

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < critCnt; j++)
                        {
                            var value = worksheet.Cells[8 + j, 1 + i].Value;
                            dgw2.Rows[j].Cells[i].Value = value;
                        }
                    }

                    excelPackage.Save();
                }
                //catch
                //{
                //    MessageBox.Show(
                //    "Открыт Excel файл или неверный формат",
                //    "Ошибка загрузки файла!"
                //    );
                //    return;
                //}
            }
        }

        //выбрать критерий
        private void CreateCriterias()
        {
            cbCriteria.Items.Clear();
            var list = new List<string>();
            for (int i = 0; i < critCnt; i++)
            {
                if (listBox2.Items.Count > i)
                {
                    list.Add(listBox2.Items[i].ToString());
                }
                else
                {
                    list.Add(Convert.ToString(i + 1) + " критерий");
                }
            }
            cbCriteria.Items.AddRange(list.ToArray());
        }

        // задать критерий
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgw2;
            dgv[0, cbCriteria.SelectedIndex].Value = cbFunction.SelectedItem.ToString();
            dgv[1, cbCriteria.SelectedIndex].Value = cbType.SelectedItem.ToString();
            if (nudQ.Visible)
                dgv[2, cbCriteria.SelectedIndex].Value = nudQ.Value.ToString();

            if (nudS.Visible)
                dgv[3, cbCriteria.SelectedIndex].Value = nudS.Value.ToString();
            dgv[4, cbCriteria.SelectedIndex].Value = nudWeight.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid1 = new double[alternativeCnt, critCnt];
            grid2 = new string[critCnt, 5];

            double sumCrit = 0;
            for (int i = 0; i < critCnt; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (j == 0 && dgw2[j, i].Value == null)
                    {
                        MessageBox.Show("Не все критерии настроены", "Ошибка");
                        return;
                    }

                    if (j == 4)
                    {
                        sumCrit += Convert.ToDouble(dgw2[j, i].Value.ToString());
                    }

                    grid2[i, j] = dgw2[j, i].Value?.ToString();
                }

            if (sumCrit != 1)
            {
                MessageBox.Show("Сумма весов критериев отлична от 1", "Ошибка");
                return;
            }


            for (int i = 0; i < alternativeCnt; i++)
                for (int j = 0; j < critCnt; j++)
                    grid1[i, j] = Convert.ToDouble(dgwLeft[j, i].Value.ToString());


            Form2 f2 = new Form2(alternativeCnt, critCnt, grid1, grid2, listBox1.Items, listBox2.Items);
            f2.ShowDialog();
            table1 = f2.GetStepOne();
            table2 = f2.GetStepTwo();
            table3 = f2.GetStepThree();
            value = f2.GetStepFour();
        }

        // формируем таблицу
        private void onCreateTable(object sender, EventArgs e)
        {
            dgwLeft.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            //dgwLeft.Columns.Clear();
            // dgwLeft.Rows.Clear();

            numericUpDown1.Value = listBox1.Items.Count == 0 ? 1 : listBox1.Items.Count;
            numericUpDown2.Value = listBox2.Items.Count == 0 ? 1 : listBox2.Items.Count;
            if (numericUpDown1.Text != "")
                alternativeCnt = Convert.ToInt32(numericUpDown1.Text);
            else
                alternativeCnt = 1;
            if (numericUpDown2.Text != "")
                critCnt = Convert.ToInt32(numericUpDown2.Text);
            else
                critCnt = 1;

            for (int i = dgwLeft.Columns.Count; i < critCnt; i++)
            {
                var column = new DataGridViewColumn();
                if (listBox2.Items.Count > i)
                {
                    column.HeaderText = listBox2.Items[i].ToString();
                }
                else
                {
                    column.HeaderText = Convert.ToString(i + 1) + " критерий";
                }
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgwLeft.Columns.Add(column);
            }

            for (int i = dgwLeft.Rows.Count; i < alternativeCnt; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                if (listBox1.Items.Count > i)
                {
                    row.HeaderCell.Value = listBox1.Items[i].ToString();
                }
                else
                {
                    row.HeaderCell.Value = "a" + Convert.ToString(i + 1);
                }

                dgwLeft.Rows.Add(row);
            }

            for (int i = dgwLeft.ColumnCount; i < alternativeCnt; i++)
                for (int j = dgwLeft.Rows.Count; j < critCnt; j++)
                    dgwLeft.Rows[i].Cells[j].Value = "0";

            CreateCriterias();
            cbCriteria.SelectedIndex = 0;
            cbFunction.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            // таблица критериев
            CreateRightTable();
        }

        void CreateRightTable()
        {
            dgw2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            dgw2.Columns.Clear();
            dgw2.Rows.Clear();
            for (int i = 0; i < 5; i++)
            {
                var column = new DataGridViewColumn();
                if (i == 0)
                    column.HeaderText = "Функция";
                if (i == 1)
                    column.HeaderText = "Тип критерия";
                if (i == 2)
                    column.HeaderText = "Q";
                if (i == 3)
                    column.HeaderText = "S";
                if (i == 4)
                    column.HeaderText = "Вес критерия";
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgw2.Columns.Add(column);
            }

            for (int i = 0; i < critCnt; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                if (listBox2.Items.Count > i)
                {
                    row.HeaderCell.Value = listBox2.Items[i].ToString();
                }
                else
                {
                    row.HeaderCell.Value = Convert.ToString(i + 1) + " критерий";
                }
                dgw2.Rows.Add(row);
            }
        }

        private void cbCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обычная функция
            // U-образная функция
            // V-образная функция
            // Уровневая функция
            // V-образная функция с порогами безразличия

            var q = false;
            var s = false;

            switch (cbFunction.SelectedIndex)
            {
                case 1:
                    q = true;
                    break;
                case 2:
                    s = true;
                    break;
                case 3:
                    q = true;
                    s = true;
                    break;
                case 4:
                    q = true;
                    s = true;
                    break;
            }

            lblQ.Visible = q;
            nudQ.Visible = q;

            lblS.Visible = s;
            nudS.Visible = s;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
            }
            numericUpDown1.Value = listBox1.Items.Count;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                listBox2.Items.Add(textBox1.Text);
            }
            numericUpDown2.Value = listBox2.Items.Count;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dgwLeft.Columns.Clear();
            dgwLeft.Rows.Clear();
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
        }
    }
}
