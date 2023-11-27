namespace Order_Managment_System
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            AboutPanel = new Panel();
            AboutLabel = new Label();
            pictureBox1 = new PictureBox();
            AboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AboutPanel
            // 
            AboutPanel.BackColor = Color.FromArgb(173, 91, 91);
            AboutPanel.Controls.Add(AboutLabel);
            AboutPanel.Controls.Add(pictureBox1);
            AboutPanel.Location = new Point(14, 13);
            AboutPanel.Margin = new Padding(4, 3, 4, 3);
            AboutPanel.Name = "AboutPanel";
            AboutPanel.Size = new Size(708, 292);
            AboutPanel.TabIndex = 0;
            // 
            // AboutLabel
            // 
            AboutLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            AboutLabel.Location = new Point(27, 23);
            AboutLabel.Margin = new Padding(4, 0, 4, 0);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(442, 252);
            AboutLabel.TabIndex = 1;
            AboutLabel.Text = "Розробник: Назаренко Михайло Романович\r\n\r\nВік: 19 років\r\n\r\nЗайнятість: Студент\r\n\r\nМісце навчання: ХНЕУ\r\n\r\nУлюбелена тварина: Кіт\r\n\r\nХоббі: Пестити котів";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.myphoto;
            pictureBox1.Location = new Point(488, 23);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 238);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 76, 76);
            ClientSize = new Size(736, 318);
            Controls.Add(AboutPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "AboutForm";
            Text = "AboutForm";
            AboutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel AboutPanel;
        private PictureBox pictureBox1;
        private Label AboutLabel;
    }
}