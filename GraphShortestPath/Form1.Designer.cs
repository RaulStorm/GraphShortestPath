namespace GraphShortestPath
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
            txtFrom = new TextBox();
            txtTo = new TextBox();
            txtStart = new TextBox();
            txtEnd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtVert = new TextBox();
            btnAddVertex = new Button();
            btnAddEdge = new Button();
            btnFindPath = new Button();
            btnSaveResult = new Button();
            btnLoadGraph = new Button();
            checkBox1 = new CheckBox();
            btnClearGraph = new Button();
            exitButton = new Button();
            btnHelp = new Button();
            SuspendLayout();
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(228, 119);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(150, 31);
            txtFrom.TabIndex = 1;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(228, 218);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(150, 31);
            txtTo.TabIndex = 2;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(228, 314);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(150, 31);
            txtStart.TabIndex = 3;
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(228, 376);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(150, 31);
            txtEnd.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 16);
            label1.Name = "label1";
            label1.Size = new Size(159, 25);
            label1.TabIndex = 6;
            label1.Text = "Введите вершину:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 125);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 7;
            label2.Text = "От вершины:\t";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 224);
            label3.Name = "label3";
            label3.Size = new Size(121, 25);
            label3.TabIndex = 8;
            label3.Text = "До вершины:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 314);
            label4.Name = "label4";
            label4.Size = new Size(181, 25);
            label4.TabIndex = 9;
            label4.Text = "Начальная вершина:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 376);
            label5.Name = "label5";
            label5.Size = new Size(172, 25);
            label5.TabIndex = 10;
            label5.Text = "Конечная вершина:";
            // 
            // txtVert
            // 
            txtVert.Location = new Point(228, 16);
            txtVert.Name = "txtVert";
            txtVert.Size = new Size(150, 31);
            txtVert.TabIndex = 11;
            // 
            // btnAddVertex
            // 
            btnAddVertex.BackColor = Color.Lavender;
            btnAddVertex.Location = new Point(396, 10);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(106, 91);
            btnAddVertex.TabIndex = 12;
            btnAddVertex.Text = "Добавить вершину";
            btnAddVertex.UseVisualStyleBackColor = false;
            btnAddVertex.Click += btnAddVertex_Click;
            // 
            // btnAddEdge
            // 
            btnAddEdge.BackColor = Color.Lavender;
            btnAddEdge.Location = new Point(396, 130);
            btnAddEdge.Name = "btnAddEdge";
            btnAddEdge.Size = new Size(106, 101);
            btnAddEdge.TabIndex = 13;
            btnAddEdge.Text = "Добавить ребро";
            btnAddEdge.UseVisualStyleBackColor = false;
            btnAddEdge.Click += btnAddEdge_Click;
            // 
            // btnFindPath
            // 
            btnFindPath.BackColor = Color.Green;
            btnFindPath.Location = new Point(396, 314);
            btnFindPath.Name = "btnFindPath";
            btnFindPath.Size = new Size(93, 93);
            btnFindPath.TabIndex = 14;
            btnFindPath.Text = "Поиск пути";
            btnFindPath.UseVisualStyleBackColor = false;
            btnFindPath.Click += btnFindPath_Click;
            // 
            // btnSaveResult
            // 
            btnSaveResult.BackColor = Color.Green;
            btnSaveResult.Location = new Point(508, 314);
            btnSaveResult.Name = "btnSaveResult";
            btnSaveResult.Size = new Size(111, 93);
            btnSaveResult.TabIndex = 15;
            btnSaveResult.Text = "Сохранить результат";
            btnSaveResult.UseVisualStyleBackColor = false;
            btnSaveResult.Click += btnSaveResult_Click;
            // 
            // btnLoadGraph
            // 
            btnLoadGraph.BackColor = Color.Lavender;
            btnLoadGraph.Location = new Point(556, 16);
            btnLoadGraph.Name = "btnLoadGraph";
            btnLoadGraph.Size = new Size(113, 94);
            btnLoadGraph.TabIndex = 16;
            btnLoadGraph.Text = "Загрузить граф";
            btnLoadGraph.UseVisualStyleBackColor = false;
            btnLoadGraph.Click += btnLoadGraph_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(159, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(219, 29);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Ребро направленное?";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnClearGraph
            // 
            btnClearGraph.BackColor = Color.Red;
            btnClearGraph.Location = new Point(827, 119);
            btnClearGraph.Name = "btnClearGraph";
            btnClearGraph.Size = new Size(151, 77);
            btnClearGraph.TabIndex = 18;
            btnClearGraph.Text = "Удалить данные";
            btnClearGraph.UseVisualStyleBackColor = false;
            btnClearGraph.Click += btnClearGraph_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(788, 344);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(203, 63);
            exitButton.TabIndex = 19;
            exitButton.Text = "Выход из программы";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Yellow;
            btnHelp.Location = new Point(827, 27);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(151, 57);
            btnHelp.TabIndex = 20;
            btnHelp.Text = "Помощь";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 424);
            Controls.Add(btnHelp);
            Controls.Add(exitButton);
            Controls.Add(btnClearGraph);
            Controls.Add(checkBox1);
            Controls.Add(btnLoadGraph);
            Controls.Add(btnSaveResult);
            Controls.Add(btnFindPath);
            Controls.Add(btnAddEdge);
            Controls.Add(btnAddVertex);
            Controls.Add(txtVert);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEnd);
            Controls.Add(txtStart);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtFrom;
        private TextBox txtTo;
        private TextBox txtStart;
        private TextBox txtEnd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtVert;
        private Button btnAddVertex;
        private Button btnAddEdge;
        private Button btnFindPath;
        private Button btnSaveResult;
        private Button btnLoadGraph;
        private CheckBox checkBox1;
        private Button btnClearGraph;
        private Button exitButton;
        private Button btnHelp;
    }
}
