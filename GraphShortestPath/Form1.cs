using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GraphShortestPath
{
    public partial class Form1 : Form
    {
        private Graph graph;

        public Form1()
        {
            InitializeComponent();
            graph = new Graph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            var input = txtVert.Text;
            var vertices = input.Split(',');

            foreach (var vertex in vertices)
            {
                if (int.TryParse(vertex.Trim(), out int v))
                {
                    graph.AddVertex(v);
                }
            }

            MessageBox.Show("Вершины добавлены.");
            txtVert.Clear();
        }


        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFrom.Text, out int from) && int.TryParse(txtTo.Text, out int to))
            {
                // Передаём состояние чекбокса для указания типа графа
                bool isDirected = checkBox1.Checked;
                graph.AddEdge(from, to);

                string edgeType = isDirected ? "направленное" : "ненаправленное";
                MessageBox.Show($"Добавлено {edgeType} ребро между {from} и {to}.");

                txtFrom.Clear();
                txtTo.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректные номера вершин.");
            }
        }


        private void btnFindPath_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStart.Text, out int start) && int.TryParse(txtEnd.Text, out int end))
            {
                try
                {
                    List<int> path = BFS.FindShortestPath(graph, start, end);
                    if (path.Count > 0)
                    {
                        MessageBox.Show($"Кратчайший путь: {string.Join(" -> ", path)}");
                    }
                    else
                    {
                        MessageBox.Show("Путь не найден.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные номера начальной и конечной вершин.");
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Сохранить результат"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var resultPath = BFS.FindShortestPath(graph, int.Parse(txtStart.Text), int.Parse(txtEnd.Text));
                    FileManager.SavePathToFile(saveFileDialog.FileName, resultPath);
                    MessageBox.Show("Результат успешно сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void btnLoadGraph_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Все поддерживаемые форматы|*.txt;*.xml|Текстовые файлы (*.txt)|*.txt|XML файлы (*.xml)|*.xml",
                Title = "Загрузить граф"
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog.FileName.EndsWith(".txt"))
                    {
                        graph = FileManager.LoadGraphFromFile(openFileDialog.FileName);
                    }
                    else if (openFileDialog.FileName.EndsWith(".xml"))
                    {
                        graph = FileManager.LoadGraphFromXmlFile(openFileDialog.FileName, checkBox1.Checked);
                    }
                    MessageBox.Show("Граф успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("Ребро направленное");
            }
            else
            {
                MessageBox.Show("Ребро не направленый");
            }
        }

        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            // Получаем состояние чекбокса
            bool isDirected = checkBox1.Checked;

            var dialogResult = MessageBox.Show(
                "Выберите действие:\n\n" +
                "Да - Удалить весь граф\n" +
                "Нет - Удалить только ребра\n" +
                "Отмена - Удалить определенную вершину/ребро",
                "Очистка графа",
                MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                graph = new Graph(isDirected);
                MessageBox.Show("Граф полностью очищен.");
            }
            else if (dialogResult == DialogResult.No)
            {
                graph.ClearEdges();
                MessageBox.Show("Все ребра удалены, вершины сохранены.");
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Введите вершину (или два числа через дефис для удаления ребра):",
                    "Удаление элемента графа");

                if (input.Contains("-"))
                {
                    var vertices = input.Split('-');
                    if (vertices.Length == 2 &&
                        int.TryParse(vertices[0], out int from) &&
                        int.TryParse(vertices[1], out int to))
                    {
                        graph.RemoveEdge(from, to);
                        MessageBox.Show($"Ребро {from}-{to} удалено.");
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод.");
                    }
                }
                else if (int.TryParse(input, out int vertex))
                {
                    graph.RemoveVertex(vertex);
                    MessageBox.Show($"Вершина {vertex} удалена.");
                }
                else
                {
                    MessageBox.Show("Некорректный ввод.");
                }
            }
        }

        
    }
}

