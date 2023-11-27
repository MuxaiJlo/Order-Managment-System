namespace Order_Managment_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            FilterPanel = new Panel();
            FilterLabel = new Label();
            SearchPanel = new Panel();
            SearchIDtextBox = new TextBox();
            SearchIDlabel = new Label();
            label2 = new Label();
            SearchBox = new TextBox();
            CheckBoxPanel = new Panel();
            comboBoxFilter = new ComboBox();
            AdviceButtonSearch = new Button();
            DataPanel = new Panel();
            dataGridView = new DataGridView();
            ChoosePanel = new Panel();
            LocationTextBox = new TextBox();
            LocationLabel = new Label();
            comboBoxComand = new ComboBox();
            label3 = new Label();
            AdviceButtonFunc = new Button();
            FuncPanel = new Panel();
            SettingsPanel = new Panel();
            Sign = new Label();
            AboutSearch = new Label();
            AboutCommand = new Label();
            AboutMe = new Label();
            AboutButton = new Button();
            FilterPanel.SuspendLayout();
            SearchPanel.SuspendLayout();
            DataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ChoosePanel.SuspendLayout();
            SettingsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // FilterPanel
            // 
            FilterPanel.BackColor = Color.FromArgb(173, 91, 91);
            FilterPanel.Controls.Add(FilterLabel);
            FilterPanel.Controls.Add(SearchPanel);
            FilterPanel.Controls.Add(CheckBoxPanel);
            FilterPanel.Controls.Add(comboBoxFilter);
            FilterPanel.Location = new Point(14, 13);
            FilterPanel.Margin = new Padding(4, 3, 4, 3);
            FilterPanel.Name = "FilterPanel";
            FilterPanel.Size = new Size(284, 670);
            FilterPanel.TabIndex = 0;
            // 
            // FilterLabel
            // 
            FilterLabel.AutoSize = true;
            FilterLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            FilterLabel.ForeColor = Color.FromArgb(28, 28, 28);
            FilterLabel.Location = new Point(44, 20);
            FilterLabel.Margin = new Padding(4, 0, 4, 0);
            FilterLabel.Name = "FilterLabel";
            FilterLabel.Size = new Size(180, 24);
            FilterLabel.TabIndex = 1;
            FilterLabel.Text = "Оберіть таблицю";
            // 
            // SearchPanel
            // 
            SearchPanel.Controls.Add(SearchIDtextBox);
            SearchPanel.Controls.Add(SearchIDlabel);
            SearchPanel.Controls.Add(label2);
            SearchPanel.Controls.Add(SearchBox);
            SearchPanel.Dock = DockStyle.Bottom;
            SearchPanel.Location = new Point(0, 492);
            SearchPanel.Margin = new Padding(4, 3, 4, 3);
            SearchPanel.Name = "SearchPanel";
            SearchPanel.Size = new Size(284, 178);
            SearchPanel.TabIndex = 2;
            // 
            // SearchIDtextBox
            // 
            SearchIDtextBox.Location = new Point(4, 121);
            SearchIDtextBox.Margin = new Padding(4, 3, 4, 3);
            SearchIDtextBox.Name = "SearchIDtextBox";
            SearchIDtextBox.Size = new Size(276, 23);
            SearchIDtextBox.TabIndex = 4;
            SearchIDtextBox.TextChanged += SearchIDtextBox_TextChanged;
            // 
            // SearchIDlabel
            // 
            SearchIDlabel.AutoSize = true;
            SearchIDlabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            SearchIDlabel.ForeColor = Color.FromArgb(28, 28, 28);
            SearchIDlabel.Location = new Point(68, 92);
            SearchIDlabel.Margin = new Padding(4, 0, 4, 0);
            SearchIDlabel.Name = "SearchIDlabel";
            SearchIDlabel.Size = new Size(126, 24);
            SearchIDlabel.TabIndex = 3;
            SearchIDlabel.Text = "Пошук по ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(28, 28, 28);
            label2.Location = new Point(42, 33);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(183, 24);
            label2.TabIndex = 2;
            label2.Text = "Пошукова стрічка";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(4, 62);
            SearchBox.Margin = new Padding(4, 3, 4, 3);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(276, 23);
            SearchBox.TabIndex = 1;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // CheckBoxPanel
            // 
            CheckBoxPanel.Location = new Point(0, 79);
            CheckBoxPanel.Margin = new Padding(4, 3, 4, 3);
            CheckBoxPanel.Name = "CheckBoxPanel";
            CheckBoxPanel.Size = new Size(284, 417);
            CheckBoxPanel.TabIndex = 1;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Items.AddRange(new object[] { "Customers", "Products", "Orders", "Order_Items" });
            comboBoxFilter.Location = new Point(4, 50);
            comboBoxFilter.Margin = new Padding(4, 3, 4, 3);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(276, 22);
            comboBoxFilter.TabIndex = 0;
            comboBoxFilter.SelectedIndexChanged += comboBoxFilter_SelectedIndexChanged;
            // 
            // AdviceButtonSearch
            // 
            AdviceButtonSearch.BackColor = Color.FromArgb(92, 142, 173);
            AdviceButtonSearch.FlatAppearance.BorderSize = 0;
            AdviceButtonSearch.FlatStyle = FlatStyle.Flat;
            AdviceButtonSearch.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AdviceButtonSearch.ForeColor = Color.White;
            AdviceButtonSearch.Location = new Point(4, 304);
            AdviceButtonSearch.Margin = new Padding(4, 3, 4, 3);
            AdviceButtonSearch.Name = "AdviceButtonSearch";
            AdviceButtonSearch.Size = new Size(158, 31);
            AdviceButtonSearch.TabIndex = 5;
            AdviceButtonSearch.Text = "Про фільтри";
            AdviceButtonSearch.UseVisualStyleBackColor = false;
            AdviceButtonSearch.Click += AdviceButtonSearch_Click;
            // 
            // DataPanel
            // 
            DataPanel.AutoScroll = true;
            DataPanel.BackColor = Color.FromArgb(205, 201, 201);
            DataPanel.Controls.Add(dataGridView);
            DataPanel.Location = new Point(304, 13);
            DataPanel.Margin = new Padding(4, 3, 4, 3);
            DataPanel.Name = "DataPanel";
            DataPanel.Size = new Size(649, 379);
            DataPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(649, 379);
            dataGridView.TabIndex = 0;
            // 
            // ChoosePanel
            // 
            ChoosePanel.BackColor = Color.FromArgb(173, 91, 91);
            ChoosePanel.Controls.Add(LocationTextBox);
            ChoosePanel.Controls.Add(LocationLabel);
            ChoosePanel.Controls.Add(comboBoxComand);
            ChoosePanel.Controls.Add(label3);
            ChoosePanel.Location = new Point(304, 403);
            ChoosePanel.Margin = new Padding(4, 3, 4, 3);
            ChoosePanel.Name = "ChoosePanel";
            ChoosePanel.Size = new Size(250, 280);
            ChoosePanel.TabIndex = 2;
            // 
            // LocationTextBox
            // 
            LocationTextBox.Location = new Point(93, 165);
            LocationTextBox.Margin = new Padding(4, 3, 4, 3);
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.ReadOnly = true;
            LocationTextBox.Size = new Size(144, 23);
            LocationTextBox.TabIndex = 5;
            LocationTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LocationLabel
            // 
            LocationLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            LocationLabel.Location = new Point(4, 142);
            LocationLabel.Margin = new Padding(4, 0, 4, 0);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(233, 46);
            LocationLabel.TabIndex = 4;
            LocationLabel.Text = "Ви знаходитесь у таблиці:";
            // 
            // comboBoxComand
            // 
            comboBoxComand.FormattingEnabled = true;
            comboBoxComand.Items.AddRange(new object[] { "INSERT", "UPDATE", "DELETE" });
            comboBoxComand.Location = new Point(34, 72);
            comboBoxComand.Margin = new Padding(4, 3, 4, 3);
            comboBoxComand.Name = "comboBoxComand";
            comboBoxComand.Size = new Size(185, 22);
            comboBoxComand.TabIndex = 3;
            comboBoxComand.SelectedIndexChanged += comboBoxComand_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(28, 28, 28);
            label3.Location = new Point(29, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(178, 24);
            label3.TabIndex = 2;
            label3.Text = "Оберіть команду";
            // 
            // AdviceButtonFunc
            // 
            AdviceButtonFunc.BackColor = Color.FromArgb(92, 142, 173);
            AdviceButtonFunc.FlatAppearance.BorderSize = 0;
            AdviceButtonFunc.FlatStyle = FlatStyle.Flat;
            AdviceButtonFunc.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AdviceButtonFunc.ForeColor = Color.White;
            AdviceButtonFunc.Location = new Point(4, 183);
            AdviceButtonFunc.Margin = new Padding(4, 3, 4, 3);
            AdviceButtonFunc.Name = "AdviceButtonFunc";
            AdviceButtonFunc.Size = new Size(158, 31);
            AdviceButtonFunc.TabIndex = 4;
            AdviceButtonFunc.Text = "Про команди";
            AdviceButtonFunc.UseVisualStyleBackColor = false;
            AdviceButtonFunc.Click += AdviceButtonFunc_Click;
            // 
            // FuncPanel
            // 
            FuncPanel.BackColor = Color.FromArgb(173, 91, 91);
            FuncPanel.Location = new Point(562, 403);
            FuncPanel.Margin = new Padding(4, 3, 4, 3);
            FuncPanel.Name = "FuncPanel";
            FuncPanel.Size = new Size(563, 280);
            FuncPanel.TabIndex = 3;
            // 
            // SettingsPanel
            // 
            SettingsPanel.BackColor = Color.FromArgb(173, 91, 91);
            SettingsPanel.Controls.Add(Sign);
            SettingsPanel.Controls.Add(AdviceButtonSearch);
            SettingsPanel.Controls.Add(AboutSearch);
            SettingsPanel.Controls.Add(AdviceButtonFunc);
            SettingsPanel.Controls.Add(AboutCommand);
            SettingsPanel.Controls.Add(AboutMe);
            SettingsPanel.Controls.Add(AboutButton);
            SettingsPanel.Location = new Point(959, 13);
            SettingsPanel.Margin = new Padding(4, 3, 4, 3);
            SettingsPanel.Name = "SettingsPanel";
            SettingsPanel.Size = new Size(166, 379);
            SettingsPanel.TabIndex = 4;
            // 
            // Sign
            // 
            Sign.AutoSize = true;
            Sign.Location = new Point(28, 365);
            Sign.Margin = new Padding(4, 0, 4, 0);
            Sign.Name = "Sign";
            Sign.Size = new Size(105, 14);
            Sign.TabIndex = 7;
            Sign.Text = "Nazarenko Inc.";
            // 
            // AboutSearch
            // 
            AboutSearch.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AboutSearch.Location = new Point(7, 248);
            AboutSearch.Margin = new Padding(4, 0, 4, 0);
            AboutSearch.Name = "AboutSearch";
            AboutSearch.Size = new Size(159, 53);
            AboutSearch.TabIndex = 6;
            AboutSearch.Text = "Інформація про фільтрацію\r\n";
            // 
            // AboutCommand
            // 
            AboutCommand.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AboutCommand.Location = new Point(8, 131);
            AboutCommand.Margin = new Padding(4, 0, 4, 0);
            AboutCommand.Name = "AboutCommand";
            AboutCommand.Size = new Size(158, 48);
            AboutCommand.TabIndex = 5;
            AboutCommand.Text = "Інформація про команди";
            // 
            // AboutMe
            // 
            AboutMe.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AboutMe.Location = new Point(4, 20);
            AboutMe.Margin = new Padding(4, 0, 4, 0);
            AboutMe.Name = "AboutMe";
            AboutMe.Size = new Size(162, 47);
            AboutMe.TabIndex = 4;
            AboutMe.Text = "Інформація про розробника";
            // 
            // AboutButton
            // 
            AboutButton.BackColor = Color.FromArgb(92, 142, 173);
            AboutButton.FlatAppearance.BorderSize = 0;
            AboutButton.FlatStyle = FlatStyle.Flat;
            AboutButton.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AboutButton.ForeColor = Color.White;
            AboutButton.Location = new Point(4, 71);
            AboutButton.Margin = new Padding(4, 3, 4, 3);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(158, 32);
            AboutButton.TabIndex = 0;
            AboutButton.Text = "Про розробника";
            AboutButton.UseVisualStyleBackColor = false;
            AboutButton.Click += AboutButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 76, 76);
            ClientSize = new Size(1140, 695);
            Controls.Add(SettingsPanel);
            Controls.Add(FuncPanel);
            Controls.Add(ChoosePanel);
            Controls.Add(DataPanel);
            Controls.Add(FilterPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Order Managment System";
            Load += MainForm_Load;
            FilterPanel.ResumeLayout(false);
            FilterPanel.PerformLayout();
            SearchPanel.ResumeLayout(false);
            SearchPanel.PerformLayout();
            DataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ChoosePanel.ResumeLayout(false);
            ChoosePanel.PerformLayout();
            SettingsPanel.ResumeLayout(false);
            SettingsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel FilterPanel;
        private Panel DataPanel;
        private ComboBox comboBoxFilter;
        private DataGridView dataGridView;
        private Panel ChoosePanel;
        private Panel CheckBoxPanel;
        private Label FilterLabel;
        private Panel SearchPanel;
        private Label label2;
        private TextBox SearchBox;
        private Label label3;
        private ComboBox comboBoxComand;
        private Panel FuncPanel;
        private Panel SettingsPanel;
        private Button AdviceButtonSearch;
        private Button AdviceButtonFunc;
        private Button AboutButton;
        private Label AboutMe;
        private Label AboutSearch;
        private Label AboutCommand;
        private Label LocationLabel;
        private TextBox LocationTextBox;
        private Label SearchIDlabel;
        private TextBox SearchIDtextBox;
        private Label Sign;
    }
}