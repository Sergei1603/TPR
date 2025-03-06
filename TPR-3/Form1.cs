using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPR_3
{
    public partial class Form1 : Form
    {
        int firstStrategiesCount;
        int secondStrategiesCount;

        int firstStartStrategy;
        int secondStartStrategy;

        double iterationsCount;
        double precision;
        double[,] payMatrix;

        int outWidth;

        public Form1()
        {
            InitializeComponent();

            CreateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void CreateTable()
        {
            payGrid.Rows.Clear();
            payGrid.Columns.Clear();

            firstStrategiesCount = Convert.ToInt32(nudPlayer1.Value);
            secondStrategiesCount = Convert.ToInt32(nudPlayer2.Value);

            for (int i = 0; i < secondStrategiesCount; i++)
            {

                var column = new DataGridViewColumn();
                column.HeaderText = "y" + Convert.ToString(i + 1);
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.CellTemplate = new DataGridViewTextBoxCell();

                payGrid.Columns.Add(column);
            }

            for (int i = 0; i < firstStrategiesCount; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = "x" + Convert.ToString(i + 1);
                payGrid.Rows.Add(row);
            }
        }

        // Вычисление
        private void button2_Click(object sender, EventArgs e)
        {
            iterGrid.Rows.Clear();
            iterGrid.Columns.Clear();

            firstStartStrategy = Convert.ToInt32(nudStart1.Value);
            secondStartStrategy = Convert.ToInt32(nudStart2.Value);
            iterationsCount = Convert.ToDouble(nudIterations.Value);

            // заполняем модель
            payMatrix = new double[firstStrategiesCount, secondStrategiesCount];
            for (int i = 0; i < firstStrategiesCount; i++)
            {
                for (int j = 0; j < secondStrategiesCount; j++)
                {
                    payMatrix[i, j] = Convert.ToDouble(payGrid[j, i].Value);
                }
            }

            // максимин
            double[] MaxMin = new double[firstStrategiesCount];
            double MaxMins = 0;

            for (int i = 0; i < firstStrategiesCount; i++)
            {
                double Min = double.MaxValue;

                for (int j = 0; j < secondStrategiesCount; j++)
                    if (payMatrix[i, j] < Min)
                        Min = payMatrix[i, j];

                MaxMin[i] = Min;
            }

            double Max = double.MinValue;
            int sedloX = -1;
            for (int i = 0; i < firstStrategiesCount; i++)
            {
                if (MaxMin[i] > Max)
                {
                    Max = MaxMin[i];
                    sedloX = i;
                }
                MaxMins = Max;
            }

            // минимакс

            double[] MinMax = new double[secondStrategiesCount];
            double MinMaxs = 0;


            for (int i = 0; i < secondStrategiesCount; i++)
            {
                double Maxs = double.MinValue;
                for (int j = 0; j < firstStrategiesCount; j++)
                {
                    if (payMatrix[j, i] > Maxs)
                    {
                        Maxs = payMatrix[j, i];
                    }
                }
                MinMax[i] = Maxs;
            }

            double Mins = double.MaxValue;
            int sedloY = 0;
            for (int i = 0; i < secondStrategiesCount; i++)
            {

                if (MinMax[i] < Mins)
                {
                    Mins = MinMax[i];
                    sedloY = i;
                }
                MinMaxs = Mins;
            }

            // проверка на седловую точку
            if (MinMaxs == MaxMins)
            {
                MessageBox.Show(
                    "Существует седловая точка. Максимин и минимакс равны, седловая точка имеет координаты " +
                    $"({sedloX + 1}, {sedloY + 1}), " +
                    $"значение цены игры равно {payMatrix[sedloX, sedloY]}",
                    "Сообщение"
                );
                return;
            }


            //----------------------------------------------------------------------------------------------------------------------
            outWidth = 5 + firstStrategiesCount + secondStrategiesCount;

            for (int i = 0; i < outWidth; i++)
            {
                var column = new DataGridViewColumn();
                if (i == 0)
                    column.HeaderText = "k";

                if (i == 1)
                    column.HeaderText = "j";

                if (i > 1 && i < (firstStrategiesCount + 2))
                    column.HeaderText = $"g{i-1}";

                if (i == firstStrategiesCount + 2)
                    column.HeaderText = "Mk";

                if (i == firstStrategiesCount + 3)
                    column.HeaderText = "Vk";

                int j = firstStrategiesCount + 3;
                if (i > j && i < (secondStrategiesCount + j + 1))
                    column.HeaderText = $"h{i - j}";

                if (i == secondStrategiesCount + j + 1)
                    column.HeaderText = "i";

                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                iterGrid.Columns.Add(column);
            }

            //стратегия первого на текущей итерации
            int I = firstStartStrategy;

            //стратегия второго на текущей итерации
            int J = secondStartStrategy; 

            double[] g = Enumerable.Repeat<double>(0, firstStrategiesCount).ToArray();
            double[] h = Enumerable.Repeat<double>(0, secondStrategiesCount).ToArray(); ;


            List<int> G = new List<int>();
            List<int> H = new List<int>();

            double razn = 100;
            var maxIterations = 500;
            precision = Convert.ToDouble(nudPrecision.Value);

            int iter = 0;
            bool condition = rbIteration.Checked
                ? iter < iterationsCount
                : precision < razn;

            while (condition)
            {
                // выход, не доходя до заданной точности
                if (rbPrecision.Checked && iter >= maxIterations)
                {
                    MessageBox.Show($"Достигнуто максимальное количество итераций = {maxIterations}");
                    break;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = $"{iter + 1} итерация";
                iterGrid.Rows.Add(row);

                G.Add(I);
                H.Add(J);

                for (int j = 0; j < firstStrategiesCount; j++)
                {
                    g[j] = g[j] + payMatrix[j, J - 1];
                }

                for (int j = 0; j < secondStrategiesCount; j++)
                {
                    h[j] = h[j] + payMatrix[I - 1, j];
                }
                int z1 = 0;
                int z2 = 0;

                for (int j = 0; j < outWidth; j++)
                {
                    if (j == 0)
                        iterGrid[j, iter].Value = iter + 1;

                    if (j == 1)
                        iterGrid[j, iter].Value = J;

                    if (j > 1 && j < (firstStrategiesCount + 2))
                    {
                        iterGrid[j, iter].Value = g[z1];
                        z1 = z1 + 1;
                    }

                    int k = firstStrategiesCount + 3;
                    if (j > k && j < (secondStrategiesCount + k + 1))
                    {
                        iterGrid[j, iter].Value = h[z2];
                        z2 = z2 + 1;
                    }

                    if (j == secondStrategiesCount + k + 1)
                        iterGrid[j, iter].Value = I;
                }

                double min = double.MaxValue;
                for (int j = 0; j < firstStrategiesCount; j++)
                {
                    if ((g[j] / (iter + 1)) < min)
                    {
                        min = g[j] / (iter + 1);
                        I = j + 1;
                    }
                }
                double max = double.MinValue;
                for (int j = 0; j < secondStrategiesCount; j++)
                {
                    if ((h[j] / (iter + 1)) > max)
                    {
                        max = h[j] / (iter + 1);
                        J = j + 1;
                    }
                }

                iterGrid[firstStrategiesCount + 2, iter].Value = min;
                lblNiz.Text = $"Нижняя цена игры: {min}";

                iterGrid[firstStrategiesCount + 3, iter].Value = max;
                lblVerh.Text = $"Верхняя цена игры: {max}";
                lblCost.Text = $"Цена игры: {min + (max - min) / 2}";


                iter++;
                if (rbPrecision.Checked)
                    razn = max - min;

                condition = rbIteration.Checked
                    ? iter < iterationsCount
                    : precision < razn;
            }

            // смешанные стратегии первого
            double[] mixedstrategy1 = new double[firstStrategiesCount];
            for (int i = 0; i < firstStrategiesCount; i++)
            {
                mixedstrategy1[i] = 0;
            }

            // считаем частоту
            for (int i = 0; i < G.Count; i++)
            {
                mixedstrategy1[Convert.ToInt32(G[i]) - 1] = mixedstrategy1[Convert.ToInt32(G[i]) - 1] + 1;
            }

            lbStrategies1.Items.Clear();
            for (int i = 0; i < secondStrategiesCount; i++)
            {

                double p = 0;
                if (mixedstrategy1[i] == 0)
                {
                    p = 0;
                }
                if (mixedstrategy1[i] == iterationsCount)
                {
                    p = 1;
                }
                if (mixedstrategy1[i] != 0 && mixedstrategy1[i] != iterationsCount)
                {
                    p = mixedstrategy1[i] / iterationsCount;
                }


                lbStrategies1.Items.Add($"p{i + 1} = {p}");
            }

            // смешанные стратегии второго
            double[] mixedstrategy2 = new double[secondStrategiesCount];
            for (int i = 0; i < secondStrategiesCount; i++)
            {
                mixedstrategy2[i] = 0.0;
            }

            for (int i = 0; i < H.Count; i++)
            {
                mixedstrategy2[Convert.ToInt32(H[i]) - 1] = mixedstrategy2[Convert.ToInt32(H[i]) - 1] + 1;
            }

            lbStrategies2.Items.Clear();
            for (int i = 0; i < secondStrategiesCount; i++)
            {

                double p = 0;
                if (mixedstrategy2[i] == 0)
                {
                    p = 0;
                }
                if (mixedstrategy2[i] == iterationsCount)
                {
                    p = 1;
                }
                if (mixedstrategy2[i] != 0 && mixedstrategy2[i] != iterationsCount)
                {
                    p = mixedstrategy2[i] / iterationsCount;
                }


                lbStrategies2.Items.Add($"p{i + 1} = {p}");
            }
        }

        private void rbIteration_CheckedChanged(object sender, EventArgs e)
        {
            nudIterations.Enabled = rbIteration.Checked;
            nudPrecision.Enabled = rbPrecision.Checked;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine(firstStrategiesCount);
                    sw.WriteLine(secondStrategiesCount);

                    for (int i = 0; i < firstStrategiesCount; i++)
                    {
                        for (int j = 0; j < secondStrategiesCount; j++)
                        {
                            sw.WriteLine(payGrid.Rows[i].Cells[j].Value);
                        }
                    }

                    sw.WriteLine(firstStartStrategy);
                    sw.WriteLine(secondStartStrategy);

                    sw.WriteLine(rbIteration.Checked ? "1" : "0");

                    sw.WriteLine(nudIterations.Value);
                    sw.WriteLine(nudPrecision.Value);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(ofd.FileName))
                {
                    firstStrategiesCount = Convert.ToInt32(sr.ReadLine());
                    secondStrategiesCount = Convert.ToInt32(sr.ReadLine());

                    nudPlayer1.Value = firstStrategiesCount;
                    nudPlayer2.Value = secondStrategiesCount;

                    CreateTable();

                    for (int i = 0; i < firstStrategiesCount; i++)
                    {
                        for (int j = 0; j < secondStrategiesCount; j++)
                        {
                            payGrid.Rows[i].Cells[j].Value = Convert.ToDouble(sr.ReadLine());
                        }
                    }

                    firstStartStrategy = Convert.ToInt32(sr.ReadLine());
                    secondStartStrategy = Convert.ToInt32(sr.ReadLine());

                    nudStart1.Value = firstStartStrategy;
                    nudStart2.Value = secondStartStrategy;

                    // 1 - итерации, 0 - точность
                    var isIteration = sr.ReadLine() == "1";

                    rbIteration.Checked = isIteration;
                    rbPrecision.Checked = !isIteration;
                   
                    nudIterations.Value = Convert.ToDecimal(sr.ReadLine());
                    nudPrecision.Value = Convert.ToDecimal(sr.ReadLine());
                }
            }
        }
    }
}
