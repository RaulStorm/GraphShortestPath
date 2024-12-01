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

            MessageBox.Show("������� ���������.");
            txtVert.Clear();
        }


        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFrom.Text, out int from) && int.TryParse(txtTo.Text, out int to))
            {
                // ������� ��������� �������� ��� �������� ���� �����
                bool isDirected = checkBox1.Checked;
                graph.AddEdge(from, to);

                string edgeType = isDirected ? "������������" : "��������������";
                MessageBox.Show($"��������� {edgeType} ����� ����� {from} � {to}.");

                txtFrom.Clear();
                txtTo.Clear();
            }
            else
            {
                MessageBox.Show("������� ���������� ������ ������.");
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
                        MessageBox.Show($"���������� ����: {string.Join(" -> ", path)}");
                    }
                    else
                    {
                        MessageBox.Show("���� �� ������.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("������� ���������� ������ ��������� � �������� ������.");
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "��������� ���������"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var resultPath = BFS.FindShortestPath(graph, int.Parse(txtStart.Text), int.Parse(txtEnd.Text));
                    FileManager.SavePathToFile(saveFileDialog.FileName, resultPath);
                    MessageBox.Show("��������� ������� ��������!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������: {ex.Message}");
                }
            }
        }

        private void btnLoadGraph_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "��� �������������� �������|*.txt;*.xml|��������� ����� (*.txt)|*.txt|XML ����� (*.xml)|*.xml",
                Title = "��������� ����"
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
                    MessageBox.Show("���� ������� ��������!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������: {ex.Message}");
                }
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("����� ������������");
            }
            else
            {
                MessageBox.Show("����� �� �����������");
            }
        }

        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            // �������� ��������� ��������
            bool isDirected = checkBox1.Checked;

            var dialogResult = MessageBox.Show(
                "�������� ��������:\n\n" +
                "�� - ������� ���� ����\n" +
                "��� - ������� ������ �����\n" +
                "������ - ������� ������������ �������/�����",
                "������� �����",
                MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                graph = new Graph(isDirected);
                MessageBox.Show("���� ��������� ������.");
            }
            else if (dialogResult == DialogResult.No)
            {
                graph.ClearEdges();
                MessageBox.Show("��� ����� �������, ������� ���������.");
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox(
                    "������� ������� (��� ��� ����� ����� ����� ��� �������� �����):",
                    "�������� �������� �����");

                if (input.Contains("-"))
                {
                    var vertices = input.Split('-');
                    if (vertices.Length == 2 &&
                        int.TryParse(vertices[0], out int from) &&
                        int.TryParse(vertices[1], out int to))
                    {
                        graph.RemoveEdge(from, to);
                        MessageBox.Show($"����� {from}-{to} �������.");
                    }
                    else
                    {
                        MessageBox.Show("������������ ����.");
                    }
                }
                else if (int.TryParse(input, out int vertex))
                {
                    graph.RemoveVertex(vertex);
                    MessageBox.Show($"������� {vertex} �������.");
                }
                else
                {
                    MessageBox.Show("������������ ����.");
                }
            }
        }

        
    }
}

