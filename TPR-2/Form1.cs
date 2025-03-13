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

namespace TPR_2
{
    public partial class Form1 : Form
    {
        // "дерево" событий
        List<List<InputResult>> events = new List<List<InputResult>>();
        int current_OS = 0;
        List<double> riskOS = new List<double>();

        public Form1()
        {
            InitializeComponent();
            events.Add(new List<InputResult>());

            // настраиваем корневое событие
            cbRootType.SelectedIndex = 0; // И
            InitRoot();
            listBox1.Items.Add("Конечное событие");
        }

        private void InitRoot()
        {
            InputResult.counter = 0;
            events[current_OS].Add(new InputResult(TypeElem.And)
            {
                Name = tbRootName.Text,
                Parent = null
            });
            SyncTree();
        }

        private void InitRoot(string name)
        {
            InputResult.counter = 0;
            events[current_OS].Add(new InputResult(TypeElem.And)
            {
                Name = name,
                Parent = null
            });
            SyncTree();
        }

        // удаление
        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                RemoveRecursive(treeView.SelectedNode.Tag as InputResult);
                SyncTree();

                if (events[current_OS].Count == 0)
                {
                    InitRoot();
                }
            }
        }

        // удаление узла
        private void RemoveRecursive(InputResult forDelete)
        {
            events[current_OS].Remove(forDelete);
            var childs = events[current_OS].FindAll((ev) => ev.Parent?.Name == forDelete.Name).ToList();
            for(int i = 0; i < childs.Count; i++)
            {
                RemoveRecursive(childs[i]);
            }
        }

        // добавление
        private void button1_Click(object sender, EventArgs e)
        {
            var selected = treeView.SelectedNode ?? treeView.Nodes[0];

            TypeElem type = rbProb.Checked
                ? TypeElem.Init
                : rbAnd.Checked ? TypeElem.And : TypeElem.Or;

            var form = new InputForm(type, selected.Tag as InputResult);
            form.ShowDialog();

            if (!string.IsNullOrEmpty(form.Result.Name))
            {
                events[current_OS].Add(form.Result);
                SyncTree();
            }
            else
                InputResult.counter--;
        }

        // отобразить "дерево" событий в контроле дерева
        private void SyncTree()
        {
            treeView.Nodes.Clear();
            events[current_OS].ForEach(e =>
            {
                string prefix = "";
                string postfix = "";
                switch (e.Type)
                {
                    case TypeElem.And:
                        prefix = "[И] ";
                        break;
                    case TypeElem.Or:
                        prefix = "[ИЛИ] ";
                        break;
                }

                if (e.Probably != null)
                {
                    postfix = $", p = {e.Probably}";
                }

                var node = new TreeNode()
                {
                    Name = e.Name,
                    Text = $"{prefix}{e.Name} (X{e.Id}{postfix})",
                    Tag = e
                };

                TreeNode parent = null;
                if (e.Parent != null)
                    parent = treeView.Nodes.Find(e.Parent.Name, true).First();

                if (parent != null)
                    parent.Nodes.Add(node);
                else
                    treeView.Nodes.Add(node);
            });

            treeView.ExpandAll();
        }

        // при изменении типа конечного события (И, ИЛИ)
        private void cbRootType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (events.Count > 0 && events[current_OS].Count > 0)
            {
                events[current_OS][0].Type = cbRootType.SelectedIndex == 0 ? TypeElem.And : TypeElem.Or;
                SyncTree();
            }
        }

        // при изменении названия конечного события
        private void tbRootName_TextChanged(object sender, EventArgs e)
        {
            if (events[current_OS].Count > 0)
            {
                events[current_OS][0].Name = tbRootName.Text;
                SyncTree();
            }
        }

        private double? SetProbRecursive(InputResult node)
        {
            if (node.Type == TypeElem.Init)
            {
                return node.Probably;
            }

            var childs = events[current_OS].FindAll((ev) => ev.Parent?.Name == node.Name).ToList();

            double? sum = node.Type == TypeElem.And ? 1 : 0;

            for (int i = 0; i < childs.Count; i++)
            {
                if (node.Type == TypeElem.And)
                    sum *= SetProbRecursive(childs[i]);
                else
                    sum += SetProbRecursive(childs[i]);
            }

            node.Probably = sum;
            return sum;
        }

        // Расчет ФАЛ и вероятностной функции
        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                SetProbRecursive(treeView.Nodes[0].Tag as InputResult);
                SyncTree();


                // ФАЛ
                var table = GetFAL(treeView.Nodes[0]);

                var diz = new List<string>();
                for (int i = 0; i < table.Count; i++)
                {
                    var kon = new List<string>();
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        kon.Add($"X{table[i][j].Id}");
                    }
                    diz.Add($"({String.Join("∩", kon)})");
                }
                tbFAL.Text = String.Join("U", diz);

                // Вероятностная функция
                var muls = new List<string>();
                muls.Add("1-(");
                for (int i = 0; i < table.Count; i++)
                {
                    var mul = new List<string>();
                    for (int j = 0; j < table[i].Count; j++)
                    {
                        mul.Add($"X{table[i][j].Id}");
                    }
                    muls.Add($"(1-{String.Join("*", mul)})");
                }
                muls.Add(")");
                tbCalc.Text = String.Join("", muls);

                var probably = table.Sum(row => row.Select(elem => elem.Probably).Aggregate((acc, prob) => acc * prob));
                lblProb.Text = $"Вероятность риска: {probably}";

                var riskValue = probably * Convert.ToDouble(nudCost.Value);
                lblOcenka.Text = $"Оценка риска: {riskValue}";
                if (riskValue != null)
                {
                    double tmp = (double)riskValue;
                    riskOS.Add(tmp);
                }
            }
        }

        // Функция алгебры логики
        // модель представления СДНФ
        private List<List<InputResult>> GetFAL(TreeNode node)
        {
            var res = node.Tag as InputResult;
            var type = res.Type;
            var list = new List<List<InputResult>>();

            if (type == TypeElem.Init)
            {
                var one = new List<InputResult>();
                one.Add(res);
                list.Add(one);
            } 
            else 
            {
                var count = node.Nodes.Count;
                
                if (type == TypeElem.And)
                {
                    var temp = new List<List<List<InputResult>>>();

                    for (int i = 0; i < count; i++)
                    {
                        temp.Add(GetFAL(node.Nodes[i]));
                    }

                    var result = new List<List<InputResult>>();
                    DecartMul(temp, new List<InputResult>(), 0, result);

                    list.AddRange(result);

                } 
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        list.AddRange(GetFAL(node.Nodes[i]));
                    }
                }
            }

            return list;
        }

        // декартово произведение матриц
        private void DecartMul(List<List<List<InputResult>>> table, List<InputResult> currentSet, int column, List<List<InputResult>> result)
        {
            if (table.Count == column)
            {
                result.Add(currentSet);
                return;
            } 

            var items = table[column];
            for (int i = 0; i < items.Count; i++)
            {
                var list = new List<InputResult>(currentSet);
                list.AddRange(items[i]);
                DecartMul(table, list, column + 1, result);
            }
        }

        private bool Check()
        {
            for (int i = 0; i < events[current_OS].Count; i++)
            {
                if (events[current_OS][i].Type != TypeElem.Init)
                {
                    var firstChild = events[current_OS].Find((ev) => ev.Parent?.Name == events[current_OS][i].Name);
                    if (firstChild == null)
                    {
                        MessageBox.Show($"У промежуточного события \"{events[current_OS][i].Name}\" нет инициирующих");
                        return false;
                    }
                }
            }

            return true;
        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(ofd.FileName))
                {
                    events.Clear();
                    listBox1.Items.Clear();
                    var countOS = Convert.ToDecimal(sr.ReadLine());
                    for (int j = 0; j < countOS; j++)
                    {
                        listBox1.Items.Add(sr.ReadLine());
                        events.Add(new List<InputResult>());
                        //              events.Clear();
                        var tmp = sr.ReadLine();
                        var _value = Convert.ToDecimal(tmp);
                        var count = Convert.ToInt32(sr.ReadLine());

                        TypeElem type;
                        string typeText, name, idText, parentText, probablyText;
                        var parentNames = new List<string>();
                        for (int i = 0; i < count; i++)
                        {
                            typeText = sr.ReadLine();
                            name = sr.ReadLine();
                            idText = sr.ReadLine();
                            parentText = sr.ReadLine();
                            probablyText = sr.ReadLine();

                            switch (typeText)
                            {
                                case "And":
                                    type = TypeElem.And;
                                    break;
                                case "Or":
                                    type = TypeElem.Or;
                                    break;
                                default:
                                    type = TypeElem.Init;
                                    break;
                            }

                            // для конечного события
                            if (i == 0)
                            {
                          //      cbRootType.SelectedIndex = type == TypeElem.And ? 0 : 1;
                               // tbRootName.Text = name;
                            }

                            parentNames.Add(parentText);

                            var res = new InputResult(type) { Name = name, value = _value }; 
                            res.Id = Convert.ToInt32(idText);

                            if (type == TypeElem.Init)
                            {
                                res.Probably = Convert.ToDouble(probablyText);
                            }

                            events[j].Add(res);
                        }

                        for (int i = 0; i < events[j].Count; i++)
                        {
                            events[j][i].Parent = string.IsNullOrEmpty(parentNames[i])
                                        ? null
                                        : events[j].Find(x => x.Id == Convert.ToInt32(parentNames[i]));
                        }
                    }
                }

                SyncTree();
            }
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine(listBox1.Items.Count);
                    for (int i = 0; i < events.Count; i++)
                    {
                        sw.WriteLine(listBox1.Items[i]);
                        sw.WriteLine(events[i][0].value);
                        sw.WriteLine(events[i].Count);

                        string typeText;
                        events[i].ForEach(ev =>
                        {
                            switch (ev.Type)
                            {
                                case TypeElem.And:
                                    typeText = "And";
                                    break;
                                case TypeElem.Or:
                                    typeText = "Or";
                                    break;
                                default:
                                    typeText = "Init";
                                    break;
                            }

                            sw.WriteLine(typeText);
                            sw.WriteLine(ev.Name);
                            sw.WriteLine(ev.Id);
                            sw.WriteLine(ev.Parent?.Id);
                            sw.WriteLine(ev.Probably);
                        });
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = treeView.SelectedNode;

            var form = new InputForm(selected.Tag as InputResult);
            form.ShowDialog();
            SyncTree();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var isRoot = treeView.SelectedNode.Tag == events[0];

            btnEdit.Enabled = !isRoot;
            btnDelete.Enabled = !isRoot;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
                events.Add(new List<InputResult>());
                current_OS = listBox1.Items.Count - 1;
                InitRoot(textBox1.Text);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                current_OS = listBox1.SelectedIndex;
                cbRootType.SelectedIndex = events[current_OS][0].Type == TypeElem.And ? 0 : 1;
                nudCost.Value = events[current_OS][0].value;
                tbRootName.Text = events[listBox1.SelectedIndex][0].Name;
                SyncTree();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1)
            {
                current_OS = 0;
                events.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.SelectedIndex = 0;
                //       SyncTree();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (riskOS.Count == listBox1.Items.Count)
            {
                label4.Text = "Оценка риска по всем ОС: " + riskOS.Sum();
            }
            else
            {
                MessageBox.Show("Для рассчета оценки риска по ИС, предворительно, необходимо рассчитать оценку риска для каждого ОС");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && listBox1.SelectedIndex != -1)
            {
                tbRootName.Text = textBox1.Text;
                events[listBox1.SelectedIndex][0].Name = textBox1.Text;
                SyncTree();
                int index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index, textBox1.Text);
            }
        }

        private void nudCost_ValueChanged(object sender, EventArgs e)
        {
            events[current_OS][0].value = nudCost.Value;
        }
    }
}
