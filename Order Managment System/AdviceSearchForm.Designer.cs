namespace Order_Managment_System
{
    partial class AdviceSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdviceSearchForm));
            Panel = new Panel();
            pictureBox2 = new PictureBox();
            FilterInfo = new Label();
            HeadFilter = new Label();
            pictureBox1 = new PictureBox();
            SearchInfo = new Label();
            HeadSearch = new Label();
            Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.BackColor = Color.FromArgb(173, 91, 91);
            Panel.Controls.Add(pictureBox2);
            Panel.Controls.Add(FilterInfo);
            Panel.Controls.Add(HeadFilter);
            Panel.Controls.Add(pictureBox1);
            Panel.Controls.Add(SearchInfo);
            Panel.Controls.Add(HeadSearch);
            Panel.Location = new Point(14, 13);
            Panel.Margin = new Padding(4, 3, 4, 3);
            Panel.Name = "Panel";
            Panel.Size = new Size(800, 350);
            Panel.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.insert;
            pictureBox2.Location = new Point(521, 216);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(140, 118);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // FilterInfo
            // 
            FilterInfo.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            FilterInfo.Location = new Point(405, 38);
            FilterInfo.Margin = new Padding(4, 0, 4, 0);
            FilterInfo.Name = "FilterInfo";
            FilterInfo.Size = new Size(392, 176);
            FilterInfo.TabIndex = 4;
            FilterInfo.Text = resources.GetString("FilterInfo.Text");
            // 
            // HeadFilter
            // 
            HeadFilter.AutoSize = true;
            HeadFilter.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            HeadFilter.Location = new Point(390, 16);
            HeadFilter.Margin = new Padding(4, 0, 4, 0);
            HeadFilter.Name = "HeadFilter";
            HeadFilter.Size = new Size(352, 20);
            HeadFilter.TabIndex = 3;
            HeadFilter.Text = "Про фільтрацію таблиць (Ctrl+(1...4))";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(128, 216);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 118);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // SearchInfo
            // 
            SearchInfo.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            SearchInfo.Location = new Point(4, 38);
            SearchInfo.Margin = new Padding(4, 0, 4, 0);
            SearchInfo.Name = "SearchInfo";
            SearchInfo.Size = new Size(394, 176);
            SearchInfo.TabIndex = 1;
            SearchInfo.Text = resources.GetString("SearchInfo.Text");
            // 
            // HeadSearch
            // 
            HeadSearch.AutoSize = true;
            HeadSearch.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            HeadSearch.Location = new Point(75, 16);
            HeadSearch.Margin = new Padding(4, 0, 4, 0);
            HeadSearch.Name = "HeadSearch";
            HeadSearch.Size = new Size(211, 20);
            HeadSearch.TabIndex = 0;
            HeadSearch.Text = "Про пошукову стрічку";
            // 
            // AdviceSearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 76, 76);
            ClientSize = new Size(828, 376);
            Controls.Add(Panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdviceSearchForm";
            Text = "AdviceSearchForm";
            Panel.ResumeLayout(false);
            Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel;
        private Label SearchInfo;
        private Label HeadSearch;
        private PictureBox pictureBox1;
        private Label FilterInfo;
        private Label HeadFilter;
        private PictureBox pictureBox2;
    }
}