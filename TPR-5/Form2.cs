using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ЛР5
{
    public partial class Form2 : Form {
        public Form f = new Form();

        double[,] matrixStepOne;
        string[,] dgv1;

        List<double[,]> StepOneMatr;
        List<double[,]> StepTwoMatr;
        List<double[,]> StepThreeMatr;
        ListBox.ObjectCollection altern;
        ListBox.ObjectCollection crit;

        int critCnt;
        int alternativeCnt;
        string Mess;

        public Form2(int a, int b, double[,] Matr, string[,] Matr2, ListBox.ObjectCollection items, ListBox.ObjectCollection items2) {
            StepOneMatr = new List<double[,]>();
            StepTwoMatr = new List<double[,]>(); ;
            StepThreeMatr = new List<double[,]>(); ;
            Mess = "";
            alternativeCnt = a;
            critCnt = b;
            matrixStepOne = Matr;
            dgv1 = Matr2;
            altern = items;
            crit = items2;
            InitializeComponent();
            StepOne();
            StepTwo();
            StepThree();
            StepFour();
        }

        public List<double[,]> GetStepOne() {
            return StepOneMatr;
        }

        public List<double[,]> GetStepTwo() {
            return StepTwoMatr;
        }

        public List<double[,]> GetStepThree() {
            return StepThreeMatr;
        }

        public string GetStepFour() {
            return Mess;
        }

        private void StepOne() {
            //tabControl1.Width = 800;
            //tabControl1.Height = 176;

            int cnt1 = tabControl1.TabPages.Count;
            for (int i = cnt1 - 1; i >= 0; i--) {
                tabControl1.TabPages.RemoveAt(i);
            }

            for (int j = 0; j < critCnt; j++) {
                StepOneMatr.Add(new double[alternativeCnt, alternativeCnt]);
                DataGridView grid = new DataGridView();

                grid.Dock = DockStyle.Fill;
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.AllowUserToResizeColumns = false;
                grid.AllowUserToResizeRows = false;
                grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                grid.BackgroundColor = System.Drawing.Color.White;

                TabPage tabP = new TabPage();

                //tabP.Text = Convert.ToString(j + 1) + " критерий";
                tabP.Text = crit[j].ToString();
                tabControl1.Controls.Add(tabP);
                tabP.Controls.Add(grid);
                tabControl1.Refresh();

                for (int i = 0; i < alternativeCnt; i++) {
                    var column = new DataGridViewColumn();
                    column.HeaderText = "a " + Convert.ToString(i + 1);
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    grid.Columns.Add(column);

                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = "a" + Convert.ToString(i + 1);
                    grid.Rows.Add(row);
                }

                for (int i = 0; i < alternativeCnt; i++) {
                    for (int k = 0; k < alternativeCnt; k++) {
                        StepOneMatr[j][i, k] = matrixStepOne[i, j] - matrixStepOne[k, j];
                        grid[k, i].Value = matrixStepOne[i, j] - matrixStepOne[k, j];
                    }
                }
            }
        }

        private void StepTwo() {
            //tabControl2.Width = 800;
            //tabControl2.Height = 176;

            int cnt1 = tabControl2.TabPages.Count;
            for (int i = cnt1 - 1; i >= 0; i--) {
                tabControl2.TabPages.RemoveAt(i);
            }

            for (int j = 0; j < critCnt; j++) {
                StepTwoMatr.Add(new double[alternativeCnt, alternativeCnt]);
                DataGridView grid = new DataGridView();

                grid.Dock = DockStyle.Fill;
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.AllowUserToResizeColumns = false;
                grid.AllowUserToResizeRows = false;
                grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                grid.BackgroundColor = Color.White;

                TabPage tabP = new TabPage();
                tabP.Text = "P" + Convert.ToString(j + 1);
                tabControl2.Controls.Add(tabP);
                tabP.Controls.Add(grid);
                tabControl2.Refresh();

                for (int i = 0; i < alternativeCnt; i++) {
                    var column = new DataGridViewColumn();
                    column.HeaderText = "a" + Convert.ToString(i + 1);
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    grid.Columns.Add(column);

                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = "a" + Convert.ToString(i + 1);
                    grid.Rows.Add(row);
                }

                DataGridView dgv2 = tabControl1.TabPages[j].Controls[0] as DataGridView;

                for (int i = 0; i < alternativeCnt; i++) {
                    for (int k = 0; k < alternativeCnt; k++) {
                        var val = Func(j, Convert.ToDouble(dgv2[k, i].Value));
                        StepTwoMatr[j][i, k] = val;
                        grid[k, i].Value = Math.Round(val, 3);
                    }
                }
            }
        }

        private double Func(int J, double d) {
            string func = dgv1[J, 0].ToString();
            string funcType = dgv1[J, 1].ToString();
            double q = 0;
            double s = 0;

            if (func == "Обычная функция") // без q и s
            {
                if (funcType == "Положительно направленный") {
                    if (d <= 0)
                        return 0;
                    else
                        return 1;
                }
                if (funcType == "Отрицательно направленный") {
                    if (d <= 0)
                        return 1;
                    else
                        return 0;
                }
            }
            if (func == "U-образная функция") //без s
            {
                q = Convert.ToDouble(dgv1[J, 2]);
                if (funcType == "Положительно направленный") {
                    if (d <= q)
                        return 0;
                    else
                        return 1;
                }
                if (funcType == "Отрицательно направленный") {
                    if (d <= q)
                        return 1;
                    else
                        return 0;
                }
            }
            if (func == "V-образная функция") // без q
            {
                s = Convert.ToDouble(dgv1[J, 3]);
                if (funcType == "Положительно направленный") {
                    if (d <= 0)
                        return 0;

                    if (d > 0 && d <= s)
                        return d / s;

                    if (d > s)
                        return 1;
                }
                if (funcType == "Отрицательно направленный") {
                    if (d <= 0)
                        return 1;

                    if (d > 0 && d <= s)
                        return d / s;

                    if (d > s)
                        return 0;
                }
            }
            if (func == "Уровневая функция") {
                q = Convert.ToDouble(dgv1[J, 2]);
                s = Convert.ToDouble(dgv1[J, 3]);
                if (funcType == "Положительно направленный") {
                    if (d <= q)
                        return 0;

                    if (d > q && d <= s)
                        return 0.5;

                    if (d > s)
                        return 1;
                }
                if (funcType == "Отрицательно направленный") {
                    if (d <= q)
                        return 1;

                    if (d > q && d <= s)
                        return 0.5;

                    if (d > s)
                        return 0;
                }
            }
            if (func == "V-образная функция с порогами безразличия") {
                q = Convert.ToDouble(dgv1[J, 2]);
                s = Convert.ToDouble(dgv1[J, 3]);
                if (funcType == "Положительно направленный") {
                    if (d <= q)
                        return 0;

                    if (d > q && d <= s)
                        return (d - q) / (s - q);

                    if (d > s)
                        return 1;
                }
                if (funcType == "Отрицательно направленный") {
                    if (d <= q)
                        return 1;

                    if (d > q && d <= s)
                        return 1 - ((d - q) / (s - q));

                    if (d > s)
                        return 0;
                }
            }
            return 0;
        }

        private void StepThree() {
            //tabControl3.Width = 800;
            //tabControl3.Height = 200;

            int cnt1 = tabControl3.TabPages.Count;
            for (int i = cnt1 - 1; i >= 0; i--) {
                tabControl3.TabPages.RemoveAt(i);
            }

            DataGridView grid = new DataGridView();

            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.BackgroundColor = System.Drawing.Color.White;

            TabPage tabP = new TabPage();
            tabP.Text = "Индексы предпочтения для каждой альтернативы";
            tabControl3.Controls.Add(tabP);
            tabP.Controls.Add(grid);
            tabControl3.Refresh();
            StepThreeMatr.Add(new double[alternativeCnt + 1, alternativeCnt + 1]);

            for (int i = 0; i < alternativeCnt + 1; i++) {
                var column = new DataGridViewColumn();
                if (i == alternativeCnt) {
                    column.HeaderText = "Ф +";
                }
                else {
                    column.HeaderText = "a" + Convert.ToString(i + 1);
                }

                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                grid.Columns.Add(column);

                DataGridViewRow row = new DataGridViewRow();
                if (i == alternativeCnt) {
                    row.HeaderCell.Value = "Ф -";
                }
                else {
                    row.HeaderCell.Value = "a" + Convert.ToString(i + 1);
                }
                grid.Rows.Add(row);
            }

            for (int i = 0; i < alternativeCnt; i++) {
                for (int k = 0; k < alternativeCnt; k++) {
                    double Elem = 0;
                    for (int j = 0; j < critCnt; j++) {
                        DataGridView dgv2 = tabControl2.TabPages[j].Controls[0] as DataGridView;

                        Elem = Elem + Convert.ToDouble(dgv2[k, i].Value) * Convert.ToDouble(dgv1[j, 4]);
                    }
                    Elem = Math.Round(Elem, 3);
                    grid[k, i].Value = Elem;
                    StepThreeMatr[0][i, k] = Elem;
                }
            }
            for (int i = 0; i < alternativeCnt; i++) {
                double Elem = 0;
                for (int k = 0; k < alternativeCnt; k++) {
                    Elem = Elem + Convert.ToDouble(grid[k, i].Value);
                }
                Elem = Math.Round(Elem, 3);
                grid[alternativeCnt, i].Value = Elem;
                StepThreeMatr[0][i, alternativeCnt] = Elem;
            }

            for (int i = 0; i < alternativeCnt; i++) {
                double Elem = 0;
                for (int k = 0; k < alternativeCnt; k++) {
                    Elem = Elem + Convert.ToDouble(grid[i, k].Value);
                }
                Elem = Math.Round(Elem, 3);
                grid[i, alternativeCnt].Value = Elem;
                StepThreeMatr[0][alternativeCnt, i] = Elem;
            }
        }

        private void StepFour() {
            double[,] Mas = new double[alternativeCnt, alternativeCnt];
            for (int i = 0; i < alternativeCnt; i++) {
                Mas[1, i] = i + 1;
            }
            DataGridView dgv1 = tabControl3.TabPages[0].Controls[0] as DataGridView;

            for (int i = 0; i < alternativeCnt; i++) {
                Mas[0, i] = Convert.ToDouble(dgv1[alternativeCnt, i].Value) - Convert.ToDouble(dgv1[i, alternativeCnt].Value);
            }

            lbFour.Items.Clear();
            for (int i = 0; i < alternativeCnt; i++) {
                lbFour.Items.Add("Φ(a" + Convert.ToString(i + 1) + ") = Φ+(a" + Convert.ToString(i + 1) + ") - Φ-(a" + Convert.ToString(i + 1) + ") = " + Math.Round(Mas[0, i], 4));
            }


            for (int i = 0; i < alternativeCnt - 1; i++) {
                for (int j = i + 1; j < alternativeCnt; j++) {
                    if (Mas[0, i] < Mas[0, j]) {
                        double temp = Mas[0, i];
                        Mas[0, i] = Mas[0, j];
                        Mas[0, j] = temp;

                        double temp1 = Mas[1, i];
                        Mas[1, i] = Mas[1, j];
                        Mas[1, j] = temp1;
                    }
                }
            }

            lbResult.Items.Clear();
            for (int i = 0; i < alternativeCnt; i++) {
                lbResult.Items.Add(altern[(int)Mas[1, i] - 1].ToString());
            }

            lblResult.Text = Mess;
        }
    }
}
