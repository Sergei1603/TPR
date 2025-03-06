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
        List<InputResult> events = new List<InputResult>();

        public Form1()
        {
            InitializeComponent();

            // настраиваем корневое событие
            cbRootType.SelectedIndex = 0; // И
            InitRoot();
        }

        private void InitRoot()
        {
            InputResult.counter = 0;
            events.Add(new InputResult(TypeElem.And)
            {
                Name = tbRootName.Text,
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

                if (events.Count == 0)
                {
                    InitRoot();
                }
            }
        }

        // удаление узла
        private void RemoveRecursive(InputResult forDelete)
        {
            events.Remove(forDelete);
            var childs = events.FindAll((ev) => ev.Parent?.Name == forDelete.Name).ToList();
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
                events.Add(form.Result);
                SyncTree();
            }
            else
                InputResult.counter--;
        }

        // отобразить "дерево" событий в контроле дерева
        private void SyncTree()
        {
            treeView.Nodes.Clear();
            events.ForEach(e =>
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
            if (events.Count > 0)
            {
                events[0].Type = cbRootType.SelectedIndex == 0 ? TypeElem.And : TypeElem.Or;
                SyncTree();
            }
        }

        // при изменении названия конечного события
        private void tbRootName_TextChanged(object sender, EventArgs e)
        {
            if (events.Count > 0)
            {
                events[0].Name = tbRootName.Text;
                SyncTree();
            }
        }

        private double? SetProbRecursive(InputResult node)
        {
            if (node.Type == TypeElem.Init)
            {
                return node.Probably;
            }

            var childs = events.FindAll((ev) => ev.Parent?.Name == node.Name).ToList();

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
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Type != TypeElem.Init)
                {
                    var firstChild = events.Find((ev) => ev.Parent?.Name == events[i].Name);
                    if (firstChild == null)
                    {
                        MessageBox.Show($"У промежуточного события \"{events[i].Name}\" нет инициирующих");
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
                    nudCost.Value = Convert.ToDecimal(sr.ReadLine());
                    var count = Convert.ToInt32(sr.ReadLine());

                    TypeElem type;
                    string typeText, name, idText, parentText, probablyText;
                    var parentNames = new List<string>();
                    for (int i = 0;i < count; i++)
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
                            cbRootType.SelectedIndex = type == TypeElem.And ? 0 : 1;
                            tbRootName.Text = name;
                        }

                        parentNames.Add(parentText);

                        var res = new InputResult(type) { Name = name };
                        res.Id = Convert.ToInt32(idText);

                        if (type == TypeElem.Init)
                        {
                            res.Probably = Convert.ToDouble(probablyText);
                        }

                        events.Add(res);
                    }

                    for (int i = 0; i < events.Count; i++)
                    {
                        events[i].Parent = string.IsNullOrEmpty(parentNames[i])
                                    ? null
                                    : events.Find(x => x.Id == Convert.ToInt32(parentNames[i]));
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
                    sw.WriteLine(nudCost.Value);
                    sw.WriteLine(events.Count);

                    string typeText;
                    events.ForEach(ev =>
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
    }
}
